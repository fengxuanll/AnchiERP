using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Anchi.ERP.Common.Globalization
{
    [Serializable]
    [DataContract]
    public sealed partial class Currency
    {
        private static Currency[] allCurrencies = null;

        private Currency(int id, CurrencyCode code, string displayName, string symbol)
        {
            this.ID = id;
            this.Code = code;
            this.DisplayName = displayName;
            this.Symbol = symbol;
        }

        /// <summary>
        /// Numeric code
        /// </summary>
        [DataMember]
        public int ID
        {
            get;
            private set;
        }

        /// <summary>
        /// Alphabetic code, 3-letter
        /// </summary>
        [DataMember]
        public CurrencyCode Code
        {
            get;
            private set;
        }

        //public CurrencyCode CodeType
        //{
        //    get
        //    {
        //        return Code.ToEnum<CurrencyCode>();
        //    }
        //}

        /// <summary>
        /// Localized Currency Name
        /// </summary>
        [DataMember]
        public string DisplayName
        {
            // TODO: localized
            get;
            private set;
        }

        /// <summary>
        /// The currency name, consisting of the language, country/region.
        /// </summary>
        [DataMember]
        public string NativeName
        {
            get
            {
                // TODO: return native name rather than localized display name
                return DisplayName;
            }
        }

        /// <summary>
        /// Symbol
        /// </summary>
        [DataMember]
        public string Symbol
        {
            get;
            private set;
        }

        ///// <summary>
        ///// Retrieves a cached, read-only instance of a currency using the specified currency code.
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns>If not found, returns null.</returns>
        //public static Currency GetCurrency(string code)
        //{
        //    return allCurrencies.FirstOrDefault(c => StringComparer.OrdinalIgnoreCase.Compare(c.Code, code) == 0);
        //}

        /// <summary>
        /// Retrieves a cached, read-only instance of a currency using the specified currency code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>If not found, returns null.</returns>
        public static Currency GetCurrency(CurrencyCode code)
        {
            //return GetCurrency(code.ToString());
            return allCurrencies.FirstOrDefault(c => c.Code == code);
        }

        /// <summary>
        /// Retrieves a cached, read-only instance of a currency using the specified currency identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Currency GetCurrency(int id)
        {
            return allCurrencies.FirstOrDefault(c => c.ID == id);
        }

        /// <summary>
        /// Retrieves all the well known currency instances.
        /// </summary>
        /// <returns></returns>
        public static Currency[] GetAllCurrencies()
        {
            return allCurrencies;
        }

        /// <summary>
        /// 采用“四舍六入五成双”圆整指定金额为两位小数。
        /// </summary>
        /// <remarks>
        /// 此方法使用“就近舍入”或“银行家舍入”算法，通常称为“四舍六入五成双“。
        /// 此算法遵循是IEEE 标准 754，具体来说就是：“四舍六入五考虑，五后非零就进一，五后皆零看奇偶，五前为偶应舍去，五前为奇要进一。”
        /// </remarks>
        /// <param name="money"></param>
        /// <returns></returns>
        public static decimal Round(decimal money)
        {
            return decimal.Round(money, 2, MidpointRounding.ToEven);
        }
    }
}
