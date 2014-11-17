using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    public sealed class History : Command
    {
        [XmlAttribute("period")]
        public string Period { get; set; }

        [XmlAttribute("count")]
        public int CountCandles { get; set; }

        [XmlAttribute("reset")]
        public bool Reset { get; set; }

        [XmlAttribute("secid")]
        public string SecId { get; set; }

        public History() 
            : base (CommandNames.GetHistoryData)
        { }
    }
}
