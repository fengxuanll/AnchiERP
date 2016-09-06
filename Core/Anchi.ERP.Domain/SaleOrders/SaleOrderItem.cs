using ServiceStack.DataAnnotations;
using System;

namespace Anchi.ERP.Domain.SaleOrders
{
    /// <summary>
    /// 销售配件
    /// </summary>
    public class SaleOrderItem : BaseDomain
    {
        /// <summary>
        /// 销售单ID
        /// </summary>
        [Required]
        public Guid SaleOrderId
        {
            get; set;
        }

        /// <summary>
        /// 配件ID
        /// </summary>
        [Required]
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// 销售数量
        /// </summary>
        [Required]
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 销售单价
        /// </summary>
        [Required]
        public decimal UnitPrice
        {
            get; set;
        }
    }
}
