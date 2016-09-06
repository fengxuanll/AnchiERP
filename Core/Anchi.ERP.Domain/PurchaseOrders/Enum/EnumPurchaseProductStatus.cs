namespace Anchi.ERP.Domain.PurchaseOrders.Enum
{
    /// <summary>
    /// 采购产品到货状态
    /// </summary>
    public enum EnumPurchaseProductStatus : byte
    {
        /// <summary>
        /// 采购中
        /// </summary>
        Purchasing = 1,
        /// <summary>
        /// 全部到货
        /// </summary>
        Completed = 2,
        /// <summary>
        /// 部分取消
        /// </summary>
        PartCancel = 4,
        /// <summary>
        /// 全部取消
        /// </summary>
        Cancel = 5,
    }
}
