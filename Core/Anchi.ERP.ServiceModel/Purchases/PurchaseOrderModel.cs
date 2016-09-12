using Anchi.ERP.Common.Extensions;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using Anchi.ERP.Domain.RepairOrder.Enum;
using System;

namespace Anchi.ERP.ServiceModel.Purchases
{
    /// <summary>
    /// 采购单实体
    /// </summary>
    public class PurchaseOrderModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName
        { get; set; }

        /// <summary>
        /// 采购人姓名
        /// </summary>
        public string PurchaseByName
        { get; set; }

        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTime PurchaseOn
        { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal Amount
        { get; set; }

        /// <summary>
        /// 采购单状态
        /// </summary>
        public EnumPurchaseOrderStatus Status
        { get; set; }

        /// <summary>
        /// 采购单状态名称
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
        /// 备注
        /// </summary>
        public string Remark
        { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime SettlementOn
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
