namespace StockTraderTransaq.InteractionRequests
{
	using System;
	using System.Windows.Input;
	using System.Windows.Threading;
	using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
	using System.Windows;
	using System.Windows.Interactivity;

    using StockTraderTransaq.InteractionWindowViews;
    using StockTraderTransaq.ControlLibrary;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class PopupWindowAction : TriggerAction<FrameworkElement>
	{
		#region DependecyProperties

		/// <summary>
		/// The content of the child window to display as part of the popup.
		/// </summary>
		public static readonly DependencyProperty WindowContentProperty =
			DependencyProperty.Register(
				"WindowContent",
				typeof(FrameworkElement),
				typeof(PopupWindowAction),
				new PropertyMetadata(null));

		/// <summary>
		/// The <see cref="DataTemplate"/> to apply to the popup content.
		/// </summary>
		public static readonly DependencyProperty ContentTemplateProperty =
			DependencyProperty.Register(
				"ContentTemplate",
				typeof(DataTemplate),
				typeof(PopupWindowAction),
				new PropertyMetadata(null));

		/// <summary>
		/// The ok content property
		/// </summary>
		public static readonly DependencyProperty OkContentProperty =
			DependencyProperty.Register(
				"OkContent",
				typeof(object),
				typeof(PopupWindowAction),
				new PropertyMetadata(null));

		#endregion

		#region Getters and Setters

		/// <summary>
		/// Gets or sets the content of the window.
		/// </summary>
		public FrameworkElement WindowContent
		{
			get { return (FrameworkElement)GetValue(WindowContentProperty); }
			set { SetValue(WindowContentProperty, value); }
		}

		/// <summary>
		/// Gets or sets the content template for the window.
		/// </summary>
		public DataTemplate ContentTemplate
		{
			get { return (DataTemplate)GetValue(ContentTemplateProperty); }
			set { SetValue(ContentTemplateProperty, value); }
		}

		/// <summary>
		/// Gets or sets the content of the ok.
		/// </summary>
		/// <value>
		/// The content of the ok.
		/// </value>
		public object OkContent
		{
			get { return GetValue(OkContentProperty); }
			set { SetValue(OkContentProperty, value); }
		}

		#endregion

		#region PopupWindowAction logic

		/// <summary>
		/// Displays the child window and collects results for <see cref="IInteractionRequest"/>.
		/// </summary>
		/// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
		protected override void Invoke(object parameter)
		{
			var args = parameter as InteractionRequestedEventArgs;
			if (args == null)
			{
				return;
			}

			// If the WindowContent shouldn't be part of another visual tree.
			if (this.WindowContent != null && this.WindowContent.Parent != null)
			{
				return;
			}

			var wrapperWindow = this.GetWindow(args.Context);

			var callback = args.Callback;
			EventHandler handler = null;
			handler = (o, e) =>
				{
					wrapperWindow.Closed -= handler;
					wrapperWindow.Content = null;
					callback();
				};
			wrapperWindow.Closed += handler;

			wrapperWindow.ShowDialog();
		}

		/// <summary>
		/// Checks if the WindowContent or its DataContext implements IPopupWindowActionAware and IRegionManagerAware.
		/// If so, it sets the corresponding values.
		/// Also, if WindowContent does not have a RegionManager attached, it creates a new scoped RegionManager for it.
		/// </summary>
		/// <param name="notification">The notification to be set as a DataContext in the HostWindow.</param>
		/// <param name="wrapperWindow">The HostWindow</param>
		protected void PrepareContentForWindow(INotification notification, ChildWindow wrapperWindow)
		{
			if (this.WindowContent == null)
			{
				return;
			}

			// We set the WindowContent as the content of the window. 
			wrapperWindow.Content = this.WindowContent;
		}

		#endregion

		#region Window creation methods

		/// <summary>
		/// Returns the window to display as part of the trigger action.
		/// </summary>
		/// <param name="notification">The notification to be set as a DataContext in the window.</param>
		/// <returns></returns>
		protected ChildWindow GetWindow(INotification notification)
		{
			ChildWindow wrapperWindow;

			if (this.WindowContent != null)
			{
				// If the WindowContent does not have its own DataContext, it will inherit this one.
				wrapperWindow = new ConfirmationDialogWindow { DataContext = notification, Title = notification.Title };

				this.PrepareContentForWindow(notification, wrapperWindow);
			}
			else
			{
				wrapperWindow = this.CreateDefaultWindow(notification);
				wrapperWindow.DataContext = notification;
			}

			return wrapperWindow;
		}

		protected virtual ChildWindow CreateDefaultWindow(INotification notification)
		{
			return new NotificationDialogWindow { NotificationTemplate = this.ContentTemplate, OkContent = this.OkContent };
		}

		#endregion
	}
}
