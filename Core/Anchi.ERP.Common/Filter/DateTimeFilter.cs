using Anchi.ERP.Common.Data;
using System;

namespace Anchi.ERP.Common.Filter
{
    /// <summary>
    /// 时间筛选器
    /// </summary>
    public class DateTimeFilter
    {
        private DateTime? beginTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get
            {
                if (this.beginTime.HasValue && this.beginTime.Value <= SqlDateTime.Min)
                    this.beginTime = SqlDateTime.Min;

                return this.beginTime;
            }
            set
            {
                this.beginTime = value;
            }
        }

        private DateTime? endTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get
            {
                if (this.endTime.HasValue && this.endTime.Value <= SqlDateTime.Min)
                    this.endTime = SqlDateTime.Min;

                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }
    }
}
