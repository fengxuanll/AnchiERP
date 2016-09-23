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
                var sb = new StringBuilder("SELECT * FROM [RepairOrder] WHERE 1 = 1");
                if (this.RepairOn != null)
                {
                    if (this.RepairOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND [RepairOn] >= @RepairOnStart");
                        this.ParamDict["@RepairOnStart"] = this.RepairOn.BeginTime.Value;
                    }
                    if (this.RepairOn.EndTime.HasValue)
                    {
                        sb.Append(" AND [RepairOn] < @RepairOnEnd");
                        this.ParamDict["@RepairOnEnd"] = this.RepairOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.CompleteOn != null)
                {
                    if (this.CompleteOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND [CompleteOn] >= @CompleteOnStart");
                        this.ParamDict["@CompleteOnStart"] = this.CompleteOn.BeginTime.Value;
                    }
                    if (this.CompleteOn.EndTime.HasValue)
                    {
                        sb.Append(" AND [CompleteOn] < @CompleteOnEnd");
                        this.ParamDict["@CompleteOnEnd"] = this.CompleteOn.EndTime.Value.Date.AddDays(1);
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
                if (this.Status.HasValue)
                {
                    sb.Append(" AND Status = @Status");
                    this.ParamDict["@Status"] = (byte)this.Status.Value;
                }
                if (this.SettlementStatus.HasValue)
                {
                    sb.Append(" AND SettlementStatus = @SettlementStatus");
                    this.ParamDict["@SettlementStatus"] = (byte)this.SettlementStatus.Value;
                }
                if (this.CustomerId.HasValue)
                {
                    sb.Append(" AND CustomerId = @CustomerId");
                    this.ParamDict["@CustomerId"] = this.CustomerId.Value;
                }
                if (this.ReceptionById.HasValue)
                {
                    sb.Append(" AND ReceptionById = @ReceptionById");
                    this.ParamDict["@ReceptionById"] = this.ReceptionById.Value;
                }

                return sb.ToString();
            }
        }
        #endregion

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
