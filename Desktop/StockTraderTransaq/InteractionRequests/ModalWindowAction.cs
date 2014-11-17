namespace StockTraderTransaq.InteractionRequests
{
	using System.Windows;
	using System.Windows.Threading;
	using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
    using StockTraderTransaq.InteractionWindowViews;
    using StockTraderTransaq.ControlLibrary;

	public class ModalWindowAction : ConfirmationWindowAction
	{
		protected override ChildWindow CreateDefaultWindow(INotification notification)
		{
			if (notification is Dialog)
			{
				var window =  new ModalDialogWindow { NotificationTemplate = this.ContentTemplate };

				var dialog = (notification as Dialog);
				var dialogContent = dialog.Content;

				/*if (dialogContent is IAddonView)
				{
					var context = (dialogContent as IAddonView).ViewContext;
					context.Validated += async (s, e) =>
					{
						await Application.Current.Dispatcher.InvokeAsync(() =>
						{
							window.IsOkEnable = !context.HasErrors;
						}, DispatcherPriority.ContextIdle);
					};
				}*/

				return window;
			}

			return base.CreateDefaultWindow(notification);
		}
	}
}
