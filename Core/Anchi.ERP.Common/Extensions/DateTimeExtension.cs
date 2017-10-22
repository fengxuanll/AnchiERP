using System;

namespace Anchi.ERP.Common.Extensions
{
    /// <summary>
    /// 时间扩展类
    /// </summary>
    public static class DateTimeExtension
    {
        #region 格式化成字符串
        /// <summary>
        /// 格式化成字符串
        /// </summary>
        /// <param name="time"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToFormatString(this DateTime time, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return time.ToString(format);
        }
        #endregion
    }
}
