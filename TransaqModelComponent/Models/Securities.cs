using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    /// <summary>
    /// Список инструментов
    /// </summary>
    [Serializable, XmlRoot(EventNames.Securities)]
    public sealed class Securities
    {
        [XmlElement("security")]
        public SecurityEx[] SecurityItems { get; set; }
    }
}
