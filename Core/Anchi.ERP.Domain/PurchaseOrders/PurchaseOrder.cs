using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using Anchi.ERP.Domain.RepairOrder.Enum;
using Anchi.ERP.Domain.Suppliers;
using Anchi.ERP.Domain.Users;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Domain.PurchaseOrders
{
    /// <summary>
    /// 采购单
    /// </summary>
    public class PurchaseOrder : BaseDomain
    {
        /// <summary>
        /// 供应商
        /// </summary>
        [Reference]
        [Ignore]
        public Supplier Supplier
        {
            get; set;
        }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [Required]
        [References(typeof(Supplier))]
        public Guid SupplierId
        {
            get; set;
        }

        /// <summary>
        /// 采购人
        /// </summary>
        [Reference]
        [Ignore]
        public Employee PurchaseBy
        {
            get; set;
        }

        /// <summary>
        /// 采购人ID
        /// </summary>
        [Required]
        [References(typeof(Employee))]
        public Guid PurchaseById
        {
            get; set;
        }

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 采购单状态
        /// </summary>
        [Required]
        [StringLength(50)]
        public EnumPurchaseOrderStatus Status
        {
            get; set;
        }

        /// <summary>
        /// 结算状态
        /// </summary>
        [Required]
        [StringLength(50)]
        public EnumSettlementStatus SettlementStatus
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(1000)]
        public string Remark
        {
            get; set;
        }

        private IList<PurchaseOrderProduct> productList;
        /// <summary>
        /// 采购产品
        /// </summary>
        [Ignore]
        public virtual IList<PurchaseOrderProduct> ProductList
        {
            get
            {
                if (productList == null)
                    productList = new List<PurchaseOrderProduct>();

                return productList;
            }
            set
            {
                productList = value;
            }
        }
    }
}
