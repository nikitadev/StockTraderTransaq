using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    [XmlInclude(typeof(History))]
    [XmlInclude(typeof(Order))]
    [XmlInclude(typeof(Connection))]
    [Serializable, XmlRoot(CommandNames.Name)]
    public class Command
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        public Command(string name)
        {
            Id = name;
        }

        protected Command() { }
    }
}
