using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Параметры инструмента в режиме торгов
    /// </summary>
    [XmlType(AnonymousType = true)]
    [Serializable, XmlRoot(Namespace = "", IsNullable = false, ElementName = EventNames.Pits)]
    public sealed class Pits
    {
        [XmlElement("pit")]
        public Pit[] PitItems { get; set; }
        
        public sealed class Pit
        {
            /// <summary>
            /// Код инструмента
            /// </summary>
            /// <remarks/>
            [XmlAttribute("seccode")]
            public string SecurityCode { get; set; }

            /// <remarks>
            /// Идентификатор режима торгов
            /// </remarks>
            [XmlAttribute("board")]
            public string BoardId { get; set; }

            /// <summary>
            /// Внутренний код рынка
            /// </summary>
            /// <remarks/>
            [XmlElement("market")]
            public int MarketId { get; set; }
        }
    }
}
