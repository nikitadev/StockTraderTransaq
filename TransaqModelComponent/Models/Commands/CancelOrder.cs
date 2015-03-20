using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    /// <summary>
    /// cancelorder
    /// </summary>
    public class CancelOrder : Command
    {
        [XmlElement("transactionid")]
        public int TransactionId { get; set; }

        public CancelOrder() 
            : base(CommandNames.CancelOrder)
        { }
    }
}
