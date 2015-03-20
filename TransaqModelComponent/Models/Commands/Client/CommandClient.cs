using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands.Client
{
    /// <summary>
    /// Базовый тип для возвращения информации по клиенту
    /// </summary>
    public class CommandClient : Command
    {
        [XmlAttribute("client")]
        public string Client { get; set; }

        private CommandClient(string name)
            : base(name)
        {

        }

        protected CommandClient()
        {

        }

        public static CommandClient Create(CommandClientType type, string client)
        {
            if (type == null)
                return null;

            CommandClient command = null;

            switch (type)
            {
                case CommandClientType.FortsPosition:
                    command = new CommandClient(CommandNames.GetFortsPosition);
                    break;
                case CommandClientType.ClientLimits:
                    command = new CommandClient(CommandNames.GetClientLimits);
                    break;
                case CommandClientType.LeverageControl:
                    command = new CommandClient(CommandNames.GetLeverageControl);
                    break;
                case CommandClientType.Portfolio:
                    command = new CommandClient(CommandNames.GetPortfolio);
                    break;
                case CommandClientType.PortfolioMCT:
                    command = new CommandClient(CommandNames.GetPortfolioMct);
                    break;
                case CommandClientType.MaxBuySell:
                    command = new CommandClient(CommandNames.GetMaxBuySellTPlus);
                    break;
            }

            command.Client = client;

            return command;
        }
    }
}
