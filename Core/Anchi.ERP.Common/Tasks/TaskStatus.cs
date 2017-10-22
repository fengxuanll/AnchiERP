using System;

namespace Anchi.ERP.Common.Tasks
{
    public class TaskStatus
    {
        /// <summary>
        /// 是否循环处理。false：只会调用一次PrepareData；true：会一直调用PrepareData，直到返回数据为空。
        /// </summary>
        public virtual bool Crculative
        {
            get;
            set;
        }
        /// <summary>
        /// 挂起标识
        /// </summary>
        public bool Suspended
        {
            get;
            internal set;
        }
        /// <summary>
        /// Task开始执行的UTC时间
        /// </summary>
        public DateTime StartTime
        {
            get;
            internal set;
        }
        /// <summary>
        /// 最近一次执行UTC时间
        /// </summary>
        public DateTime LastActiveTime
        {
            get;
            internal set;
        }
    }
}
