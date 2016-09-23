using Anchi.ERP.Domain.Sequences.Enum;
using System;

namespace Anchi.ERP.Domain.Sequences
{
    /// <summary>
    /// 序列
    /// </summary>
    public class Sequence
    {
        /// <summary>
        /// 序列类型(唯一)
        /// </summary>
        public virtual EnumSequenceType Type
        {
            get; set;
        }

        /// <summary>
        /// 最小值
        /// </summary>
        public virtual long MinValue
        {
            get; set;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public virtual long MaxValue
        {
            get; set;
        }

        /// <summary>
        /// 用于定义序列的步长，如果省略，则默认为1，如果出现负值，则代表序列的值是按照此步长递减的。
        /// </summary>
        public virtual long Increment
        {
            get;
            set;
        }

        /// <summary>
        /// 当前值，这个值已经被用掉了。
        /// </summary>
        public virtual long CurrentValue
        {
            get;
            set;
        }

        /// <summary>
        /// 0：最大值后会重新开始序列
        /// 1：按天循环
        /// </summary>
        public virtual byte Cycle
        {
            get;
            set;
        }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime ModifiedOn
        {
            get;
            set;
        }

        /// <summary>
        /// 序列描述
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

        #region 获取下一个序列值
        private static object _locker = new object();
        /// <summary>
        /// 获取下一个序列值
        /// </summary>
        /// <returns></returns>
        public long GetNextValue()
        {
            lock (_locker)
            {
                if (this.CurrentValue >= this.MaxValue || this.CurrentValue <= this.MinValue || (this.Cycle == 1 && this.ModifiedOn.Date != DateTime.Now.Date))
                    this.CurrentValue = this.MinValue;

                this.ModifiedOn = DateTime.Now;
                this.CurrentValue = this.CurrentValue + this.Increment;
            }
            return this.CurrentValue;
        }
        #endregion
    }
}
