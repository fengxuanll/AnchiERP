using Anchi.ERP.Common.Extensions;
using System.Collections.Generic;
using System.Configuration;

namespace Anchi.ERP.Common.Configuration
{
    public class AppSettingReader
    {
        private static IDictionary<string, object> Dict;
        static AppSettingReader()
        {
            Dict = new Dictionary<string, object>();
        }

        #region 获取字符串配置
        /// <summary>
        /// 获取字符串配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return string.Empty;

            if (!Dict.ContainsKey(key))
                Dict[key] = ConfigurationManager.AppSettings[key];

            return Dict[key].ExtToString();
        }
        #endregion
    }
}
