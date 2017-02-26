namespace StockTraderTransaq.InteractionRequests
{
	using MahApps.Metro.SimpleChildWindow;
	using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
	using Microsoft.Practices.ServiceLocation;
	using StockTraderTransaq.InteractionWindowViews;

	public class ModalWindowAction : ConfirmationWindowAction
	{
		protected override ChildWindow CreateDefaultWindow(INotification notification)
		{
			if (notification is Dialog)
			{
                var dialog = (notification as Dialog);

				var window = ServiceLocator.Current.GetInstance<ModalDialogWindow>();
                //window.NotificationTemplate = this.ContentTemplate;

				return window;
			}

			return base.CreateDefaultWindow(notification);
		}
	}
}
