using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    public class CancelOrder : Command
    {
        [XmlElement("transactionid")]
        public int TransactionId { get; set; }

        public CancelOrder() 
            : base(CommandNames.CancelOrder)
        { }
    }
}
