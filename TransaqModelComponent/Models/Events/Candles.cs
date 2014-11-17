using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <remarks>
    /// Исторические данные
    /// </remarks>
    [XmlType(AnonymousType = true)]
    [Serializable, XmlRoot(Namespace = "", IsNullable = false, ElementName = EventNames.Candles)]
    public partial class Candles
    {
        /// <remarks/>
        [XmlElement("candle")]
        public Candle[] CandleItems { get; set; }
        
        /// <remarks/>
        [XmlAttribute("secid")]
        public int SecId { get; set; }
        
        /// <remarks>
        /// Идентификатор периода
        /// </remarks>
        [XmlAttribute("period")]
        public int PeriodId { get; set; }

        /// <remarks>
        /// Показывает, осталась ли еще история
        /// </remarks>
        [XmlAttribute("status")]
        public int Status { get; set; }
        
        /// <remarks>
        /// Идентификатор режима торгов
        /// </remarks>
        [XmlAttribute("board")]
        public string BoardId { get; set; }
        
        /// <remarks>
        /// Код инструмента
        /// </remarks>
        [XmlAttribute("seccode")]
        public string SecCode { get; set; }

        /// <remarks/>
        [XmlTypeAttribute(AnonymousType = true)]
        public partial class Candle
        {
            /// <remarks/>
            [XmlAttribute("date")]
            public DateTime Date { get; set; }
            
            /// <remarks/>
            [XmlAttribute("open")]
            public double Open { get; set; }
            
            /// <remarks/>
            [XmlAttribute("high")]
            public double High { get; set; }

            /// <remarks/>
            [XmlAttribute("low")]
            public double Low { get; set; }
            
            /// <remarks/>
            [XmlAttribute("close")]
            public double Close { get; set; }
            
            /// <remarks/>
            [XmlAttribute("volume")]
            public int Volume { get; set; }
            
            /// <remarks>
            /// Передается только для фьючерсов и опционов.
            /// </remarks>
            [XmlAttribute("oi")]
            public int OpenInterest { get; set; }
        }
    }
}
