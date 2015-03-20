using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    public class ConditionalOrder : Order
    {
        /// <summary>
        /// тип условия
        /// </summary>
        [XmlElement("cond_type")]
        public string ConditionalType { get; set; }

        /// <summary>
        /// значение
        /// </summary>
        [XmlElement("cond_value")]
        public int Value { get; set; }

        [XmlElement("validafter")]
        public int ValidAfter { get; set; }

        [XmlElement("validbefore")]
        public string ValidBefore { get; set; }

        public ConditionalOrder()
            : base(CommandNames.NewCondOrder)
        { }
    }
}
