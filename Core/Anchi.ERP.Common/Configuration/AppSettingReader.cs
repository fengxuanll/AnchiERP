using Anchi.ERP.Common.Extensions;
using System.Collections.Generic;
using System.Configuration;

namespace Anchi.ERP.Common.Configuration
{
    /// <summary>
    /// AppSetting配置读取器
    /// </summary>
    public static class AppSettingReader
    {
        private static IDictionary<string, string> Dict;
        static AppSettingReader()
        {
            Dict = new Dictionary<string, string>();
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

            Dict.TryGetValue(key, out string value);

            if (string.IsNullOrWhiteSpace(value))
            {
                value = ConfigurationManager.AppSettings[key];
                Dict[key] = value;
            }

            return value;
        }
        #endregion

        #region 获取数字类型配置
        /// <summary>
        /// 获取数字类型配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt32(string key, int defaultValue = 0)
        {
            var value = GetString(key);

            if (!int.TryParse(value, out int result))
                result = defaultValue;

            return result;
        }
        #endregion

        #region 获取浮点类型配置
        /// <summary>
        /// 获取浮点类型配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetFloat(string key, float defaultValue = 0)
        {
            var value = GetString(key);

            if (!float.TryParse(value, out float result))
                result = defaultValue;

            return result;
        }
        #endregion

        #region 获取Boolean类型配置
        /// <summary>
        /// 获取Boolean类型配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool GetBoolean(string key, bool defaultValue = false)
        {
            var value = GetString(key);

            if (!bool.TryParse(value, out bool result))
                result = defaultValue;

            return result;
        }
        #endregion

        #region 获取字符串集合
        /// <summary>
        /// 获取字符串集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="splitChar"></param>
        /// <param name="removeEmpty"></param>
        /// <returns></returns>
        public static IList<string> GetStringList(string key, string splitChar = ",", bool removeEmpty = true)
        {
            var value = GetString(key);
            if (string.IsNullOrWhiteSpace(value))
                return new List<string>();

            return value.ToList(splitChar, removeEmpty);
        }
        #endregion
    }
}
