using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Состояние сервера
    /// </summary>
    /// <remarks>
    /// неверно указаны логин/пароль;
    /// сервер недоступен;
    /// нет прав на подключение к серверу;
    /// не удается открыть соединение;
    /// внутренних ошибках коннектора при подключении
    /// </remarks>
    [Serializable, XmlRoot(EventNames.ServerStatus)]
    public sealed class ServerStatus
    {
        /// <remarks>
        /// ID сервера
        /// </remarks>
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("connected")]
        public string StatusConnect { get; set; }

        [XmlAttribute("recover")]
        public string Recover { get; set; }

        /// <remarks>
        /// Имя таймзоны сервера
        /// </remarks>
        [XmlAttribute("server_tz")]
        public string ServerTimeZone { get; set; }
    }
}
