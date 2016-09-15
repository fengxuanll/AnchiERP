using Anchi.ERP.Domain.Products;
using System;

namespace Anchi.ERP.Domain.SaleOrders
{
    /// <summary>
    /// 销售配件
    /// </summary>
    public class SaleOrderProduct : BaseDomain
    {
        /// <summary>
        /// 销售单ID
        /// </summary>
        public Guid SaleOrderId
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
        /// 配件信息
        /// </summary>
        public Product Product
        {
            get; set;
        }

        /// <summary>
        /// 销售数量
        /// </summary>
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal UnitPrice
        {
            get; set;
        }
    }
}
