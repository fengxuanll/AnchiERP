using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anchi.ERP.Common
{
    /// <summary>
    /// Json操作类
    /// </summary>
    public class JsonUtils
    {
        const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        #region 序列化对象
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize(object value)
        {
            if (value == null)
                return null;

            var timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = DateTimeFormat;
            return JsonConvert.SerializeObject(value, timeFormat);
        }
        #endregion

        #region 序列化对象
        /// <summary>
        /// 序列化对象，并待缩进格式化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeIndented(object value)
        {
            if (value == null)
                return null;

            var timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = DateTimeFormat;
            return JsonConvert.SerializeObject(value, Formatting.Indented, timeFormat);
        }
        #endregion

        #region 反序列化对象
        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool TryDeserializeObject<T>(string value, out T t)
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
