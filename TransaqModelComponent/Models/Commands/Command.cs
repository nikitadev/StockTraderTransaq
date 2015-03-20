using System;
using System.Xml.Serialization;
using TransaqModelComponent.Models.Commands.Client;

namespace TransaqModelComponent.Models.Commands
{
    [XmlInclude(typeof(History))]
    [XmlInclude(typeof(Order))]
    [XmlInclude(typeof(ConditionalOrder))]
    [XmlInclude(typeof(StopOrder))]
    [XmlInclude(typeof(Connection))]
    [XmlInclude(typeof(MoveOrder))]
    [XmlInclude(typeof(ChangePassword))]
    [XmlInclude(typeof(CommandClient))]
    [XmlInclude(typeof(SubscribeTicks))]
    [XmlInclude(typeof(MaxBuySellClient))]
    [XmlInclude(typeof(LeverageControlClient))]
    [Serializable, XmlRoot(CommandNames.Name)]
    public class Command
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        public Command(string name)
        {
            Id = name;
        }

        protected Command() { }
    }
}
