using System;
using Anchi.ERP.Domain.SaleOrders.Enum;
using Anchi.ERP.Common.Extensions;
using Anchi.ERP.Domain.RepairOrders.Enum;

namespace Anchi.ERP.ServiceModel.Sales
{
    /// <summary>
	/// 销售单实体
	/// </summary>
	public class SaleOrderModel
	{
		/// <summary>
		/// 销售单ID
		/// </summary>
		/// <value>The identifier.</value>
		public Guid Id
		{ get; set; }

		/// <summary>
		/// 开单时间
		/// </summary>
		/// <value>The sale on.</value>
		public DateTime SaleOn
		{ get; set; }

		/// <summary>
		/// 客户姓名
		/// </summary>
		/// <value>The name of the customer.</value>
		public string CustomerName
		{ get; set; }

		/// <summary>
		/// 销售人姓名
		/// </summary>
		/// <value>The name of the sale by.</value>
		public string SaleByName
		{ get; set; }

		/// <summary>
		/// 销售单状态
		/// </summary>
		/// <value>The status.</value>
		public EnumSaleOrderStatus Status
		{ get; set; }

		/// <summary>
		/// 销售单状态名称
		/// </summary>
		/// <value>The name of the status.</value>
		public string StatusName
		{
			get
			{
				return Status.GetDisplayName();
			}
		}

		/// <summary>
		/// 订单总金额
		/// </summary>
		/// <value>The amount.</value>
		public decimal Amount
		{ get; set; }

		/// <summary>
		/// 结算金额
		/// </summary>
		/// <value>The settlement amount.</value>
		public decimal SettlementAmount
		{ get; set; }

		/// <summary>
		/// 结算状态
		/// </summary>
		/// <value>The settlement status.</value>
		public EnumSettlementStatus SettlementStatus
		{ get; set; }

		/// <summary>
		/// 结算状态名称
		/// </summary>
		/// <value>The name of the settlement status.</value>
		public string SettlementStatusName
		{
			get
			{
				return SettlementStatus.GetDisplayName();
			}
		}

		/// <summary>
		/// 结算时间
		/// </summary>
		/// <value>The settlement on.</value>
		public DateTime SettlementOn
		{ get; set; }

		/// <summary>
		/// 出库时间
		/// </summary>
		/// <value>The outbound on.</value>
		public DateTime OutboundOn
		{ get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		/// <value>The remark.</value>
		public string Remark
		{ get; set; }
	}
}

