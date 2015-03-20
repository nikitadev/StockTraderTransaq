using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands.Client
{
    /// <summary>
    /// Запрос на получении информации по максимальным значениям покупки и
    /// продажи по перечисленным клиентам для заданного клиента. Так же будет
    /// возвращено плановое и фактическое плечо для заданного клиента.
    /// </summary>
    public class LeverageControlClient : CommandClient
    {
        [XmlElement("security")]
        public Security[] Securities { get; set; }

        public static LeverageControlClient Create(string client, Security[] securities)
        {
            var leverageControl = (LeverageControlClient)CommandClient.Create(CommandClientType.LeverageControl, client);

            leverageControl.Securities = securities;

            return leverageControl;
        }
    }
}
