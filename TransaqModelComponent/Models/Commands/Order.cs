using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
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

    /// <summary>
    /// new_order
    /// </summary>
    public class Order : Command
    {
        [XmlElement("security")]
        public Security Security { get; set; }

        [XmlElement("client")]
        public string Client { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }

        /// <summary>
        /// Скрытое количество в лотах
        /// </summary>
        [XmlElement("hidden")]
        public int Hidden { get; set; }

        /// <summary>
        /// Количество в лотах
        /// </summary>
        [XmlElement("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// "В" - покупка, или "S" – продажа
        /// </summary>
        [XmlElement("buysell")]
        public OrderType Type { get; set; }

        // TODO: <bymarket/>

        /// <summary>
        /// Примечание
        /// </summary>
        [XmlElement("brokerref")]
        public string BrokerRef { get; set; }

        [XmlElement("unfilled")]
        public OrderUnfilled Unfilled { get; set; }

        // TODO: <usecredit/>
        // TODO: <nosplit/>

        /// <summary>
        /// Дата экспирации (только для ФОРТС)
        /// </summary>
        [XmlElement("expdate")]
        public DateTime ExpDate { get; set; }

        public Order() 
            : base(CommandNames.NewOrder)
        { }

        public Order(string name)
            : base(name)
        { }
    }
}
