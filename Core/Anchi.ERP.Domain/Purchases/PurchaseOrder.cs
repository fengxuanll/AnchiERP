using Anchi.ERP.Domain.Purchases.Enum;
using Anchi.ERP.Domain.Repairs.Enum;
using Anchi.ERP.Domain.Suppliers;
using Anchi.ERP.Domain.Users;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Domain.Purchases
{
    /// <summary>
    /// 采购单
    /// </summary>
    public class PurchaseOrder : BaseDomain
    {
        /// <summary>
        /// 供应商
        /// </summary>
        public Supplier Supplier
        {
            get; set;
        }

        /// <summary>
        /// 采购人
        /// </summary>
        public User User
        {
            get; set;
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 采购单状态
        /// </summary>
        public EnumPurchaseOrderStatus Status
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
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }

        private IList<PurchaseOrderProduct> productList;
        /// <summary>
        /// 采购产品
        /// </summary>
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
