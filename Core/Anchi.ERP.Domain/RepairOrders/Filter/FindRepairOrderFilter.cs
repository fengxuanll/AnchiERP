using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.RepairOrders.Enum;
using System;
using System.Text;

namespace Anchi.ERP.Domain.RepairOrders.Filter
{
    /// <summary>
    /// 查找维修单筛选器
    /// </summary>
    public class FindRepairOrderFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT ro.* FROM [RepairOrder] ro");
                if (!string.IsNullOrWhiteSpace(this.Customer))
                {
                    sb.Append(" JOIN [Customer] c ON c.Id = ro.CustomerId");
                    sb.Append(" AND (CHARINDEX(@Customer, c.Name) OR CHARINDEX(@Customer, c.CarNumber))");
                    this.ParamDict["@Customer"] = this.Customer;
                }
                sb.Append(" WHERE 1 = 1");
                if (this.RepairOn != null)
                {
                    if (this.RepairOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND ro.[RepairOn] >= @RepairOnStart");
                        this.ParamDict["@RepairOnStart"] = this.RepairOn.BeginTime.Value;
                    }
                    if (this.RepairOn.EndTime.HasValue)
                    {
                        sb.Append(" AND ro.[RepairOn] < @RepairOnEnd");
                        this.ParamDict["@RepairOnEnd"] = this.RepairOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.CompleteOn != null)
                {
                    if (this.CompleteOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND ro.[CompleteOn] >= @CompleteOnStart");
                        this.ParamDict["@CompleteOnStart"] = this.CompleteOn.BeginTime.Value;
                    }
                    if (this.CompleteOn.EndTime.HasValue)
                    {
                        sb.Append(" AND ro.[CompleteOn] < @CompleteOnEnd");
                        this.ParamDict["@CompleteOnEnd"] = this.CompleteOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.SettlementOn != null)
                {
                    if (this.SettlementOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND ro.[SettlementOn] >= @SettlementOnStart");
                        this.ParamDict["@SettlementOnStart"] = this.SettlementOn.BeginTime.Value;
                    }
                    if (this.SettlementOn.EndTime.HasValue)
                    {
                        sb.Append(" AND ro.[SettlementOn] < @SettlementOnEnd");
                        this.ParamDict["@SettlementOnEnd"] = this.SettlementOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.Status.HasValue)
                {
                    sb.Append(" AND ro.[Status] = @Status");
                    this.ParamDict["@Status"] = (byte)this.Status.Value;
                }
                if (this.SettlementStatus.HasValue)
                {
                    sb.Append(" AND ro.[SettlementStatus] = @SettlementStatus");
                    this.ParamDict["@SettlementStatus"] = (byte)this.SettlementStatus.Value;
                }
                if (this.CustomerId.HasValue)
                {
                    sb.Append(" AND ro.[CustomerId] = @CustomerId");
                    this.ParamDict["@CustomerId"] = this.CustomerId.Value;
                }
                if (this.ReceptionById.HasValue)
                {
                    sb.Append(" AND ro.[ReceptionById] = @ReceptionById");
                    this.ParamDict["@ReceptionById"] = this.ReceptionById.Value;
                }

                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 客户姓名或车牌号
        /// </summary>
        public string Customer
        {
            get; set;
        }

        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTimeFilter RepairOn
        {
            get; set;
        }

        /// <summary>
        /// 完工时间
        /// </summary>
        public DateTimeFilter CompleteOn
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

        /// <summary>
        /// 维修单状态
        /// </summary>
        public EnumRepairOrderStatus? Status
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
        /// 客户ID
        /// </summary>
        public Guid? CustomerId
        {
            get; set;
        }

        /// <summary>
        /// 接待人ID
        /// </summary>
        public Guid? ReceptionById
        {
            get; set;
        }
    }
}
