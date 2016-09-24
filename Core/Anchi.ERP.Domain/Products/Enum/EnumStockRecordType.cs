using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.Products.Enum
{
    /// <summary>
    /// 库存记录类型
    /// </summary>
    [EnumAsInt]
    public enum EnumStockRecordType
    {
        /// <summary>
        /// 维修出库(出库)
        /// </summary>
        [Display(Name = "维修出库", GroupName = "Out")]
        Repair = 10,
        /// <summary>
        /// 销售出库(出库)
        /// </summary>
        [Display(Name = "销售出库", GroupName = "Out")]
        Sale = 11,
        /// <summary>
        /// 取消采购(出库)
        /// </summary>
        [Display(Name = "取消采购", GroupName = "Out")]
        CancelPurchase = 12,
        /// <summary>
        /// 库存盘损(出库)
        /// </summary>
        [Display(Name = "库存盘损", GroupName = "Out")]
        ModifyStockOut = 13,
        /// <summary>
        /// 采购入库(入库)
        /// </summary>
        [Display(Name = "采购入库", GroupName = "In")]
        Purchase = 20,
        /// <summary>
        /// 取消维修(入库)
        /// </summary>
        [Display(Name = "取消维修", GroupName = "In")]
        CancelRepair = 21,
        /// <summary>
        /// 取消销售(入库)
        /// </summary>
        [Display(Name = "取消销售", GroupName = "In")]
        CancelSale = 22,
        /// <summary>
        /// 库存盘赢(入库)
        /// </summary>
        [Display(Name = "库存盘赢", GroupName = "In")]
        ModifyStockIn = 23,
    }
}
