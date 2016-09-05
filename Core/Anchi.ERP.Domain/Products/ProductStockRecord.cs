using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.Domain.Users;
using System;

namespace Anchi.ERP.Domain.Products
{
    /// <summary>
    /// 配件库存记录
    /// </summary>
    public class ProductStockRecord : BaseDomain
    {
        /// <summary>
        /// 配件
        /// </summary>
        public Product Product
        {
            get; set;
        }

        /// <summary>
        /// 操作之前的数量
        /// </summary>
        public int QuantityBefore
        {
            get; set;
        }

        /// <summary>
        /// 出入库数量
        /// </summary>
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 库存记录类型
        /// </summary>
        public EnumStockRecordType Type
        {
            get; set;
        }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime CreatedOn
        {
            get; set;
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public virtual User User
        {
            get; set;
        }
    }
}
