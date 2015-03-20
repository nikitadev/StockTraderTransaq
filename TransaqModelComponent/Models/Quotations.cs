using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    [Serializable, XmlRoot(ModelNames.Quotations)]
    public class Quotations
    {
        [XmlElement("security")]
        public Security[] SecurityItems { get; set; }
    }
}
