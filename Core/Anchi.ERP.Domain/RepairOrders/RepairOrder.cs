using Anchi.ERP.Common;
using Anchi.ERP.Domain.Customers;
using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.RepairOrders.Enum;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Domain.RepairOrder
{
    /// <summary>
    /// 维修单
    /// </summary>
    public class RepairOrder : BaseDomain
    {
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        private DateTime repairOn;
        /// <summary>
        /// 开单日期
        /// </summary>
        public DateTime RepairOn
        {
            get
            {
                if (repairOn < SqlDateTime.Min)
                    repairOn = SqlDateTime.Min;

                return repairOn;
            }
            set
            {
                repairOn = value;
            }
        }

        private DateTime completeOn;
        /// <summary>
        /// 完工时间
        /// </summary>
        public DateTime CompleteOn
        {
            get
            {
                if (completeOn < SqlDateTime.Min)
                    completeOn = SqlDateTime.Min;

                return completeOn;
            }
            set
            {
                completeOn = value;
            }
        }

        private DateTime settlementOn;
        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime SettlementOn
        {
            get
            {
                if (settlementOn < SqlDateTime.Min)
                    settlementOn = SqlDateTime.Min;

                return settlementOn;
            }
            set
            {
                settlementOn = value;
            }
        }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal SettlementAmount
        {
            get; set;
        }

        /// <summary>
        /// 维修单状态
        /// </summary>
        public EnumRepairOrderStatus Status
        {
            get; set;
        }

        /// <summary>
        /// 结算状态
        /// </summary>
        public EnumSettlementStatus SettlementStatus
        {
            get; set;
        }

        /// <summary>
        /// 客户信息
        /// </summary>
        [Ignore]
        public virtual Customer Customer
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
        /// 接待人ID
        /// </summary>
        public Guid ReceptionById
        {
            get; set;
        }

        /// <summary>
        /// 接待人信息
        /// </summary>
        [Ignore]
        public virtual Employee ReceptionBy
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

        private IList<RepairOrderProject> projectList;
        /// <summary>
        /// 维修项目列表
        /// </summary>
        [Ignore]
        public virtual IList<RepairOrderProject> ProjectList
        {
            get
            {
                if (projectList == null)
                    projectList = new List<RepairOrderProject>();

                return projectList;
            }
            set
            {
                projectList = value;
            }
        }

        private IList<RepairOrderProduct> productList;
        /// <summary>
        /// 配件明细列表
        /// </summary>
        [Ignore]
        public virtual IList<RepairOrderProduct> ProductList
        {
            get
            {
                if (productList == null)
                    productList = new List<RepairOrderProduct>();

                return productList;
            }
            set
            {
                productList = value;
            }
        }
    }
}
