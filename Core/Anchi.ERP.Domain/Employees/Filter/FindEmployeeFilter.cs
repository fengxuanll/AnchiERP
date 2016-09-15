using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Employees.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchi.ERP.Domain.Employees.Filter
{
    public class FindEmployeeFilter : PagedQueryFilter
    {
        public override string SQL
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 员工状态
        /// </summary>
        public EnumEmployeeStatus? Status
        { get; set; }
    }
}
