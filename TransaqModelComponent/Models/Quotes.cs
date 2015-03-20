using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    [Serializable, XmlRoot(ModelNames.Quotes)]
    public class Quotes
    {
        [XmlElement("security")]
        public Security[] SecurityItems { get; set; }
    }
}
