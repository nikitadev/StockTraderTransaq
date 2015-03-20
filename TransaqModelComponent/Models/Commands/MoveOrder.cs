using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    public enum MoveFlag : int
    {
        // не менять количество
        None = 0,
        // изменить количество
        Change = 1,
        // при несовпадении количества с текущим – снять заявку
        Cancel = 2
    }

    /// <summary>
    /// Применима только для
    /// заявок с фиксированной ценой 
    /// по инструментам срочного рынка
    /// </summary>
    public class MoveOrder : Command
    {
        /// <summary>
        /// Идентификатор заменяемой заявки FORTS
        /// </summary>
        [XmlElement("transactionid")]
        public int TransactionId { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }

        /// <summary>
        /// Количество в лотах
        /// </summary>
        [XmlElement("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Cпособ замены
        /// </summary>
        [XmlElement("moveflag")]
        public MoveFlag MoveFlag { get; set; }

        public MoveOrder()
            : base(CommandNames.MoveOrder)
        {

        }
    }
}
