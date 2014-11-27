namespace StockTraderTransaq.InteractionRequests
{
	using System.Windows;
	using System.Windows.Threading;
	using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
    using StockTraderTransaq.InteractionWindowViews;
    using StockTraderTransaq.ControlLibrary;
    using Microsoft.Practices.ServiceLocation;

	public class ModalWindowAction : ConfirmationWindowAction
	{
		protected override ChildWindow CreateDefaultWindow(INotification notification)
		{
			if (notification is Dialog)
			{
                var dialog = (notification as Dialog);

				var window = ServiceLocator.Current.GetInstance<ModalDialogWindow>();
                window.NotificationTemplate = this.ContentTemplate;

				return window;
			}

			return base.CreateDefaultWindow(notification);
		}
	}
}
