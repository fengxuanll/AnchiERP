using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.PurchaseOrders.Enum;

namespace Anchi.ERP.Domain.PurchaseOrders
{
    /// <summary>
    /// 采购产品
    /// </summary>
    public class PurchaseOrderProduct : BaseDomain
    {
        /// <summary>
        /// 产品信息
        /// </summary>
        public virtual Product Product
        {
            get; set;
        }

        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal Price
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
        /// 到货数量
        /// </summary>
        public int ArrivalQuantity
        {
            get; set;
        }

        /// <summary>
        /// 到货状态
        /// </summary>
        public EnumPurchaseProductStatus Status
        {
            get; set;
        }
    }
}
