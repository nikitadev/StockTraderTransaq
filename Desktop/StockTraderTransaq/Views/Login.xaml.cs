using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;

namespace StockTraderTransaq
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    [Export]
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        [Import]
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "Needs to be a property to be composed by MEF")]
        public LoginViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
