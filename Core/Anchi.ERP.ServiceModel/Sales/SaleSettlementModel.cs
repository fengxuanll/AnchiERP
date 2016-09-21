using Anchi.ERP.Domain.RepairOrders.Enum;
using System;

namespace Anchi.ERP.ServiceModel.Sales
{
    /// <summary>
    /// 销售结算实体
    /// </summary>
    public class SaleSettlementModel
    {
        /// <summary>
        /// 销售单ID
        /// </summary>
        public Guid SaleOrderId
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
