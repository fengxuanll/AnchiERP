using System;

namespace Anchi.ERP.Common.Filter
{
    /// <summary>
    /// 时间筛选器
    /// </summary>
    public class DateTimeFilter
    {
        private DateTime beginTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime
        {
            get
            {
                if (beginTime < SqlDateTime.Min)
                    beginTime = SqlDateTime.Min;

                return beginTime;
            }
            set
            {
                beginTime = value;
            }
        }

        private DateTime endTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                if (endTime < SqlDateTime.Min)
                    endTime = DateTime.Now;

                return endTime;
            }
            set
            {
                endTime = value;
            }
        }
    }
}
