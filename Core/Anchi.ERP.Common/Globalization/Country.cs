using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Anchi.ERP.Common.Globalization
{
    /// <summary>
    /// Provides information about country or region name and code.
    /// </summary>
    /// <remarks>
    /// Conforms to ISO 3166 http://www.iso.org/iso/english_country_names_and_code_elements.
    /// </remarks>
    [DataContract, Serializable]
    public sealed partial class Country
    {
        private static Country[] allCountries = null;

        private Country(CountryCode code)
        {
            this.Code = code;
        }

        /// <summary>
        /// 2-letter alphabetic code
        /// </summary>
        [DataMember]
        public CountryCode Code
        {
            get;
            private set;
        }

        //[DataMember]
        //public CountryCode CodeType
        //{
        //    get
        //    {
        //        return Code.ToEnum<CountryCode>();
        //    }
        //}

        /// <summary>
        /// 简体中文名称
        /// </summary>
        [DataMember]
        public string ChineseName
        {
            get
            {
                return GetSafeName("zh-hans");
            }
        }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName
        {
            get
            {
                return GetSafeName("en");
            }
        }

        /// <summary>
        /// 本地化的显示名称。
        /// </summary>
        /// <remarks>
        /// 根据当前线程的区域文化本地化。
        /// </remarks>
        public string DisplayName
        {
            get
            {
                return GetSafeName();
            }
        }

        string GetSafeName(string culture = null)
        {
            string name;
            if (string.IsNullOrWhiteSpace(culture))
            {
                name = CountryDisplayNames.ResourceManager.GetString(this.Code.ToString());
            }
            else
            {
                CultureInfo ci = CultureInfo.GetCultureInfo(culture);
                name = CountryDisplayNames.ResourceManager.GetString(this.Code.ToString(), ci);
            }
            if (String.IsNullOrEmpty(name))
            {
                return this.Code.ToString();
            }
            return name;
        }

        /// <summary>
        /// Checks if the specified country <paramref name="code"/> exists.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool CountryExists(string code)
        {
            return GetCountry(code) != null;
        }

        /// <summary>
        /// Returns the country with the specified <paramref name="code"/>.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>If not found, null, else the <see cref="Country"/> object.</returns>
        public static Country GetCountry(string code)
        {
            CountryCode cc = (CountryCode)Enum.Parse(typeof(CountryCode), code);
            return GetCountry(cc);
        }

        /// <summary>
        /// Returns the country with the specified <paramref name="code"/>.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>If not found, null, else the <see cref="Country"/> object.</returns>
        public static Country GetCountry(CountryCode code)
        {
            return allCountries.FirstOrDefault(c => c.Code == code);
        }

        /// <summary>
        /// Returns all the defined countries in the ascending order of <see cref="Code"/> property.
        /// </summary>
        /// <returns></returns>
        public static Country[] GetAllCountries()
        {
            return allCountries;
        }
    }
}
