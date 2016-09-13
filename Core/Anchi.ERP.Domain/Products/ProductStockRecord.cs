using Anchi.ERP.Common;
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
        /// 配件ID
        /// </summary>
        [Required]
        [References(typeof(Product))]
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// 配件信息
        /// </summary>
        [Ignore]
        public Product Product
        {
            get; set;
        }

        private DateTime recordOn;
        /// <summary>
        /// 出入库时间
        /// </summary>
        [Required]
        public DateTime RecordOn
        {
            get
            {
                if (recordOn <= SqlDateTime.Min)
                    recordOn = SqlDateTime.Min;

                return recordOn;
            }
            set
            {
                recordOn = value;
            }
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
        public EnumStockRecordType Type
        {
            get; set;
        }
    }
}
