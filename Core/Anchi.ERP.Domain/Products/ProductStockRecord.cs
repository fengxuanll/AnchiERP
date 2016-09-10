using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Products.Enum;
using ServiceStack.DataAnnotations;
using System;

namespace Anchi.ERP.Domain.Products
{
    /// <summary>
    /// 配件库存记录
    /// </summary>
    public class ProductStockRecord : BaseDomain
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        [Required]
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// 操作之前的数量
        /// </summary>
        [Required]
        public int QuantityBefore
        {
            get; set;
        }

        /// <summary>
        /// 本次操作的出入库数量
        /// </summary>
        [Required]
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 库存记录类型
        /// </summary>
        [Required]
        [StringLength(50)]
        public EnumStockRecordType Type
        {
            get; set;
        }
    }
}
