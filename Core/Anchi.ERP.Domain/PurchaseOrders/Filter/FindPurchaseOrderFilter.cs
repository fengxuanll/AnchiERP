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
                if (this.ArrivalOn != null)
                {
                    if (this.ArrivalOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND [ArrivalOn] >= @ArrivalOnStart");
                        this.ParamDict["@ArrivalOnStart"] = this.ArrivalOn.BeginTime.Value;
                    }
                    if (this.ArrivalOn.EndTime.HasValue)
                    {
                        sb.Append(" AND [ArrivalOn] < @ArrivalOnEnd");
                        this.ParamDict["@ArrivalOnEnd"] = this.ArrivalOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.SettlementOn != null)
                {
                    if (this.SettlementOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND [SettlementOn] >= @SettlementOnStart");
                        this.ParamDict["@SettlementOnStart"] = this.SettlementOn.BeginTime.Value;
                    }
                    if (this.SettlementOn.EndTime.HasValue)
                    {
                        sb.Append(" AND [SettlementOn] < @SettlementOnEnd");
                        this.ParamDict["@SettlementOnEnd"] = this.SettlementOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.PurchaseOn != null)
                {
                    if (this.PurchaseOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND [PurchaseOn] >= @PurchaseOnStart");
                        this.ParamDict["@PurchaseOnStart"] = this.PurchaseOn.BeginTime.Value;
                    }
                    if (this.PurchaseOn.EndTime.HasValue)
                    {
                        sb.Append(" AND [PurchaseOn] < @PurchaseOnEnd");
                        this.ParamDict["@PurchaseOnEnd"] = this.PurchaseOn.EndTime.Value.Date.AddDays(1);
                    }
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
        public DateTimeFilter PurchaseOn
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
        public DateTimeFilter ArrivalOn
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
        public DateTimeFilter SettlementOn
        {
            get; set;
        }
    }
}
