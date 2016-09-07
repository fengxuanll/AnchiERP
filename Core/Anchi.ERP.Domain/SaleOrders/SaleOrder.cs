using Anchi.ERP.Domain.Employees;
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
        /// 销售人ID
        /// </summary>
        [Required]
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
        /// 销售时间
        /// </summary>
        [Required]
        [StringLength(30)]
        public DateTime SaleOn
        {
            get; set;
        }

        /// <summary>
        /// 创建人Id
        /// </summary>
        [Required]
        public Guid CreatedById
        {
            get; set;
        }

        /// <summary>
        /// 发票号
        /// </summary>
        [StringLength(100)]
        public string InvoiceId
        {
            get; set;
        }

        private IList<SaleOrderItem> itemList;
        /// <summary>
        /// 销售配件列表
        /// </summary>
        [Ignore]
        public virtual IList<SaleOrderItem> ItemList
        {
            get
            {
                if (itemList == null)
                    itemList = new List<SaleOrderItem>();

                return itemList;
            }
            set
            {
                itemList = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(1000)]
        public string Remark
        {
            get; set;
        }
    }
}
