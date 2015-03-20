using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    /// <summary>
    /// Подписка на тиковые данные
    /// </summary>
    public class SubscribeTicks : Command
    {
        [XmlElement("security")]
        public Security Security { get; set; }

        /// <summary>
        /// c "true" будут отдаваться
        /// только сделки нормального периода торгов
        /// </summary>
        [XmlElement("filter")]
        public bool Filter { get; set; }
    }
}
