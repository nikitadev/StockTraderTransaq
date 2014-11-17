using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    [XmlRoot(IsNullable = true, Namespace = "", ElementName = "result")]
    public sealed class Result
    {
        [XmlAttribute("success")]
        public bool Success { get; set; }

        [XmlElement(ElementName = "message")]
        public string Message { get; set; }

        [XmlElement(ElementName = "transactionid")]
        public int TransactionId { get; set; }
    }
}
