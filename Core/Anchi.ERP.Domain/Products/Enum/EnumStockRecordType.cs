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
        /// 维修出库
        /// </summary>
        [Display(Name = "维修出库")]
        Repair = 10,
        /// <summary>
        /// 销售出库
        /// </summary>
        [Display(Name = "销售出库")]
        Sale = 11,
        /// <summary>
        /// 采购入库
        /// </summary>
        [Display(Name = "采购入库")]
        Purchase = 20,
    }
}
