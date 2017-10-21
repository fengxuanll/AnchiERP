using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Anchi.ERP.Common.Globalization
{
    public class GlobalString
    {
        public GlobalString()
        {
            this.DefaultLanguage = "en";
        }

        public GlobalString(string defaultLanguage)
        {
            this.DefaultLanguage = defaultLanguage;
        }

        /// <summary>
        /// 此全球化字符串包含的本地化字符串对象。
        /// </summary>
        protected List<LocalString> localList = new List<LocalString>();
        public List<LocalString> LocalStrings
        {
            get
            {
                return this.localList;
            }
            set
            {
                if (value == null)
                {
                    value = new List<LocalString>();
                }
                LocalStringDict.Clear();
                this.localList = value;
                foreach (var ll in value)
                {
                    LocalStringDict[ll.LanguageCode] = ll;
                }
            }
        }

        Dictionary<string, LocalString> _localStringDict = null;
        protected Dictionary<string, LocalString> LocalStringDict
        {
            get
            {
                if (this._localStringDict == null)
                    this._localStringDict = new Dictionary<string, LocalString>(StringComparer.InvariantCultureIgnoreCase);
                return this._localStringDict;
            }
        }

        /// <summary>
        /// 默认语言。每次使用GetValue方法获取Value时，如果指定的Language没有对应的Value，则尝试用默认语言获取。
        /// </summary>
        public string DefaultLanguage
        {
            get;
            set;
        }

        /// <summary>
        /// 添加或更新本地化字符串
        /// </summary>
        /// <param name="locals">本地字符串</param>
        public void AddOrUpdate(params LocalString[] locals)
        {
            if (locals == null || locals.Length == 0)
                return;
            foreach (var l in locals)
            {
                if (l == null)
                    continue;
                if (l.LanguageCode.Length < 2)
                {
                    throw new ArgumentException("格式错误，LanguageCode必须是languagecode2格式", "locals");
                }
                //精确匹配：要求<languagecode2>-<country/regioncode2>完全一致
                if (this.LocalStringDict.ContainsKey(l.LanguageCode))
                {
                    LocalString ls = this.LocalStringDict[l.LanguageCode];
                    ls.Value = l.Value;
                }
                else
                {
                    this.Add(l);
                }
            }
        }

        /// <summary>
        /// 更新已经存在的本地化字符串。
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="value"></param>
        /// <returns>已经存在对应的语言返回true，否则返回false。</returns>
        public bool Update(string languageCode, string value)
        {
            //精确匹配：要求<languagecode2>-<country/regioncode2>完全一致
            if (this.LocalStringDict.ContainsKey(languageCode))
            {
                LocalString ls = this.LocalStringDict[languageCode];
                ls.Value = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取对应语言的字符串
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public string GetValue(string languageCode, bool useDefaultLanguage = true)
        {
            LocalString ls = this.Get(languageCode, useDefaultLanguage);
            return ls?.Value;
        }

        /// <summary>
        /// 用CurrentUICulture作为目标语言
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            return this.GetValue(Thread.CurrentThread.CurrentUICulture.Name);
        }

        /// <summary>
        /// 获取CultureInfo对应的文本
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public string GetValue(CultureInfo culture, bool useDefaultLanguage = true)
        {
            return this.GetValue(culture.Name, useDefaultLanguage);
        }

        #region 私有

        private void Add(LocalString ls)
        {
            this.localList.Add(ls);
            this.LocalStringDict[ls.LanguageCode] = ls;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageCode">
        /// <![CDATA[<languagecode2>-<country/regioncode2>]]>
        /// </param>
        /// <param name="useDefaultLanguage">
        /// 是否使用默认语言
        /// </param>
        /// <returns></returns>
        protected LocalString Get(string languageCode, bool useDefaultLanguage)
        {
            LocalString ls = this.Get(languageCode);
            if ((ls == null || ls.InvalidValue) && useDefaultLanguage)
                return this.Get(this.DefaultLanguage);
            return ls;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageCode">
        /// <![CDATA[<languagecode2>-<country/regioncode2>]]>
        /// </param>
        /// <returns></returns>
        protected LocalString Get(string languageCode)
        {
            #region 参数校验
            if (languageCode == null)
                return null;
            if (languageCode.Length < 2)
            {
                throw new ArgumentException("格式错误，必须是languagecode2格式", "languageCode");
            }
            #endregion

            //精确匹配：要求<languagecode2>-<country/regioncode2>完全一致
            if (this.LocalStringDict.ContainsKey(languageCode))
            {
                return this.LocalStringDict[languageCode];
            }
            //部分匹配：要求已经存在<languagecode2>的文本
            string languagecode2 = languageCode.Substring(0, 2);
            if (this.LocalStringDict.ContainsKey(languagecode2))
            {
                return this.LocalStringDict[languagecode2];
            }
            //部分匹配：随便取一个<languagecode2>相同的文本
            foreach (var item in this.LocalStrings)
            {
                if (item.LanguageCode.StartsWith(languagecode2, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.AddOrUpdate(new LocalString(languagecode2, item.Value));//添加<languagecode2>
                    return item;
                }
            }
            return null;
        }
        #endregion
    }
}
