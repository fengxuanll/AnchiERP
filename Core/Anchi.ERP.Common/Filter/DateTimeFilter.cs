using System;

namespace Anchi.ERP.Common.Filter
{
    /// <summary>
    /// 时间筛选器
    /// </summary>
    public class DateTimeFilter
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get; set;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get; set;
        }
    }
}
