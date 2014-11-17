using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Текстовые сообщения
    /// </summary>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = EventNames.Messages)]
    public partial class Messages
    {
        /// <remarks/>
        [XmlElement("message")]
        public Message[] MessageItems { get; set; }
        
        /// <remarks/>
        [XmlType(AnonymousType = true)]
        public partial class Message
        {
            /// <summary>
            /// Дата и время
            /// </summary>
            [XmlElement("date")]
            public string Date { get; set; }
            
            /// <summary>
            /// Срочное: Y/N
            /// </summary>
            [XmlElement("urgent")]
            public string Urgent { get; set; }

            /// <summary>
            /// Отправитель
            /// </summary>
            [XmlElement("from")]
            public string From { get; set; }

            /// <summary>
            /// Текст сообщения
            /// </summary>
            [XmlElement("text")]
            public string Text { get; set; }
        }
    }
}
