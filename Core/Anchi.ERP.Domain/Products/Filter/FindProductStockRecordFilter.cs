using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Products.Enum;
using System.Text;

namespace Anchi.ERP.Domain.Products.Filter
{
    /// <summary>
    /// 查找配件库存记录筛选器
    /// </summary>
    public class FindProductStockRecordFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT psr.* FROM [ProductStockRecord] psr JOIN [Product] p ON psr.ProductId = p.Id WHERE 1 = 1");

                if (!string.IsNullOrWhiteSpace(this.Code))
                {
                    sb.Append(" AND CHARINDEX(@Code, [Code])");
                    this.ParamDict["@Code"] = this.Code;
                }
                if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    sb.Append(" AND CHARINDEX(@Name, [Name])");
                    this.ParamDict["@Name"] = this.Name;
                }
                if (this.RecordOn != null)
                {
                    if (this.RecordOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND psr.[RecordOn] >= @RecordOnStart");
                        this.ParamDict["@RecordOnStart"] = this.RecordOn.BeginTime.Value;
                    }
                    if (this.RecordOn.EndTime.HasValue)
                    {
                        sb.Append(" AND psr.[RecordOn] < @RecordOnEnd");
                        this.ParamDict["@RecordOnEnd"] = this.RecordOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                if (this.Type.HasValue)
                {
                    sb.Append(" AND psr.[Type] = @Type");
                    this.ParamDict["@Type"] = (byte)this.Type.Value;
                }

                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 配件编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 配件名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTimeFilter RecordOn
        {
            get; set;
        }

        /// <summary>
        /// 库存记录类型
        /// </summary>
        public EnumStockRecordType? Type
        {
            get; set;
        }
    }
}
