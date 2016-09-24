using Anchi.ERP.Common.Extensions;
using Anchi.ERP.Domain.Products.Enum;
using System;

namespace Anchi.ERP.ServiceModel.Products
{
    /// <summary>
    /// 配件出入库记录实体
    /// </summary>
    public class ProductStockRecordModel
    {
        /// <summary>
        /// 出入库记录ID
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// 配件编码
        /// </summary>
        public string ProductCode
        {
            get; set;
        }

        /// <summary>
        /// 配件名称
        /// </summary>
        public string ProductName
        {
            get; set;
        }

        /// <summary>
        /// 当前库存数量
        /// </summary>
        public int Stock
        {
            get; set;
        }

        /// <summary>
        /// 出入库时间
        /// </summary>
        public DateTime RecordOn
        {
            get; set;
        }

        /// <summary>
        /// 出入库前库存数量
        /// </summary>
        public int QuantityBefore
        {
            get; set;
        }

        /// <summary>
        /// 本次出入库数量
        /// </summary>
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 出入库类型
        /// </summary>
        public EnumStockRecordType Type
        {
            get; set;
        }

        /// <summary>
        /// 出入库类型名称
        /// </summary>
        public string TypeName
        {
            get
            {
                return Type.GetDisplayName();
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }
    }
}
