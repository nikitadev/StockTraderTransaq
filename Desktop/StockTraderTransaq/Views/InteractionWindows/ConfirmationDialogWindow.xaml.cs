namespace StockTraderTransaq.InteractionWindowViews
{
	using StockTraderTransaq.ControlLibrary;
	using StockTraderTransaq.Infrastructure;
	using StockTraderTransaq.InteractionRequests;
	using System.Windows;
	using MahApps.Metro;
	using MahApps.Metro.SimpleChildWindow;


	/// <summary>
	/// Interaction logic for PopupWindow.xaml
	/// </summary>
	public partial class ConfirmationDialogWindow : ChildWindow
	{
		public static readonly DependencyProperty OkContentProperty =
			DependencyProperty.Register(
				"OkContent",
				typeof(object),
				typeof(ConfirmationDialogWindow),
				new PropertyMetadata(null));

		public object OkContent
		{
			get { return GetValue(OkContentProperty); }
			set { SetValue(OkContentProperty, value); }
		}

		public static readonly DependencyProperty CancelContentProperty =
			DependencyProperty.Register(
				"CancelContent",
				typeof(object),
				typeof(ConfirmationDialogWindow),
				new PropertyMetadata(null));

		public object CancelContent
		{
			get { return GetValue(CancelContentProperty); }
			set { SetValue(CancelContentProperty, value); }
		}

		public ConfirmationDialogWindow()
		{
			InitializeComponent();
		}

		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);

			if (e.Property == CancelContentProperty)
			{
				CancelButton.Content = CancelContent;
			}

			if (e.Property == OkContentProperty)
			{
				OkButton.Content = OkContent;
			}
		}
	}
}
