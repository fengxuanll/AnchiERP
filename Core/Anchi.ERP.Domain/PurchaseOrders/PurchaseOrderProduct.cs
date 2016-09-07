using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using ServiceStack.DataAnnotations;
using System;

namespace Anchi.ERP.Domain.PurchaseOrders
{
    /// <summary>
    /// 采购产品
    /// </summary>
    public class PurchaseOrderProduct : BaseDomain
    {
        /// <summary>
        /// 采购单ID
        /// </summary>
        [Required]
        public Guid PurchaseOrderId
        {
            get; set;
        }

        /// <summary>
        /// 采购配件信息
        /// </summary>
        [Reference]
        public virtual Product Product
        {
            get; set;
        }

        /// <summary>
        /// 配件ID
        /// </summary>
        [References(typeof(Product))]
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// 采购单价
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
        /// 到货数量
        /// </summary>
        [Required]
        public int ArrivalQuantity
        {
            get; set;
        }

        /// <summary>
        /// 到货状态
        /// </summary>
        [Required]
        public EnumPurchaseProductStatus Status
        {
            get; set;
        }
    }
}
