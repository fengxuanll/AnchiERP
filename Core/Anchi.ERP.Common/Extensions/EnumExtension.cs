using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Anchi.ERP.Common.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        #region 获取枚举Display特性中的Name属性
        /// <summary>
        /// 获取枚举Display特性中的Name属性
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum e)
        {
            Type type = e.GetType();
            var enumField = type.GetField(e.ToString());
            if (enumField == null)
                return null;

            var displayAttributes = enumField.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (displayAttributes == null || !displayAttributes.Any())
                return null;

            var displayItem = displayAttributes.First() as DisplayAttribute;
            return displayItem == null ? null : displayItem.Name;
        }
        #endregion

        #region 将枚举转换为集合
        /// <summary>
        /// 将枚举转换为集合
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static IList<EnumKeyValuePair> ToList(Type enumType)
        {
            var pairList = new List<EnumKeyValuePair>();
            if (enumType == null || !enumType.IsEnum)
                return pairList;

            var valueList = Enum.GetValues(enumType);
            foreach (int valueItem in valueList)
            {
                var pairItem = new EnumKeyValuePair();
                pairItem.Key = Enum.GetName(enumType, valueItem);
                pairItem.Value = valueItem;

                var enumField = enumType.GetField(pairItem.Key);
                if (enumField != null)
                {
                    var displayAttributes = enumField.GetCustomAttributes(typeof(DisplayAttribute), false);
                    if (displayAttributes != null && displayAttributes.Any())
                    {
                        var displayItem = displayAttributes.First() as DisplayAttribute;
                        pairItem.DisplayName = displayItem == null ? null : displayItem.Name;
                    }
                }

                pairList.Add(pairItem);
            }
            return pairList;
        }
        #endregion
    }

    #region 枚举键值项
    /// <summary>
    /// 枚举键值项
    /// </summary>
    public class EnumKeyValuePair
    {
        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Key
        {
            get; set;
        }

        /// <summary>
        /// 枚举值
        /// </summary>
        public int Value
        {
            get; set;
        }

        /// <summary>
        /// 枚举显示名称
        /// </summary>
        public string DisplayName
        {
            get; set;
        }
    }
    #endregion
}
