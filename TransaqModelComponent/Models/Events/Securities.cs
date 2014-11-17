using System;
using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Events
{
    public enum SecurityType
    {
        // Торгуемые инструменты
        SHARE, // акции
        BOND, // облигации корпоративные
        FUT, // фьючерсы FORTS
        OPT, // опционы
        GKO, // гос. бумаги
        FOB, // фьючерсы ММВБ

        // Неторгуемые (все кроме IDX приходят только с зарубежных площадок)
        IDX, // индексы
        QUOTES, // котировки (прочие)
        CURRENCY, // валютные пары
        ADR, // АДР
        NYSE, // данные с NYSE
        METAL, // металлы
        OIL, // нефтянка

        ERROR, // в случае внутренней ошибки (не должно появляться)
    }

    /// <summary>
    /// Список инструментов
    /// </summary>
    [Serializable, XmlRoot(EventNames.Securities)]
    public sealed class Securities
    {
        [XmlElement("security")]
        public Security[] SecurityItems { get; set; }

        public class Security
        {
            /// <summary>
            /// внутренний код
            /// </summary>
            /// <remarks>
            /// действителен в течение сессии
            /// </remarks>
            [XmlAttribute("secid")]
            public int Id { get; set; }

            [XmlAttribute("active")]
            public bool Active { get; set; }

            /// <summary>
            /// Код инструмента
            /// </summary>
            [XmlElement("seccode")]
            public string Code { get; set; }

            /// <summary>
            /// Идентификатор режима торгов по умолчанию
            /// </summary>
            [XmlElement("board")]
            public string BoardId { get; set; }

            /// <summary>
            /// Наименование бумаги
            /// </summary>
            [XmlElement("shortname")]
            public string ShortName { get; set; }

            /// <summary>
            /// Идентификатор рынка
            /// </summary>
            [XmlElement("market")]
            public string MarketId { get; set; }

            /// <summary>
            /// Количество десятичных знаков в цене
            /// </summary>
            [XmlElement("decimals")]
            public int Decimals { get; set; }

            /// <summary>
            /// Шаг цены
            /// </summary>
            [XmlElement("minstep")]
            public double MinStep { get; set; }

            /// <summary>
            /// Размер лота
            /// </summary>
            [XmlElement("lotsize")]
            public int LotSize { get; set; }

            /// <summary>
            /// Стоимость пункта цены
            /// </summary>
            /// <remarks>
            /// Стоимость_шага_цены = point_cost * minstep * 10^decimals
            /// Для перевода значения в рубли необходимо его разделить на 100
            /// </remarks>
            [XmlElement("point_cost")]
            public double PointCost { get; set; }
            
            /// <summary>
            /// Стоимость пункта цены
            /// </summary>
            [XmlElement("opmask")]
            public Opmask OpmaskItems { get; set; }
            
            /// <summary>
            /// Тип бумаги
            /// </summary>
            [XmlElement("sectype")]
            public SecurityType Type { get; set; }

            /// <summary>
            /// имя таймзоны инструмента
            /// </summary>
            /// <remarks>
            /// содержит секцию CDATA
            /// </remarks>
            /// <example>
            /// "Russian Standard Time", "USA=Eastern Standard Time"
            /// </example>
            [XmlElement("sec_tz")]
            public string TimeZone { get; set; }

            /// <remarks>
            /// Для неторгуемых бумаг не будут возвращаться поля minstep, lotsize и opmask.
            /// </remarks>
            [XmlType(AnonymousType = true)]
            [XmlRoot(Namespace = "", IsNullable = false)]
            public sealed class Opmask
            {
                /// <remarks>
                /// "yes" указывает на возможность использования свойства
                /// "Использовать кредит" в диалоге ввода заявки. 
                /// Для фьючерсов, например, "no" (всегда)
                /// </remarks>
                [XmlAttribute("usecredit")]
                public string UseCredit { get; set; }
                
                /// <remarks/>
                [XmlAttribute("bymarket")]
                public string ByMarket { get; set; }
                
                [XmlElement("nosplit")]
                public string NoSplit { get; set; }

                [XmlElement("immorcancel")]
                public string ImmorCancel { get; set; }

                [XmlElement("cancelbalance")]
                public string CancelBalance { get; set; }
            }
        }
    }
}
