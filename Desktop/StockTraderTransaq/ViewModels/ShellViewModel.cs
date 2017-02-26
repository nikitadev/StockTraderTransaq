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
using TransaqModelComponent;

namespace StockTraderTransaq
{
    [Export]
    public class ShellViewModel : BindableBase, IDisposable
    {
        // This is where any view model logic for the shell would go.

        private readonly TransaqConnector transaqConnector;

        public string Title { get; set; }

        public bool IsContentGridVisible { get; set; }

        public bool IsSideGridVisible { get; set; }

        public ICommand RaiseAboutCommand { get; set; }
        public ICommand RaiseMinimizeCommand { get; set; }
        public ICommand RaiseCloseCommand { get; set; }

        public InteractionRequest<IConfirmation> ConfirmationRequest { get; private set; }
        public InteractionRequest<INotification> NotificationRequest { get; private set; }
        public InteractionRequest<LoginViewModel> LoginRequest { get; private set; }
        public InteractionRequest<LoadingViewModel> LoadingRequest { get; private set; }

        public ICommand LoadedCommand { get; private set; }

        [ImportingConstructor]
        public ShellViewModel()
        {
            this.transaqConnector = new TransaqConnector();

            this.Title = StockTraderTransaq.Properties.Resources.Title;

            this.IsContentGridVisible = false;

            this.IsSideGridVisible = false;

            this.ConfirmationRequest = new InteractionRequest<IConfirmation>();
            this.NotificationRequest = new InteractionRequest<INotification>();

            this.LoginRequest = new InteractionRequest<LoginViewModel>();
            this.LoadingRequest = new InteractionRequest<LoadingViewModel>();

            // Commands for each of the buttons. Each of these raise a different interaction request.
            this.RaiseAboutCommand = new DelegateCommand(this.OnAbout);
            this.RaiseCloseCommand = new DelegateCommand(this.OnClose);
            this.RaiseMinimizeCommand = new DelegateCommand(this.OnMinimize);

            this.LoadedCommand = new DelegateCommand<RoutedEventArgs>(this.OnLoaded);
        }

        ~ShellViewModel()
        {
            Dispose();
        }

        private void OnLoaded(RoutedEventArgs obj)
        {
            //CallLoginDialog();

            this.IsContentGridVisible = true;

            this.IsSideGridVisible = true;
        }

        private void CallLoginDialog()
        {
            var dialog = ServiceLocator.Current.GetInstance<LoginViewModel>();
            dialog.Title = StockTraderTransaq.Properties.Resources.LoginTitle;
            dialog.OkContent = StockTraderTransaq.Properties.Resources.Ok;
            dialog.CancelContent = StockTraderTransaq.Properties.Resources.Cancel;
            dialog.Content = ServiceLocator.Current.GetInstance<Login>();

            this.LoginRequest.Raise(dialog, this.OnCloseLoginDialogEventHandler);

            CreateLoadingDialog();
        }

        private async void OnCloseLoginDialogEventHandler(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Confirmed)
            {               
                // определение папки, в которой запущена программа
                string logPath = String.Concat(System.IO.Directory.GetCurrentDirectory(), "\0");

                await transaqConnector.Initialize(logPath, 2);

                await transaqConnector.Connect(loginViewModel.Login, loginViewModel.Password, "213.247.141.133", 3900, logPath);

                if (transaqConnector.IsConnected)
                {
                    this.IsContentGridVisible = true;

                    this.IsSideGridVisible = true;
                }
            }
            else
            {
                Environment.Exit(-1);
            }
        }

        private void CreateLoadingDialog()
        { 
            var dialog = ServiceLocator.Current.GetInstance<LoadingViewModel>();
            dialog.Title = Properties.Resources.LoadingTitle;
            dialog.Content = ServiceLocator.Current.GetInstance<Loading>();

            this.LoadingRequest.Raise(dialog);
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

        public void Dispose()
        {
            transaqConnector.Dispose();
        }
    }
}
