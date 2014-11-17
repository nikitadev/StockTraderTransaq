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
using System.Xml.Linq;
using StockTraderTransaq.Infrastructure.Interfaces;
using StockTraderTransaq.Infrastructure.Models;
using StockTraderTransaq.Modules.Market.Properties;
using System.ComponentModel.Composition;

namespace StockTraderTransaq.Modules.Market.Services
{
    [Export(typeof(IMarketHistoryService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MarketHistoryService : IMarketHistoryService
    {
        private Dictionary<string, MarketHistoryCollection> marketHistory;

        public MarketHistoryService()
        {
            InitializeMarketHistory();
        }

        private void InitializeMarketHistory()
        {
            var document = XDocument.Parse(Resources.MarketHistory);

            this.marketHistory = document.Descendants("MarketHistoryItem")
                .GroupBy(x => x.Attribute("TickerSymbol").Value,
                         x => new MarketHistoryItem
                                  {
                                      DateTimeMarker = DateTime.Parse(x.Attribute("Date").Value, CultureInfo.InvariantCulture),
                                      Value = Decimal.Parse(x.Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                                  })
                .ToDictionary(group => group.Key, group => new MarketHistoryCollection(group));
        }

        public MarketHistoryCollection GetPriceHistory(string tickerSymbol)
        {
            MarketHistoryCollection items = this.marketHistory[tickerSymbol];
            return items;
        }
    }
}
