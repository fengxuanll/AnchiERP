using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Employees.Enum;
using System;
using System.Text;

namespace Anchi.ERP.Domain.Employees.Filter
{
    /// <summary>
    /// 查找员工筛选类
    /// </summary>
    public class FindEmployeeFilter : PagedQueryFilter
    {
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [Employee] WHERE 1 = 1");

                if (!string.IsNullOrWhiteSpace(this.Code))
                {
                    sb.Append(" AND [Code] = @Code");
                    this.ParamDict["@Code"] = this.Code;
                }
                if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    sb.Append(" AND [Name] = @Name");
                    this.ParamDict["@Name"] = this.Name;
                }
                if (this.Status.HasValue)
                {
                    sb.Append(" AND [Status] = @Status");
                    this.ParamDict["@Status"] = (int)this.Status.Value;
                }
                if (this.EntryOn.HasValue)
                {
                    sb.Append(" AND [EntryOn] >= @EntryOnStart AND [EntryOn] < @EntryOnEnd");
                    this.ParamDict["@EntryOnStart"] = this.EntryOn.Value.Date;
                    this.ParamDict["@EntryOnEnd"] = this.EntryOn.Value.Date.AddDays(1);
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 员工状态
        /// </summary>
        public EnumEmployeeStatus? Status { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? EntryOn { get; set; }
    }
}
