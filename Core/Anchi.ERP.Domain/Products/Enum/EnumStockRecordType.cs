using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.Products.Enum
{
    /// <summary>
    /// 库存记录类型
    /// </summary>
    [EnumAsInt]
    public enum EnumStockRecordType : byte
    {
        /// <summary>
        /// 维修出库(出库)
        /// </summary>
        [Display(Name = "维修出库")]
        Repair = 10,
        /// <summary>
        /// 销售出库(出库)
        /// </summary>
        [Display(Name = "销售出库")]
        Sale = 11,
        /// <summary>
        /// 取消采购(出库)
        /// </summary>
        [Display(Name = "取消采购")]
        CancelPurchase = 12,
        /// <summary>
        /// 采购入库(入库)
        /// </summary>
        [Display(Name = "采购入库")]
        Purchase = 20,
        /// <summary>
        /// 取消维修(入库)
        /// </summary>
        [Display(Name = "取消维修")]
        CancelRepair = 21,
        /// <summary>
        /// 取消销售(入库)
        /// </summary>
        [Display(Name = "取消销售")]
        CancelSale = 22,
    }
}
