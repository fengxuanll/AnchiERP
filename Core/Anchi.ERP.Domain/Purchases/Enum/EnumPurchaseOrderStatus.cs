namespace Anchi.ERP.Domain.Purchases.Enum
{
    /// <summary>
    /// 采购单状态
    /// </summary>
    public enum EnumPurchaseOrderStatus : byte
    {
        /// <summary>
        /// 采购中
        /// </summary>
        Purchasing = 1,
        /// <summary>
        /// 完成采购
        /// </summary>
        Completed = 2,
        /// <summary>
        /// 部分到货
        /// </summary>
        PartCompleted = 3,
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
