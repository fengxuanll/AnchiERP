using Anchi.ERP.Domain.RepairOrders.Enum;
using System;
using Anchi.ERP.Common.Extensions;

namespace Anchi.ERP.ServiceModel.Repairs
{
    /// <summary>
    /// 维修单实体
    /// </summary>
    public class RepairOrderModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        { get; set; }

        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTime RepairOn
        {
            get; set;
        }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName
        {
            get; set;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNumber
        {
            get; set;
        }

        /// <summary>
        /// 接待人姓名
        /// </summary>
        public string ReceptionByName
        {
            get; set;
        }

        /// <summary>
        /// 应收总金额
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 完工时间
        /// </summary>
        public DateTime CompleteOn
        {
            get; set;
        }

        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime SettlementOn
        {
            get; set;
        }

        /// <summary>
        /// 维修单状态
        /// </summary>
        public EnumRepairOrderStatus Status
        {
            get; set;
        }

        /// <summary>
        /// 维修单状态名称
        /// </summary>
        public string StatusName
        {
            get
            {
                return Status.GetDisplayName();
            }
        }

        /// <summary>
        /// 结算状态
        /// </summary>
        public EnumSettlementStatus SettlementStatus
        {
            get; set;
        }

        /// <summary>
        /// 结算状态名称
        /// </summary>
        public string SettlementStatusName
        {
            get
            {
                return SettlementStatus.GetDisplayName();
            }
        }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal SettlementAmount
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }
    }
}
