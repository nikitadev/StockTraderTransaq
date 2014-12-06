using StockTraderTransaq.InteractionRequests;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;

namespace StockTraderTransaq
{
    [Export]
    public class LoginViewModel : Dialog
    {
        private string login, password;

        [Required(ErrorMessageResourceName = "RequiredLogin", ErrorMessageResourceType = typeof(StockTraderTransaq.Properties.Resources))]
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                SetProperty(ref login, value);
            }
        }

        [Required(ErrorMessageResourceName = "RequiredPassword", ErrorMessageResourceType = typeof(StockTraderTransaq.Properties.Resources))]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetProperty(ref password, value);
            }
        }
    }
}
