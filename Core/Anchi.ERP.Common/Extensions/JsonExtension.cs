using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anchi.ERP.Common.Extensions
{
    /// <summary>
    /// Json扩展
    /// </summary>
    public static class JsonExtension
    {
        const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        #region 将对象序列化成Json字符串
        /// <summary>
        /// 将对象序列化成Json字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isIndented"></param>
        /// <returns></returns>
        public static string SerializeToJson(this object value, bool isIndented = false)
        {
            if (value == null)
                return null;

            var timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = DateTimeFormat;
            return isIndented 
                ? JsonConvert.SerializeObject(value, Formatting.Indented, timeFormat) 
                : JsonConvert.SerializeObject(value, timeFormat);
        }
        #endregion

        #region 将Json字符串反序列化成对象
        /// <summary>
        /// 将Json字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool TryDeserializeObject<T>(this string value, out T t)
        {
            t = default(T);
            if (string.IsNullOrWhiteSpace(value))
                return false;

            value = value.Trim();
            if (!value.StartsWith("{") && !value.StartsWith("["))
                return false;

            try
            {
                t = JsonConvert.DeserializeObject<T>(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
