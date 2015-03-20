using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    [Serializable, XmlRoot(ModelNames.AllTrades)]
    public class AllTrades
    {
        [XmlElement("security")]
        public Security[] SecurityItems { get; set; }
    }
}
