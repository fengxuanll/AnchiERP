using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Anchi.ERP.Common.Extensions
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtension
    {
        #region ExtToString
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
        #endregion

        #region 字符串转List
        /// <summary>
        /// 字符串转List
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static IList<string> ToList(this string str, string splitChar = ",", bool removeEmpty = true)
        {
            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();

            var options = removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            return str.Split(new string[] { splitChar }, options).ToList();
        }
        #endregion

        #region 替换连续多个空格为一个
        /// <summary>
        /// 替换连续多个空格为一个
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceMultipleSpace(this string str)
        {
            if (str == null)
                return str;

            var spaceRegex = new Regex(@"(\s\s\s*)");
            return spaceRegex.Replace(str, " ");
        }
        #endregion

        #region 单词首字母大写
        /// <summary>
        /// 单词首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperFirstLetter(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            var newList = new List<string>();
            var itemList = str.Split(' ').ToList();
            foreach (var item in itemList)
            {
                newList.Add(" ");
                if (string.IsNullOrWhiteSpace(item))
                    continue;

                var firstLetter = item.Substring(0, 1).ToUpper();
                newList.Add(firstLetter + item.Remove(0, 1));
            }
            if (newList.Any())
                newList.RemoveAt(0);

            return string.Join("", newList);
        }
        #endregion
    }
}
