using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.RepairOrder.Enum;
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
                if (this.RepairOn.HasValue)
                {
                    sb.Append(" AND RepairOn >= @RepairOnStart AND RepairOn < @RepairOnEnd");
                    this.ParamDict["@RepairOnStart"] = this.RepairOn.Value.Date;
                    this.ParamDict["@RepairOnEnd"] = this.RepairOn.Value.Date.AddDays(1);
                }
                if (this.CompleteOn.HasValue)
                {
                    sb.Append(" AND CompleteOn >= @CompleteOnStart AND CompleteOn < @CompleteOnEnd");
                    this.ParamDict["@CompleteOnStart"] = this.CompleteOn.Value.Date;
                    this.ParamDict["@CompleteOnEnd"] = this.CompleteOn.Value.Date.AddDays(1);
                }
                if (this.SettlementOn.HasValue)
                {
                    sb.Append(" AND SettlementOn >= @SettlementOnStart AND SettlementOn < @SettlementOnEnd");
                    this.ParamDict["@SettlementOnStart"] = this.SettlementOn.Value.Date;
                    this.ParamDict["@SettlementOnEnd"] = this.SettlementOn.Value.Date.AddDays(1);
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
        public DateTime? RepairOn
        {
            get; set;
        }

        /// <summary>
        /// 完工时间
        /// </summary>
        public DateTime? CompleteOn
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
