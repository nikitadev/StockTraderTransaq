using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    public class Takeprofit
    {
        /// <summary>
        /// Цена активации
        /// </summary>
        [XmlElement("activationprice")]
        public double ActivationPrice { get; set; }

        /// <summary>
        /// Выставить заявку по рынку
        /// </summary>
        [XmlElement("bymarket")]
        public string ByMarket { get; set; }

        /// <summary>
        /// Объем
        /// </summary>
        [XmlElement("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Использование кредита
        /// </summary>
        [XmlElement("usecredit")]
        public string UseCredit { get; set; }

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

        /// <summary>
        /// Коррекция
        /// </summary>
        [XmlElement("correction")]
        public double Correction { get; set; }

        /// <summary>
        /// Защитный спрэд
        /// </summary>
        [XmlElement("spread")]
        public int Spread { get; set; }
    }
}
