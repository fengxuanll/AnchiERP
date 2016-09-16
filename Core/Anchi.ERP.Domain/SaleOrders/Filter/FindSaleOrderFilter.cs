using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.RepairOrder.Enum;
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
                var sb = new StringBuilder("SELECT * FROM [SaleOrder] WHERE 1 = 1");
                if (this.SaleOn.HasValue)
                {   // TODO...... 时间类型，待测试
                    sb.Append(" AND SaleOn = @SaleOn");
                    this.ParamDict["@SaleOn"] = this.SaleOn.Value;
                }
                if (this.OutboundOn.HasValue)
                {   // TODO...... 时间类型，待测试
                    sb.Append(" AND OutboundOn = @OutboundOn");
                    this.ParamDict["@OutboundOn"] = this.OutboundOn.Value;
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
                if (this.SaleById.HasValue)
                {
                    sb.Append(" AND SaleById = @SaleById");
                    this.ParamDict["@SaleById"] = this.SaleById.Value;
                }

                return sb.ToString();
            }
        }
        #endregion

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
        public DateTime? SaleOn
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
        public DateTime? OutboundOn
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
