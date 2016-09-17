using Anchi.ERP.Domain.Products;
using ServiceStack.DataAnnotations;
using System;

namespace Anchi.ERP.Domain.RepairOrder
{
    /// <summary>
    /// 维修单配件明细
    /// </summary>
    public class RepairOrderProduct : BaseDomain
    {
        /// <summary>
        /// 维修单ID
        /// </summary>
        public Guid RepairOrderId
        {
            get; set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice
        {
            get; set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 配件ID
        /// </summary>
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// 使用配件
        /// </summary>
        [Ignore]
        public virtual Product Product
        {
            get; set;
        }
    }
}
