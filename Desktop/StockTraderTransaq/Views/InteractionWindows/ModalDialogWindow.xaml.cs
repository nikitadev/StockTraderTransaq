namespace StockTraderTransaq.InteractionWindowViews
{
    using StockTraderTransaq.ControlLibrary;
    using StockTraderTransaq.Infrastructure;
    using StockTraderTransaq.InteractionRequests;
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;

	/// <summary>
	/// Interaction logic for ModalDialogWindow.xaml
	/// </summary>
    [Export]
	public partial class ModalDialogWindow : ChildWindow
	{
		public ModalDialogWindow()
		{
			InitializeComponent();
		}
	}
}
