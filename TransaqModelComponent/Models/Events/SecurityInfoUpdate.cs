using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Обновление информации по инструменту
    /// </summary>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = EventNames.SecurityInfoUpdate)]
    public sealed class SecurityInfoUpdate
    {
        /// <summary>
        /// идентификатор бумаги
        /// </summary>
        /// <remarks/>
        [XmlElement("secid")]
        public int SecurityId { get; set; }

        /// <summary>
        /// Внутренний код рынка
        /// </summary>
        /// <remarks/>
        [XmlElement("market")]
        public int MarketId { get; set; }

        /// <summary>
        /// Код инструмента
        /// </summary>
        /// <remarks/>
        [XmlElement("seccode")]
        public string SecurityCode { get; set; }

        /// <summary>
        /// минимальная цена
        /// </summary>
        /// <remarks>
        /// только FORTS
        /// </remarks>
        [XmlElement("minprice")]
        public double MinPrice { get; set; }

        /// <summary>
        /// максимальная цена
        /// </summary>
        /// <remarks>
        /// только FORTS
        /// </remarks>
        [XmlElement("maxprice")]
        public double MaxPrice { get; set; }

        /// <summary>
        /// ГО покупателя
        /// </summary>
        /// <remarks>
        /// фьючерсы FORTS
        /// </remarks>
        [XmlElement("buy_deposit")]
        public double BuyDeposit { get; set; }

        /// <summary>
        /// ГО продавца
        /// </summary>
        /// <remarks>
        /// фьючерсы FORTS
        /// </remarks>
        [XmlElement("sell_deposit")]
        public double SellDeposit { get; set; }

        /// <summary>
        /// ГО покрытой позиции
        /// </summary>
        /// <remarks>
        /// опционы FORTS
        /// </remarks>
        [XmlElement("bgo_c")]
        public double BgoCovered { get; set; }

        /// <summary>
        /// ГО непокрытой позиции
        /// </summary>
        /// <remarks>
        /// опционы FORTS
        /// </remarks>
        [XmlElement("bgo_nc")]
        public double BgoNotCovered { get; set; }

                /// <remarks/>
        [XmlElement("bgo_buy")]
        public string BgoBuy { get; set; }
 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks/>
        [XmlElement("point_cost")]
        public string PointCost { get; set; }
    }
}
