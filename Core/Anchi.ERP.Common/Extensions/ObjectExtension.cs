using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Anchi.ERP.Common.Extensions
{
    /// <summary>
    /// 对象扩展
    /// </summary>
    public static class ObjectExtension
    {
        #region 深度拷贝对象
        /// <summary>
        /// 深度拷贝对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">可序列化的对象</param>
        /// <returns></returns>
        public static T DeepClone<T>(this T source)
        {
            T result;
            using (Stream objectStream = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(objectStream, source);
                objectStream.Seek(0L, SeekOrigin.Begin);
                result = (T)bf.Deserialize(objectStream);
            }
            return result;
        }
        #endregion

        #region 序列化成Json串
        /// <summary>
        /// 序列化成Json串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, bool throwException = false)
        {
            if (obj == null)
                return "{}";

            try
            {
                return JsonExtension.SerializeToJson(obj);
            }
            catch (Exception ex)
            {
                if (throwException)
                    throw;

                return string.Format("{Exception:'{0}'}", ex.ToString());
            }
        }
        #endregion

        #region 是否包含在序列中
        /// <summary>
        /// 是否包含在序列中
        /// </summary>
        /// <param name="t"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool In<T>(this T t, params T[] list)
        {
            if (list == null || list.Length == 0)
                return false;
            return list.Contains(t);
        }
        #endregion

        #region 是否不包含在序列中
        /// <summary>
        /// 是否不包含在序列中
        /// </summary>
        /// <param name="t"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool NotIn<T>(this T t, params T[] list)
        {
            return !t.In(list);
        }
        #endregion
    }
}
