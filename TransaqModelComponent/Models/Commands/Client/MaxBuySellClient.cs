using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands.Client
{
    /// <summary>
    /// Команда для получения информации о максимально возможных объемах
    /// заявок на покупку и на продажу по перечисленным бумагам сектора T+
    /// фондового рынка для заданного клиента. В данной команде можно задавать
    /// только инструменты фондового рынка ММВБ.
    /// </summary>
    public class MaxBuySellClient : CommandClient
    {
        [XmlElement("security")]
        public Security[] Securities { get; set; }

        public static MaxBuySellClient Create(string client, Security[] securities)
        {
            var maxBuySellClient = (MaxBuySellClient)CommandClient.Create(CommandClientType.LeverageControl, client);

            maxBuySellClient.Securities = securities;

            return maxBuySellClient;
        }
    }
}
