using Anchi.ERP.Common.Data;
using System;

namespace Anchi.ERP.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class BaseDomain
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        private DateTime createdOn;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn
        {
            get
            {
                if (createdOn < SqlDateTime.Min)
                    createdOn = SqlDateTime.Min;

                return createdOn;
            }
            set
            {
                createdOn = value;
            }
        }
    }
}
