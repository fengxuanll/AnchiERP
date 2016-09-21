using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.SaleOrders.Enum
{
    /// <summary>
    /// 销售订单状态
    /// </summary>
    [EnumAsInt]
    public enum EnumSaleOrderStatus
    {
        /// <summary>
        /// 待出库
        /// </summary>
        [Display(Name = "待出库")]
        Initial = 1,
        /// <summary>
        /// 已出库
        /// </summary>
        [Display(Name = "已出库")]
        Outbound = 2,
    }
}
