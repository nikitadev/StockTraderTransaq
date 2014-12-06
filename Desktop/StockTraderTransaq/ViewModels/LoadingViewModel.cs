using StockTraderTransaq.InteractionRequests;
using System.ComponentModel.Composition;

namespace StockTraderTransaq
{
    [Export]
    public sealed class LoadingViewModel : Dialog
    {
        public bool IsVisibleProgress { get; set; }
    }
}
