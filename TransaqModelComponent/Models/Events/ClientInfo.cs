using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Клиентские счета
    /// </summary>
    [Serializable, XmlRoot(EventNames.ClientInfo)]
    public sealed class ClientInfo
    {
        /// <summary>
        /// CLIENT_ID
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("remove")]
        public bool Remove { get; set; }

        /// <summary>
        /// Тип клиента
        /// </summary>
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Валюта фондового портфеля клиента
        /// </summary>
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Дневной кредит
        /// </summary>
        [XmlElement(ElementName = "ml_intraday")]
        public double CreditIntraday { get; set; }

        /// <summary>
        /// овернайт кредит
        /// </summary>
        [XmlElement(ElementName = "ml_overnight")]
        public double CreditOvernight { get; set; }

        /// <summary>
        /// у.м. ограничительный
        /// </summary>
        [XmlElement(ElementName = "ml_restrict")]
        public double CreditRestrict { get; set; }

        /// <summary>
        /// у.м. требования
        /// </summary>
        [XmlElement(ElementName = "ml_call")]
        public double CreditCall { get; set; }

        /// <summary>
        /// у.м. закрытия
        /// </summary>
        [XmlElement(ElementName = "ml_close")]
        public double CreditClose { get; set; }
    }
}
