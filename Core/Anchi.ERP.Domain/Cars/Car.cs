using Anchi.ERP.Domain.Customers;
using System;

namespace Anchi.ERP.Domain.Cars
{
    /// <summary>
    /// 车
    /// </summary>
    public class Car : BaseDomain
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string Number
        {
            get; set;
        }

        /// <summary>
        /// 所属客户ID
        /// </summary>
        public int CustomerId
        {
            get; set;
        }

        /// <summary>
        /// 所属客户
        /// </summary>
        public virtual Customer Customer
        {
            get; set;
        }

        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNo
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn
        {
            get; set;
        }
    }
}
