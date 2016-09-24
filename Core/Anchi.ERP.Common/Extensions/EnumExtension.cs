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
        static Dictionary<object, DisplayAttribute> EnmuDisplayAttributeCache = null;
        static EnumExtension()
        {
            EnmuDisplayAttributeCache = new Dictionary<object, DisplayAttribute>();
        }

        #region 获取枚举Display特性中的Name属性
        /// <summary>
        /// 获取枚举Display特性中的Name属性
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum e)
        {
            var displayAttr = e.GetDisplayAttribute();
            return displayAttr == null ? null : displayAttr.Name;
        }
        #endregion

        #region 获取枚举Display特性中的Description属性
        /// <summary>
        /// 获取枚举Display特性中的Description属性
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDisplayDescription(this Enum e)
        {
            var displayAttr = e.GetDisplayAttribute();
            return displayAttr == null ? null : displayAttr.Description;
        }
        #endregion

        #region 获取枚举Display特性中的GroupName属性
        /// <summary>
        /// 获取枚举Display特性中的GroupName属性
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDisplayGroupName(this Enum e)
        {
            var displayAttr = e.GetDisplayAttribute();
            return displayAttr == null ? null : displayAttr.GroupName;
        }
        #endregion

        #region 获取枚举的Display特性
        private static object _locker = new object();
        /// <summary>
        /// 获取枚举的Display特性
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static DisplayAttribute GetDisplayAttribute(this object e)
        {
            if (!EnmuDisplayAttributeCache.ContainsKey(e))
            {
                Type type = e.GetType();
                lock (_locker)
                {
                    if (!EnmuDisplayAttributeCache.ContainsKey(e))
                    {
                        DisplayAttribute displayItem = null;
                        var enumField = type.GetField(e.ToString());
                        if (enumField != null)
                        {
                            var displayAttributes = enumField.GetCustomAttributes(typeof(DisplayAttribute), false);
                            if (displayAttributes != null && displayAttributes.Any())
                            {
                                displayItem = displayAttributes.First() as DisplayAttribute;
                            }
                        }
                        EnmuDisplayAttributeCache[e] = displayItem;
                    }
                }
            }
            return EnmuDisplayAttributeCache[e];
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

                var tEnum = Enum.Parse(enumType, pairItem.Key);
                var displayAttr = tEnum.GetDisplayAttribute();
                if (displayAttr != null)
                {
                    pairItem.DisplayName = displayAttr.Name;
                    pairItem.DisplayDescription = displayAttr.Description;
                    pairItem.DisplayGroupName = displayAttr.GroupName;
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

        /// <summary>
        /// 枚举描述
        /// </summary>
        public string DisplayDescription
        {
            get; set;
        }

        /// <summary>
        /// 枚举分组
        /// </summary>
        public string DisplayGroupName
        {
            get; set;
        }
    }
    #endregion
}
