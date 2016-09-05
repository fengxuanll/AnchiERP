using Anchi.ERP.Domain.Customers;
using Anchi.ERP.Domain.Repairs.Enum;
using System.Collections.Generic;

namespace Anchi.ERP.Domain.Repairs
{
    /// <summary>
    /// 维修单
    /// </summary>
    public class RepairOrder : BaseDomain
    {
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
        public Customer Customer
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

        private IList<RepairOrderItem> itemList;
        /// <summary>
        /// 维修项目列表
        /// </summary>
        public virtual IList<RepairOrderItem> ItemList
        {
            get
            {
                if (itemList == null)
                    itemList = new List<RepairOrderItem>();

                return itemList;
            }
            set
            {
                itemList = value;
            }
        }

        private IList<RepairProductItem> productList;
        /// <summary>
        /// 配件明细列表
        /// </summary>
        public virtual IList<RepairProductItem> ProductList
        {
            get
            {
                if (productList == null)
                    productList = new List<RepairProductItem>();

                return productList;
            }
            set
            {
                productList = value;
            }
        }
    }
}
