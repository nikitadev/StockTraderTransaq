using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Информация о доступных периодах свечей
    /// </summary>
    [Serializable, XmlRoot(Namespace = "", IsNullable = false, ElementName = EventNames.Candlekinds)]
    public sealed class Candlekinds
    {
        [XmlElement("kind")]
        public Kind[] KindItems { get; set; }

        public class Kind
        {
            /// <summary>
            /// идентификатор периода
            /// </summary>
            [XmlElement(ElementName = "id")]
            public int Id { get; set; }

            /// <summary>
            /// количество секунд в периоде
            /// </summary>
            [XmlElement(ElementName = "period")]
            public string Period { get; set; }

            /// <summary>
            /// наименование периода
            /// </summary>
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
        }
    }
}
