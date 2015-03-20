using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    /// <summary>
    /// Подписаться или отписаться на получение 
    /// котировок, сделок и глубины рынка (стакана) 
    /// по одному или нескольким инструментам.
    /// </summary>
    public class Subscribe : Command
    {
        [XmlElement("alltrades")]
        public AllTrades Trades { get; set; }

        [XmlElement("quotations")]
        public Quotations Quotations { get; set; }

        [XmlElement("quotes")]
        public Quotes Quotes { get; set; }

        private Subscribe()
        {

        }

        public Subscribe Create(bool unsubscribe, AllTrades trades, Quotations quotations, Quotes quotes)
        {
            var model = new Subscribe 
            { 
                Id = (unsubscribe) ? CommandNames.Unsubscribe : CommandNames.Subscribe,
                Trades = trades,
                Quotations = quotations,
                Quotes = quotes
            };

            return model;
        }
    }
}