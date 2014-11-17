namespace StockTraderTransaq.InteractionRequests
{
	using System.Windows;
	using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
	using StockTraderTransaq.InteractionWindowViews;
    using StockTraderTransaq.ControlLibrary;

	public class ConfirmationWindowAction : PopupWindowAction
	{
		public static readonly DependencyProperty CancelContentProperty =
			DependencyProperty.Register(
				"CancelContent",
				typeof(object),
				typeof(ConfirmationWindowAction),
				new PropertyMetadata(null));

		public object CancelContent
		{
			get { return GetValue(CancelContentProperty); }
			set { SetValue(CancelContentProperty, value); }
		}

		protected override ChildWindow CreateDefaultWindow(INotification notification)
		{
			if (notification is Confirmation)
			{
				return new ConfirmationDialogWindow { NotificationTemplate = this.ContentTemplate, CancelContent = this.CancelContent, OkContent = this.OkContent };
			}

			return base.CreateDefaultWindow(notification);
		}
	}
}
