using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.RepairOrders.Enum;
using Anchi.ERP.Domain.SaleOrders.Enum;
using System;
using System.Text;

namespace Anchi.ERP.Domain.SaleOrders.Filter
{
    /// <summary>
    /// 查找销售单筛选器
    /// </summary>
    public class FindSaleOrderFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT so.* FROM [SaleOrder] so");
                if (!string.IsNullOrWhiteSpace(this.Customer))
                {
                    sb.Append(" JOIN [Customer] c ON c.Id = so.CustomerId");
                    sb.Append(" AND (CHARINDEX(@Customer, c.Name) OR CHARINDEX(@Customer, c.CarNumber))");
                    this.ParamDict["@Customer"] = this.Customer;
                }
                sb.Append(" WHERE 1 = 1");
                if (this.SaleOn != null)
                {
                    if (this.SaleOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND so.[SaleOn] >= @SaleOnStart");
                        this.ParamDict["@SaleOnStart"] = this.SaleOn.BeginTime.Value;
                    }
                    if (this.SaleOn.EndTime.HasValue)
                    {
                        sb.Append(" AND so.[SaleOn] < @SaleOnEnd");
                        this.ParamDict["@SaleOnEnd"] = this.SaleOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.OutboundOn != null)
                {
                    if (this.OutboundOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND so.[OutboundOn] >= @OutboundOnStart");
                        this.ParamDict["@OutboundOnStart"] = this.OutboundOn.BeginTime.Value;
                    }
                    if (this.OutboundOn.EndTime.HasValue)
                    {
                        sb.Append(" AND so.[OutboundOn] < @OutboundOnEnd");
                        this.ParamDict["@OutboundOnEnd"] = this.OutboundOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.SettlementOn != null)
                {
                    if (this.SettlementOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND so.[SettlementOn] >= @SettlementOnStart");
                        this.ParamDict["@SettlementOnStart"] = this.SettlementOn.BeginTime.Value;
                    }
                    if (this.SettlementOn.EndTime.HasValue)
                    {
                        sb.Append(" AND so.[SettlementOn] < @SettlementOnEnd");
                        this.ParamDict["@SettlementOnEnd"] = this.SettlementOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.Status.HasValue)
                {
                    sb.Append(" AND so.[Status] = @Status");
                    this.ParamDict["@Status"] = (byte)this.Status.Value;
                }
                if (this.SettlementStatus.HasValue)
                {
                    sb.Append(" AND so.[SettlementStatus] = @SettlementStatus");
                    this.ParamDict["@SettlementStatus"] = (byte)this.SettlementStatus.Value;
                }
                if (this.CustomerId.HasValue)
                {
                    sb.Append(" AND so.[CustomerId] = @CustomerId");
                    this.ParamDict["@CustomerId"] = this.CustomerId.Value;
                }
                if (this.SaleById.HasValue)
                {
                    sb.Append(" AND so.[SaleById] = @SaleById");
                    this.ParamDict["@SaleById"] = this.SaleById.Value;
                }

                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 客户姓名或者车牌号
        /// </summary>
        public string Customer
        {
            get; set;
        }

        /// <summary>
        /// 销售人ID
        /// </summary>
        public Guid? SaleById
        {
            get; set;
        }

        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid? CustomerId
        {
            get; set;
        }

        /// <summary>
        /// 销售时间
        /// </summary>
        public DateTimeFilter SaleOn
        {
            get; set;
        }

        /// <summary>
        /// 销售单状态
        /// </summary>
        public EnumSaleOrderStatus? Status
        {
            get; set;
        }

        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTimeFilter OutboundOn
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
