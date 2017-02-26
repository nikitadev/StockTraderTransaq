namespace StockTraderTransaq.InteractionRequests
{
	using System;
	using System.Windows.Media;
	using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
    using Microsoft.Practices.Prism.Mvvm;
	using StockTraderTransaq.Infrastructure;

    public class Dialog : ValidationBindableBase, IConfirmation
	{
        public string Title { get; set; }

        public bool Confirmed { get; set; }

        public object Content { get; set; }

		public ImageSource Image { get; set; }

		public object OkContent { get; set; }

		public object CancelContent { get; set; }
    }
}
