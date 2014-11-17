using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Справочник режимов торгов
    /// </summary>
    [Serializable, XmlRoot(EventNames.Boards)]
    public sealed class Boards
    {
        [XmlElement("board")]
        public Board[] BoardItems { get; set; }

        public class Board
        {
            [XmlAttribute("id")]
            public string Id { get; set; }

            [XmlElement(ElementName = "name")]
            public string Name { get; set; }

            [XmlElement(ElementName = "market")]
            public int Market { get; set; }

            [XmlElement(ElementName = "type")]
            public int Type { get; set; }
        }
    }
}
