using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using Anchi.ERP.Domain.RepairOrders.Enum;
using System;
using System.Text;

namespace Anchi.ERP.Domain.PurchaseOrders.Filter
{
    /// <summary>
    /// 查找采购单筛选器
    /// </summary>
    public class FindPurchaseOrderFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [PurchaseOrder] WHERE 1 = 1");

                if (this.SupplierId.HasValue)
                {
                    sb.Append(" AND [SupplierId] = @SupplierId");
                    this.ParamDict["@SupplierId"] = this.SupplierId.Value;
                }
                if (this.PurchaseById.HasValue)
                {
                    sb.Append(" AND [PurchaseById] = @PurchaseById");
                    this.ParamDict["@PurchaseById"] = this.PurchaseById.Value;
                }
                if (this.Status.HasValue)
                {
                    sb.Append(" AND [Status] = @Status");
                    this.ParamDict["@Status"] = (byte)this.Status.Value;
                }
                if (this.SettlementStatus.HasValue)
                {
                    sb.Append(" AND [SettlementStatus] = @SettlementStatus");
                    this.ParamDict["@SettlementStatus"] = (byte)this.SettlementStatus.Value;
                }
                if (this.ArrivalOn.HasValue)
                {
                    sb.Append(" AND [ArrivalOn] >= @ArrivalOnStart AND [ArrivalOn] < @ArrivalOnEnd");
                    this.ParamDict["@ArrivalOnStart"] = this.ArrivalOn.Value.Date;
                    this.ParamDict["@ArrivalOnEnd"] = this.ArrivalOn.Value.Date.AddDays(1);
                }
                if (this.SettlementOn.HasValue)
                {
                    sb.Append(" AND [SettlementOn] >= @SettlementOnStart AND [SettlementOn] < @SettlementOnEnd");
                    this.ParamDict["@SettlementOnStart"] = this.SettlementOn.Value.Date;
                    this.ParamDict["@SettlementOnEnd"] = this.SettlementOn.Value.Date.AddDays(1);
                }
                if (this.PurchaseOn.HasValue)
                {
                    sb.Append(" AND [PurchaseOn] >= @PurchaseOnStart AND [PurchaseOn] < @PurchaseOnEnd");
                    this.ParamDict["@PurchaseOnStart"] = this.PurchaseOn.Value.Date;
                    this.ParamDict["@PurchaseOnEnd"] = this.PurchaseOn.Value.Date.AddDays(1);
                }

                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 供应商ID
        /// </summary>
        public Guid? SupplierId
        {
            get; set;
        }

        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTime? PurchaseOn
        {
            get; set;
        }

        /// <summary>
        /// 采购人ID
        /// </summary>
        public Guid? PurchaseById
        {
            get; set;
        }

        /// <summary>
        /// 采购单状态
        /// </summary>
        public EnumPurchaseOrderStatus? Status
        {
            get; set;
        }

        /// <summary>
        /// 到货时间
        /// </summary>
        public DateTime? ArrivalOn
        {
            get; set;
        }

        /// <summary>
        /// 结算状态
        /// </summary>
        public EnumSettlementStatus? SettlementStatus
        {
            get; set;
        }

        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime? SettlementOn
        {
            get; set;
        }
    }
}
