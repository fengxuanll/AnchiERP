using Anchi.ERP.Domain.Products;
using ServiceStack.DataAnnotations;
using System;

namespace Anchi.ERP.Domain.RepairOrder
{
    /// <summary>
    /// 维修单配件明细
    /// </summary>
    public class RepairProductItem : BaseDomain
    {
        /// <summary>
        /// 维修单ID
        /// </summary>
        [Required]
        public Guid RepairOrderId
        {
            get; set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        public decimal UnitPrice
        {
            get; set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 配件ID
        /// </summary>
        [Required]
        [References(typeof(Product))]
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// 使用配件
        /// </summary>
        [Reference]
        public virtual Product Product
        {
            get; set;
        }
    }
}
