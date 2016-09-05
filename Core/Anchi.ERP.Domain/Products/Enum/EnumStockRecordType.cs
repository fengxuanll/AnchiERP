namespace Anchi.ERP.Domain.Products.Enum
{
    /// <summary>
    /// 库存记录类型
    /// </summary>
    public enum EnumStockRecordType : byte
    {
        /// <summary>
        /// 维修出库
        /// </summary>
        Repair = 1,
        /// <summary>
        /// 采购入库
        /// </summary>
        Purchase = 2,
    }
}
