using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    /// <summary>
    /// Информация по инструменту
    /// </summary>
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = EventNames.SecurityInfo)]
    public class SecurityInfo
    {
        /// <summary>
        /// идентификатор бумаги
        /// </summary>
        /// <remarks/>
        [XmlAttribute("secid")]
        public int SecurityId { get; set; }

        /// <summary>
        /// полное наименование инструмента
        /// </summary>
        /// <remarks/>
        [XmlElement("secname")]
        public string SecurityName { get; set; }
        
        /// <summary>
        /// Код инструмента
        /// </summary>
        /// <remarks/>
        [XmlElement("seccode")]
        public string SecurityCode { get; set; }
        
        /// <summary>
        /// Внутренний код рынка
        /// </summary>
        /// <remarks/>
        [XmlElement("market")]
        public int MarketId { get; set; }
        
        /// <summary>
        /// единицы измерения цены
        /// </summary>
        /// <remarks/>
        [XmlElement("pname")]
        public string PointName { get; set; }
        
        /// <summary>
        /// дата погашения
        /// </summary>
        /// <remarks/>
        [XmlElement("mat_date")]
        public DateTime RepaymentDate { get; set; }
        
        /// <summary>
        /// цена последнего клиринга
        /// </summary>
        /// <remarks>
        /// только FORTS
        /// </remarks>
        [XmlElement("clearing_price")]
        public double ClearingPrice { get; set; }
        
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
        
        /// <summary>
        /// текущий НКД
        /// </summary>
        /// <remarks/>
        [XmlElement("accruedint")]
        public double Accruedint { get; set; }
        
        /// <summary>
        /// размер купона
        /// </summary>
        /// <remarks/>
        [XmlElement("coupon_value")]
        public double CouponValue { get; set; }
        
        /// <summary>
        /// дата погашения купона
        /// </summary>
        /// <remarks/>
        [XmlElement("coupon_date")]
        public DateTime CouponDate { get; set; }
        
        /// <summary>
        /// период выплаты купона, дни
        /// </summary>
        /// <remarks/>
        [XmlElement("coupon_period")]
        public int CouponPeriod { get; set; }
        
        /// <summary>
        /// номинал облигации или акции
        /// </summary>
        /// <remarks/>
        [XmlElement("facevalue")]
        public double FaceValue { get; set; }
        
        /// <summary>
        /// тип опциона Call(C)/Put(P)
        /// </summary>
        /// <remarks/>
        [XmlElement("put_call")]
        public string PutCall { get; set; }
        
        /// <summary>
        /// маржинальный(M)/премия(P)
        /// </summary>
        /// <remarks/>
        [XmlElement("opt_type")]
        public string OPTType { get; set; }
        
        /// <summary>
        /// количество базового актива
        /// </summary>
        /// <remarks>
        /// FORTS
        /// </remarks>
        [XmlElement("lot_volume")]
        public int LotVolume { get; set; }
    }
}
