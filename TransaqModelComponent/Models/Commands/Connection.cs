using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    /// <summary>
    /// connect
    /// </summary>
    public sealed class Connection : Command
    {
        [XmlElement(ElementName = "login")]
        public string UserId { get; set; }

        [XmlElement(ElementName = "password")]
        public string Password { get; set; }

        [XmlElement(ElementName = "host")]
        public string Host { get; set; }

        [XmlElement(ElementName = "port")]
        public int Port { get; set; }

        [XmlElement(ElementName = "logsdir")]
        public string PathForLogs { get; set; }

        [XmlElement(ElementName = "loglevel")]
        public int LogLevel { get; set; }

        [XmlElement(ElementName = "autopos")]
        public bool Autopos { get; set; }

        [XmlElement(ElementName = "rqdelay")]
        public int RqDelay { get; set; }

        public Connection() 
            : base(CommandNames.Connection)
        {
            LogLevel = 0;
            Autopos = false;
            RqDelay = 330;
        }
    }
}
