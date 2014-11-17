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
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System;
using Microsoft.Practices.Prism.Mvvm;
using StockTraderTransaq.InteractionRequests;
using System.ComponentModel;
using Microsoft.Practices.ServiceLocation;

namespace StockTraderTransaq
{
    [Export]
    public class ShellViewModel : BindableBase
    {
        // This is where any view model logic for the shell would go.

        public string Title { get; set; }

        public ICommand RaiseAboutCommand { get; set; }
        public ICommand RaiseMinimizeCommand { get; set; }
        public ICommand RaiseCloseCommand { get; set; }

        public InteractionRequest<IConfirmation> ConfirmationRequest { get; private set; }
        public InteractionRequest<INotification> NotificationRequest { get; private set; }
        public InteractionRequest<Dialog> DialogRequest { get; private set; }

        public ICommand LoadedCommand { get; private set; }

        [ImportingConstructor]
        public ShellViewModel()
        {
            this.Title = StockTraderTransaq.Properties.Resources.Title;

            this.ConfirmationRequest = new InteractionRequest<IConfirmation>();
            this.NotificationRequest = new InteractionRequest<INotification>();
            this.DialogRequest = new InteractionRequest<Dialog>();

            // Commands for each of the buttons. Each of these raise a different interaction request.
            this.RaiseAboutCommand = new DelegateCommand(this.OnAbout);
            this.RaiseMinimizeCommand = new DelegateCommand(this.OnMinimize);
            this.RaiseCloseCommand = new DelegateCommand(this.OnClose);

            this.LoadedCommand = new DelegateCommand<RoutedEventArgs>(this.OnLoaded);
        }

        private void OnLoaded(RoutedEventArgs obj)
        {
            CallLoginDialog();
        }

        private void CallLoginDialog()
        {
            var dialog = new Dialog
            {
                Title = "Login",
                OkContent = StockTraderTransaq.Properties.Resources.Ok,
                CancelContent = StockTraderTransaq.Properties.Resources.Cancel,
                Content = ServiceLocator.Current.GetInstance<Login>()
            };

            this.DialogRequest.Raise(dialog, this.OnCloseLoginDialogEventHandler);
        }

        private void OnCloseLoginDialogEventHandler(Dialog d)
        {
            if (d.Confirmed)
            {
                /*var viewModel = Addons.SingleOrDefault(a => a.Manifest.Id.Equals(d.Id));
                if (viewModel != null)
                {
                    viewModel.ActionCommand.Execute();
                }*/
            }
        }

        private void OnAbout()
        {
            this.NotificationRequest.Raise(new Notification 
            { 
                Title = StockTraderTransaq.Properties.Resources.AboutTitle, 
                Content = StockTraderTransaq.Properties.Resources.AboutMessage 
            });
        }

        private void OnMinimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnClose()
        {
            //eventAggregator.GetEvent<CancelEvent>().Publish(this);

            this.ConfirmationRequest.Raise(
                    new Confirmation
                    {
                        Content = StockTraderTransaq.Properties.Resources.ConfirmExitMessage,
                        Title = StockTraderTransaq.Properties.Resources.ConfirmExitTitle
                    },
                    cb => { if (cb.Confirmed) Application.Current.MainWindow.Close(); });
        }
    }
}
