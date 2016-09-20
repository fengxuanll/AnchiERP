using Anchi.ERP.Domain.RepairOrder.Enum;
using System;

namespace Anchi.ERP.ServiceModel.Purchases
{
    /// <summary>
    /// 采购单结算实体
    /// </summary>
    public class PurchaseSettlementModel
    {
        /// <summary>
        /// 维修单ID
        /// </summary>
        public Guid PurchaseOrderId
        {
            get; set;
        }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal SettlementAmount
        {
            get; set;
        }

        /// <summary>
        /// 结算备注
        /// </summary>
        public string SettlementRemark
        {
            get; set;
        }

        /// <summary>
        /// 结算状态
        /// </summary>
        public EnumSettlementStatus SettlementStatus
        {
            get; set;
        }
    }
}
