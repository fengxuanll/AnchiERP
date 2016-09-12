using System;

namespace Anchi.ERP.ServiceModel.Repairs
{
    /// <summary>
    /// 维修单结算实体
    /// </summary>
    public class RepairSettlementModel
    {
        /// <summary>
        /// 维修单ID
        /// </summary>
        public Guid RepairOrderId
        { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal SettlementAmount
        { get; set; }

        /// <summary>
        /// 结算备注
        /// </summary>
        public string SettlementRemark
        { get; set; }
    }
}
