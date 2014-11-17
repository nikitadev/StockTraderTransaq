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
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel.Composition;

namespace StockTraderTransaq.Infrastructure
{
    public static class StockTraderTransaqCommands
    {
        private static CompositeCommand submitOrderCommand = new CompositeCommand(true);
        private static CompositeCommand cancelOrderCommand = new CompositeCommand(true);
        private static CompositeCommand submitAllOrdersCommand = new CompositeCommand();
        private static CompositeCommand cancelAllOrdersCommand = new CompositeCommand();

        public static CompositeCommand SubmitOrderCommand
        {
            get { return submitOrderCommand; }
            set { submitOrderCommand = value; }
        }

        public static CompositeCommand CancelOrderCommand
        {
            get { return cancelOrderCommand; }
            set { cancelOrderCommand = value; }
        }

        public static CompositeCommand SubmitAllOrdersCommand
        {
            get { return submitAllOrdersCommand; }
            set { submitAllOrdersCommand = value; }
        }

        public static CompositeCommand CancelAllOrdersCommand
        {
            get { return cancelAllOrdersCommand; }
            set { cancelAllOrdersCommand = value; }
        }
    }

    [Export]    
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StockTraderTransaqCommandProxy
    {
        virtual public CompositeCommand SubmitOrderCommand
        {
            get { return StockTraderTransaqCommands.SubmitOrderCommand; }
        }

        virtual public CompositeCommand CancelOrderCommand
        {
            get { return StockTraderTransaqCommands.CancelOrderCommand; }
        }

        virtual public CompositeCommand SubmitAllOrdersCommand
        {
            get { return StockTraderTransaqCommands.SubmitAllOrdersCommand; }
        }

        virtual public CompositeCommand CancelAllOrdersCommand
        {
            get { return StockTraderTransaqCommands.CancelAllOrdersCommand; }
        }
    }
}
