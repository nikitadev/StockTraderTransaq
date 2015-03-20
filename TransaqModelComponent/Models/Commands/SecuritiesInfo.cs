using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    public class SecuritiesInfo : Command
    {
        [XmlElement("security")]
        public Security Security { get; set; }

        public SecuritiesInfo()
            : base(CommandNames.GetSecuritiesInfo)
        {

        }
    }
}
