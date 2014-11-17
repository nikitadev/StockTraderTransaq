namespace StockTraderTransaq.InteractionWindowViews
{
    using StockTraderTransaq.ControlLibrary;
    using StockTraderTransaq.Infrastructure;
    using StockTraderTransaq.InteractionRequests;
    using System;
    using System.Windows;

	/// <summary>
	/// Interaction logic for ModalDialogWindow.xaml
	/// </summary>
	public partial class ModalDialogWindow : ChildWindow
	{
		public static readonly DependencyProperty IsOkEnableProperty =
			DependencyProperty.Register(
				"IsOkEnable",
				typeof(bool),
				typeof(ModalDialogWindow),
				new PropertyMetadata(null));

		public bool IsOkEnable
		{
			get { return (bool)GetValue(IsOkEnableProperty); }
			set { SetValue(IsOkEnableProperty, value); }
		}

		public ModalDialogWindow()
		{
			InitializeComponent();
		}
	}
}
