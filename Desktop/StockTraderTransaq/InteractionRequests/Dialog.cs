namespace StockTraderTransaq.InteractionRequests
{
	using System;
	using System.Windows.Media;
	using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

    public class Dialog : IConfirmation
	{
		public Guid Id { get; set; }

		public ImageSource Image { get; set; }

		public object OkContent { get; set; }

		public object CancelContent { get; set; }

        public bool Confirmed { get; set; }
        
        public object Content { get; set; }
        
        public string Title { get; set; }
    }
}
