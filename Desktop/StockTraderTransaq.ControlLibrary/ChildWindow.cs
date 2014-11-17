namespace StockTraderTransaq.ControlLibrary
{
	using System.ComponentModel;
	using System.Windows;

	public class ChildWindow : Window
	{
		public static readonly DependencyProperty NotificationTemplateProperty =
			DependencyProperty.Register(
				"NotificationTemplate",
				typeof(DataTemplate),
				typeof(ChildWindow),
				new PropertyMetadata(null));

		/// <summary>
		/// The content template to use when showing <see cref="Confirmation"/> data.
		/// </summary>
		public DataTemplate NotificationTemplate
		{
			get { return (DataTemplate)GetValue(NotificationTemplateProperty); }
			set { SetValue(NotificationTemplateProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Dialogs.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty NavigationProperty =
			DependencyProperty.Register("Navigation", typeof(object), typeof(ChildWindow), new UIPropertyMetadata(null));

		[Category("Content")]
		public object Navigation
		{
			get { return GetValue(NavigationProperty); }
			set { SetValue(NavigationProperty, value); }
		}

		static ChildWindow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ChildWindow), new FrameworkPropertyMetadata(typeof(ChildWindow)));
		}

		public ChildWindow()
		{
			Owner = Application.Current.MainWindow;

			if (Owner != null)
			{
				Point position = Owner.PointToScreen(new Point(0, 0));

				Top = position.Y;
				Left = position.X;

				Height = Owner.Height;
				Width = Owner.Width;
			}
		}
	}
}
