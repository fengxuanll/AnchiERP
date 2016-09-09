using System;
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
    }
}
