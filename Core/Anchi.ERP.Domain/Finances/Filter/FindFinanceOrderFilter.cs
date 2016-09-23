using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Finances.Enum;
using System.Text;

namespace Anchi.ERP.Domain.Finances.Filter
{
    /// <summary>
    /// 查找财务单筛选类
    /// </summary>
    public class FindFinanceOrderFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [FinanceOrder] fo WHERE 1 = 1");
                if (this.Type.HasValue)
                {
                    sb.Append(" AND fo.[Type] = @Type");
                    this.ParamDict["@Type"] = (int)this.Type.Value;
                }
                if (this.CreatedOn != null)
                {
                    if (this.CreatedOn.BeginTime.HasValue)
                    {
                        sb.Append(" AND fo.[CreatedOn] >= @CreatedOnStart");
                        this.ParamDict["@CreatedOnStart"] = this.CreatedOn.BeginTime.Value;
                    }
                    if (this.CreatedOn.EndTime.HasValue)
                    {
                        sb.Append(" AND fo.[CreatedOn] < @CreatedOnEnd");
                        this.ParamDict["@CreatedOnEnd"] = this.CreatedOn.EndTime.Value.Date.AddDays(1);
                    }
                }
                return sb.ToString();
            }
        }
        #endregion

        #region 财务单类型
        /// <summary>
        /// 财务单类型
        /// </summary>
        public EnumFinanceOrderType? Type
        {
            get; set;
        }
        #endregion

        #region 创建时间
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeFilter CreatedOn
        {
            get; set;
        }
        #endregion
    }
}
