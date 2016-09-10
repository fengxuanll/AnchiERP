using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.PurchaseOrders.Enum
{
    /// <summary>
    /// 采购单状态
    /// </summary>
    public enum EnumPurchaseOrderStatus : byte
    {
        /// <summary>
        /// 采购中
        /// </summary>
        [Display(Name = "采购中")]
        Purchasing = 1,
        /// <summary>
        /// 完成采购
        /// </summary>
        [Display(Name = "完成采购")]
        Completed = 2,
        /// <summary>
        /// 部分到货
        /// </summary>
        [Display(Name = "部分到货")]
        PartCompleted = 3,
        /// <summary>
        /// 部分取消
        /// </summary>
        [Display(Name = "部分取消")]
        PartCancel = 4,
        /// <summary>
        /// 全部取消
        /// </summary>
        [Display(Name = "全部取消")]
        Cancel = 5,
    }
}
