using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    public struct OrderType 
    { 
        public const string Buy = "B"; 
        public const string Sell = "S";
    }

    public struct OrderUnfilled
    {
        public const string PIQ = "PutInQueue";
        public const string IOC = "ImmOrCancel";
        public const string CB = "CancelBalance";
    }

    public class Order : Command
    {
        [XmlElement("client")]
        public string Client { get; set; }

        [XmlElement("secid")]
        public string SecId { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("buysell")]
        public OrderType Type { get; set; }

        [XmlElement("unfilled")]
        public OrderUnfilled Unfilled { get; set; }

        public Order() 
            : base(CommandNames.NewOrder)
        { }
    }
}
