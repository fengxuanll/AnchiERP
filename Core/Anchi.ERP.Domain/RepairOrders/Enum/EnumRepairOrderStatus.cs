namespace Anchi.ERP.Domain.RepairOrder.Enum
{
    /// <summary>
    /// 维修单状态
    /// </summary>
    public enum EnumRepairOrderStatus : byte
    {
        /// <summary>
        /// 维修中
        /// </summary>
        Repairing = 1,
        /// <summary>
        /// 维修完成
        /// </summary>
        Completed = 2,
        /// <summary>
        /// 已取消
        /// </summary>
        Cancel = 3,
    }
}
