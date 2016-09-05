using Anchi.ERP.Domain.Products;

namespace Anchi.ERP.Domain.Repairs
{
    /// <summary>
    /// 配件明细
    /// </summary>
    public class RepairProductItem : BaseDomain
    {
        /// <summary>
        /// 单价
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
        /// 使用配件
        /// </summary>
        public virtual Product Product
        {
            get; set;
        }
    }
}
