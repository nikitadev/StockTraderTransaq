using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models
{
    [XmlInclude(typeof(SecurityEx))]
    [Serializable, XmlRoot(ModelNames.Security)]
    public class Security
    {
        /// <summary>
        /// Код инструмента
        /// </summary>
        [XmlElement("seccode")]
        public string Code { get; set; }

        /// <summary>
        /// Идентификатор режима торгов по умолчанию
        /// </summary>
        [XmlElement("board")]
        public string BoardId { get; set; }
    }
}
