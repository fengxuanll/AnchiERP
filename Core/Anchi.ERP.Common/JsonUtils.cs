using Newtonsoft.Json;

namespace Anchi.ERP.Common
{
    /// <summary>
    /// Json操作类
    /// </summary>
    public class JsonUtils
    {
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            if (value == null)
                return null;

            return JsonConvert.SerializeObject(value);
        }

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
    }
}
