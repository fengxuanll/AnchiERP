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
                {   // TODO...... 时间类型，待测试
                    sb.Append(" AND RepairOn = @RepairOn");
                    this.ParamDict["@RepairOn"] = this.RepairOn.Value;
                }
                if (this.CompleteOn.HasValue)
                {   // TODO...... 时间类型，待测试
                    sb.Append(" AND CompleteOn = @CompleteOn");
                    this.ParamDict["@CompleteOn"] = this.CompleteOn.Value;
                }
                if (this.SettlementOn.HasValue)
                {   // TODO...... 时间类型，待测试
                    sb.Append(" AND SettlementOn = @SettlementOn");
                    this.ParamDict["@SettlementOn"] = this.SettlementOn.Value;
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
