using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Common.Extensions
{
    /// <summary>
    /// 字符串扩展类
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultString"></param>
        /// <returns></returns>
        public static string ExtToString(this object obj, string defaultString = "")
        {
            if (obj == null)
                return defaultString;

            return obj.ToString();
        }

        /// <summary>
        /// 字符串转List
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static IList<string> ToList(this string str, string splitChar = ",")
        {
            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();

            return str.Split(new string[] { splitChar }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
