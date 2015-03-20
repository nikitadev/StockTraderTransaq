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
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;
using StockTraderTransaq.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using StockTraderTransaq.Modules.Market;
using StockTraderTransaq.Modules.Position;
using StockTraderTransaq.Modules.Watch;
using StockTraderTransaq.Modules.News;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.ServiceLocation;

namespace StockTraderTransaq
{
    [CLSCompliant(false)]
    public partial class StockTraderTransaqBootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(StockTraderTransaqBootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(StockTraderTransaqCommands).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MarketModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(PositionModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(WatchModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(NewsModule).Assembly));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override void ConfigureServiceLocator()
        {
            var serviceLocator = this.Container.GetExportedValue<IServiceLocator>();
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();

            factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));

            return factory;
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }
    }
}
