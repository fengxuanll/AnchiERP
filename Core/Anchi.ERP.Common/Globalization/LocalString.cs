using Anchi.ERP.Common.Domain;
using System;

namespace Anchi.ERP.Common.Globalization
{
    /// <summary>
    /// 本地化字符串对象
    /// </summary>
    [Serializable]
    public class LocalString : ValueObject<LocalString>
    {
        public LocalString()
        { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="languageCode">使用LanguageCodes的静态属性</param>
        /// <param name="value"></param>
        public LocalString(string languageCode, string value)
        {
            this.LanguageCode = languageCode;
            this.Value = value;
        }

        /// <summary>
        /// 返回或设置语言代码
        /// </summary>
        public string LanguageCode
        {
            set;
            get;
        }

        /// <summary>
        /// 返回或设置值
        /// </summary>
        public string Value
        {
            set;
            get;
        }

        /// <summary>
        /// Value是否是无效的。
        /// </summary>
        public bool InvalidValue
        {
            get
            {
                return string.IsNullOrEmpty(this.Value);
            }
        }
    }
}
