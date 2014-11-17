using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Доступные рынки
    /// </summary>
    [Serializable, XmlRoot(EventNames.Markets)]
    public sealed class Markets
    {
        [XmlElement("market")]
        public Market[] MarketItems { get; set; }

        public class Market
        {
            /// <summary>
            /// внутренний код рынка
            /// </summary>
            [XmlAttribute("id")]
            public string Id { get; set; }

            /// <summary>
            /// название рынка
            /// </summary>
            public string Name { get; set; }
        }
    }    
    
}
