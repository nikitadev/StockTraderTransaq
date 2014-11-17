//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Microsoft.Practices.Prism.Events;
using StockTraderTransaq.Infrastructure;
using StockTraderTransaq.Infrastructure.Interfaces;
using StockTraderTransaq.Modules.Market.Properties;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.PubSubEvents;

namespace StockTraderTransaq.Modules.Market.Services
{
    [Export(typeof(IMarketFeedService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MarketFeedService : IMarketFeedService, IDisposable
    {
        private IEventAggregator EventAggregator { get; set; }
        private readonly Dictionary<string, decimal> priceList = new Dictionary<string, decimal>();
        private readonly Dictionary<string, long> volumeList = new Dictionary<string, long>();
        static readonly Random randomGenerator = new Random(unchecked((int)DateTime.Now.Ticks));
        private Timer timer;
        private int refreshInterval = 10000;
        private readonly object lockObject = new object();

        [ImportingConstructor]
        public MarketFeedService(IEventAggregator eventAggregator)
            : this(XDocument.Parse(Resources.Market), eventAggregator)
        {
        }

        protected MarketFeedService(XDocument document, IEventAggregator eventAggregator)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            EventAggregator = eventAggregator;
            this.timer = new Timer(TimerTick);

            var marketItemsElement = document.Element("MarketItems");
	        if (marketItemsElement != null)
	        {
		        var refreshRateAttribute = marketItemsElement.Attribute("RefreshRate");
		        if (refreshRateAttribute != null)
		        {
			        this.RefreshInterval = CalculateRefreshIntervalMillisecondsFromSeconds(int.Parse(refreshRateAttribute.Value, CultureInfo.InvariantCulture));
		        }
	        }

	        if (marketItemsElement != null)
	        {
		        var itemElements = marketItemsElement.Elements("MarketItem");
		        foreach (XElement item in itemElements)
		        {
			        string tickerSymbol = item.Attribute("TickerSymbol").Value;
			        decimal lastPrice = decimal.Parse(item.Attribute("LastPrice").Value, NumberStyles.Float, CultureInfo.InvariantCulture);
			        long volume = Convert.ToInt64(item.Attribute("Volume").Value, CultureInfo.InvariantCulture);
			        this.priceList.Add(tickerSymbol, lastPrice);
			        this.volumeList.Add(tickerSymbol, volume);
		        }
	        }
        }

        public int RefreshInterval
        {
            get { return this.refreshInterval; }
            set
            {
                this.refreshInterval = value;
                this.timer.Change(this.refreshInterval, this.refreshInterval);
            }
        }

        /// <summary>
        /// Callback for Timer
        /// </summary>
        /// <param name="state"></param>
        private void TimerTick(object state)
        {
            UpdatePrices();
        }

        public decimal GetPrice(string tickerSymbol)
        {
            if (!SymbolExists(tickerSymbol))
                throw new ArgumentException(Resources.MarketFeedTickerSymbolNotFoundException, "tickerSymbol");

            return this.priceList[tickerSymbol];
        }

        public long GetVolume(string tickerSymbol)
        {
            return this.volumeList[tickerSymbol];
        }

        public bool SymbolExists(string tickerSymbol)
        {
            return this.priceList.ContainsKey(tickerSymbol);
        }

        protected void UpdatePrice(string tickerSymbol, decimal newPrice, long newVolume)
        {
            lock (this.lockObject)
            {
                this.priceList[tickerSymbol] = newPrice;
                this.volumeList[tickerSymbol] = newVolume;
            }
            OnMarketPricesUpdated();
        }

        protected void UpdatePrices()
        {
            lock (this.lockObject)
            {
                foreach (string symbol in this.priceList.Keys.ToArray())
                {
                    decimal newValue = this.priceList[symbol];
                    newValue += Convert.ToDecimal(randomGenerator.NextDouble() * 10f) - 5m;
                    this.priceList[symbol] = newValue > 0 ? newValue : 0.1m;
                }
            }
            OnMarketPricesUpdated();
        }

        private void OnMarketPricesUpdated()
        {
            Dictionary<string, decimal> clonedPriceList = null;
            lock (this.lockObject)
            {
                clonedPriceList = new Dictionary<string, decimal>(this.priceList);
            }
            EventAggregator.GetEvent<MarketPricesUpdatedEvent>().Publish(clonedPriceList);
        }

        private static int CalculateRefreshIntervalMillisecondsFromSeconds(int seconds)
        {
            return seconds * 1000;
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (this.timer != null)
                this.timer.Dispose();
            this.timer = null;
        }

        // Use C# destructor syntax for finalization code.
        ~MarketFeedService()
        {
            Dispose(false);
        }

        #endregion
    }
}
