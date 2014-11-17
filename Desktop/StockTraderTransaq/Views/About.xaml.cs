namespace StockTraderTransaq
{
    using Microsoft.Practices.ServiceLocation;
    using System.ComponentModel.Composition;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Controls;

	/// <summary>
	/// Interaction logic for About.xaml
	/// </summary>
	[Export]
	public partial class About : UserControl
	{
		public About()
		{
			InitializeComponent();

            this.DataContext = ServiceLocator.Current.GetInstance<AboutViewModel>();
		}
	}
}
