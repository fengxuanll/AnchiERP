using System.IO;
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
    }
}
