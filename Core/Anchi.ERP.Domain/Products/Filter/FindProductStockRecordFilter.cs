using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Products.Enum;
using System;
using System.Text;

namespace Anchi.ERP.Domain.Products.Filter
{
    /// <summary>
    /// 查找配件库存记录筛选器
    /// </summary>
    public class FindProductStockRecordFilter : PagedQueryFilter
    {
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                // TODO...... 关联查询，待测试
                var sb = new StringBuilder("SELECT psr.* FROM [ProductStockRecord] psr JOIN [Product] p ON psr.ProductId = p.Id WHERE 1 = 1");

                if (!string.IsNullOrWhiteSpace(this.Code))
                {
                    sb.Append(" AND p.[Code] = @Code");
                    this.ParamDict["@Code"] = this.Code;
                }
                if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    sb.Append(" AND p.[Name] = @Name");
                    this.ParamDict["@Name"] = this.Name;
                }
                if (this.RecordOn.HasValue)
                {
                    sb.Append(" AND psr.[RecordOn] = @RecordOn");
                    this.ParamDict["@RecordOn"] = this.RecordOn.Value;
                }
                if (this.Type.HasValue)
                {
                    sb.Append(" AND psr.[Type] = @Type");
                    this.ParamDict["@Type"] = (byte)this.Type.Value;
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 配件编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 配件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? RecordOn { get; set; }

        /// <summary>
        /// 库存记录类型
        /// </summary>
        public EnumStockRecordType? Type { get; set; }
    }
}
