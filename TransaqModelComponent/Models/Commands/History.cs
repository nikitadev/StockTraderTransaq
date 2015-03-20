using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    /// <summary>
    /// Выдать последние N свечей заданного периода, по заданному инструменту
    /// </summary>
    public sealed class History : Command
    {
        [XmlElement("security")]
        public Security Security { get; set; }

        [XmlAttribute("period")]
        public string Period { get; set; }

        [XmlAttribute("count")]
        public int CountCandles { get; set; }

        [XmlAttribute("reset")]
        public bool Reset { get; set; }

        public History() 
            : base (CommandNames.GetHistoryData)
        { }
    }
}
