using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    public class StopOrder : Order
    {
        /// <summary>
        /// Номер связной заявки
        /// </summary>
        [XmlElement("linkedorderno")]
        public int LinkedOrderNumber { get; set; }

        /// <summary>
        /// Заявка действительно до
        /// </summary>
        [XmlElement("validfor")]
        public string ValidFor { get; set; }

        [XmlElement("stoploss")]
        public Stoploss Stoploss { get; set; }

        [XmlElement("takeprofit")]
        public Takeprofit Takeprofit { get; set; }
    }
}
