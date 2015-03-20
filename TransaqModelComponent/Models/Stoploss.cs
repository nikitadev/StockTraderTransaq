using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    public class Stoploss
    {
        /// <summary>
        /// Цена активации
        /// </summary>
        [XmlElement("activationprice")]
        public double ActivationPrice { get; set; }

        /// <summary>
        /// Цена заявки
        /// </summary>
        [XmlElement("orderprice")]
        public double OrderPrice { get; set; }

        /// <summary>
        /// Выставить заявку по рынку
        /// </summary>
        [XmlElement("bymarket")]
        public bool ByMarket { get; set; }

        /// <summary>
        /// Объем
        /// </summary>
        [XmlElement("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Использование кредита
        /// </summary>
        [XmlElement("usecredit")]
        public bool UseCredit { get; set; }

        /// <summary>
        /// Защитное время
        /// </summary>
        [XmlElement("guardtime")]
        public DateTime GuardTime { get; set; }

        /// <summary>
        /// Примечание брокера
        /// </summary>
        [XmlElement("brokerref")]
        public string BrokerRef { get; set; }
    }
}
