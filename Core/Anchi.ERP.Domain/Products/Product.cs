namespace Anchi.ERP.Domain.Products
{
    /// <summary>
    /// 配件信息
    /// </summary>
    public class Product : BaseDomain
    {
        /// <summary>
        /// 配件编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 配件名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 当前库存
        /// </summary>
        public int Stock
        {
            get; set;
        }

        /// <summary>
        /// 安全库存
        /// </summary>
        public int SafeStock
        {
            get; set;
        }

        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal SalePrice
        {
            get; set;
        }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice
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
    }
}
