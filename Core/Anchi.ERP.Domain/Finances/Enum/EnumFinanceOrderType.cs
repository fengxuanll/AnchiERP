using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.Finances.Enum
{
    /// <summary>
    /// 财务单状态枚举
    /// </summary>
    [EnumAsInt]
    public enum EnumFinanceOrderType
    {
        /// <summary>
        /// 维修收款
        /// </summary>
        [Display(Name = "维修收款")]
        ReceiptRepair = 10,
        /// <summary>
        /// 销售收款
        /// </summary>
        [Display(Name = "销售收款")]
        ReceiptSale = 11,
        /// <summary>
        /// 采购付款
        /// </summary>
        [Display(Name = "采购付款")]
        PaymentPurchase = 20,
    }
}
