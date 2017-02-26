namespace StockTraderTransaq.InteractionWindowViews
{
	using MahApps.Metro.SimpleChildWindow;
	using System.ComponentModel.Composition;

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
