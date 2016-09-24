using Anchi.ERP.Common.Data;
using Anchi.ERP.Domain.Customers;
using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.RepairOrders.Enum;
using Anchi.ERP.Domain.SaleOrders.Enum;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Domain.SaleOrders
{
    /// <summary>
    /// 销售单
    /// </summary>
    public class SaleOrder : BaseDomain
    {
        /// <summary>
        /// 销售单编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 销售人ID
        /// </summary>
        public Guid SaleById
        {
            get; set;
        }

        /// <summary>
        /// 销售人信息
        /// </summary>
        [Ignore]
        public Employee SaleBy
        {
            get; set;
        }

        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid CustomerId
        {
            get; set;
        }

        /// <summary>
        /// 客户信息
        /// </summary>
        [Ignore]
        public Customer Customer
        {
            get; set;
        }

        /// <summary>
        /// 销售时间
        /// </summary>
        public DateTime SaleOn
        {
            get; set;
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 销售单状态
        /// </summary>
        public EnumSaleOrderStatus Status
        {
            get; set;
        }

        private DateTime outboundOn;
        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime OutboundOn
        {
            get
            {
                if (outboundOn < SqlDateTime.Min)
                    outboundOn = SqlDateTime.Min;

                return outboundOn;
            }
            set
            {
                outboundOn = value;
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
        /// 已结算金额
        /// </summary>
        public decimal SettlementAmount
        {
            get; set;
        }

        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime SettlementOn
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public Guid CreatedById
        {
            get; set;
        }

        private IList<SaleOrderProduct> productList;
        /// <summary>
        /// 销售配件列表
        /// </summary>
        [Ignore]
        public virtual IList<SaleOrderProduct> ProductList
        {
            get
            {
                if (productList == null)
                    productList = new List<SaleOrderProduct>();

                return productList;
            }
            set
            {
                productList = value;
            }
        }
    }
}
