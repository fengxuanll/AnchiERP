using System;

namespace Anchi.ERP.Common.Extensions
{
    /// <summary>
    /// 小数类型扩展类
    /// </summary>
    public static class DecimalExtension
    {
        #region 保留小数位
        /// <summary>
        /// 保留小数位
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ExRound(this decimal d, int digits = 2, EnumMidpointRounding rounding = EnumMidpointRounding.AwayFromZero)
        {
            if (rounding == EnumMidpointRounding.AwayFromZero)
                return Math.Round(d, digits, MidpointRounding.AwayFromZero);

            if (rounding == EnumMidpointRounding.ToEven)
                return Math.Round(d, digits, MidpointRounding.ToEven);

            var digitValue = (decimal)Math.Pow(10, digits);
            return Math.Truncate(d * digitValue) / digitValue;
        }
        #endregion
    }

    /// <summary>
    ///  指定数学舍入方法应如何处理两个数字间的中间值。
    /// </summary>
    public enum EnumMidpointRounding
    {
        /// <summary>
        /// 当一个数字是其他两个数字的中间值时，会将其舍入为最接近的偶数。
        /// </summary>
        ToEven = 0,
        /// <summary>
        /// 当一个数字是其他两个数字的中间值时，会将其舍入为两个值中绝对值较小的值。
        /// </summary>
        AwayFromZero = 1,
        /// <summary>
        /// 不处理，直接截取小数位
        /// </summary>
        NoRounding = 2,
    }
}
