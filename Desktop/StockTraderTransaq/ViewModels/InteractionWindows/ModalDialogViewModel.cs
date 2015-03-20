using StockTraderTransaq.Infrastructure;

namespace StockTraderTransaq
{
    public abstract class ModalDialogViewModel : ValidationBindableBase
    {
        private string okContent;

        public string OkContent 
        { 
            get 
            {
                return okContent;
            }
            set
            {
                SetProperty(ref okContent, value);
            }
        }

        protected ModalDialogViewModel()
            : base()
        {
            OkContent = StockTraderTransaq.Properties.Resources.Ok;
        }
    }
}
