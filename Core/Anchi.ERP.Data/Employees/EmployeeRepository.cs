using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Employees.Enum;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Data.Employees
{
    /// <summary>
    /// 员工仓储类
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>
    {
        #region 根据状态获取员工列表
        /// <summary>
        /// 根据状态获取员工列表
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public IList<Employee> GetListByStatus(EnumEmployeeStatus status)
        {
            using (var db = DbFactory.Open())
            {
                return db.Select<Employee>(item => item.Status == status);
            }
        }
        #endregion
    }
}
