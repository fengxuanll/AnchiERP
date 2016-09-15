using Anchi.ERP.Domain.Products;
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
        public Guid PurchaseOrderId
        {
            get; set;
        }

        /// <summary>
        /// 采购配件信息
        /// </summary>
        public virtual Product Product
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
        /// 采购单价
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
    }
}
