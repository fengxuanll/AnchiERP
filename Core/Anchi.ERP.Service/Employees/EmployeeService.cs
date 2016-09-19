using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Employees.Enum;
using Anchi.ERP.Domain.Employees.Filter;
using Anchi.ERP.IRepository.Employees;
using Anchi.ERP.Repository.Employees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Service.Employees
{
    /// <summary>
    /// 员工管理服务类
    /// </summary>
    public class EmployeeService : BaseService<Employee>
    {
        #region 构造函数和属性
        public EmployeeService() : this(new EmployeeRepository()) { }

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }

        IEmployeeRepository EmployeeRepository { get; }
        #endregion

        #region 保存员工
        /// <summary>
        /// 保存员工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Employee SaveOrUpdate(Employee model)
        {
            if (model == null)
                throw new Exception("提交数据错误。");

            if (string.IsNullOrWhiteSpace(model.Code))
                throw new Exception("请输入员工编码。");

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("请输入员工姓名。");

            var temp = GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                model.Status = EnumEmployeeStatus.Normal;
                this.EmployeeRepository.Create(model);
            }
            else
            {
                temp.Code = model.Code;
                temp.Name = model.Name;
                temp.EntryOn = model.EntryOn;
                temp.IDCard = model.IDCard;
                temp.Tel = model.Tel;
                temp.Address = model.Address;
                temp.Remark = model.Remark;

                this.EmployeeRepository.Update(temp);
            }
            return model;
        }
        #endregion

        #region 获取所有在职的员工
        /// <summary>
        /// 获取所有在职的员工
        /// </summary>
        /// <returns></returns>
        public IList<Employee> FindNormalList()
        {
            var filter = new FindEmployeeFilter();
            filter.Status = EnumEmployeeStatus.Normal;
            return this.EmployeeRepository.Find<Employee>(filter);
        }
        #endregion

        #region 批量启用员工
        /// <summary>
        /// 批量启用员工
        /// </summary>
        /// <param name="idList"></param>
        public void EnableEmployee(IList<Guid> idList)
        {
            if (idList == null || !idList.Any())
                return;

            foreach (var id in idList)
            {
                var model = EmployeeRepository.Get(id);
                if (model == null)
                    continue;

                model.Status = EnumEmployeeStatus.Normal;
                this.EmployeeRepository.Update(model);
            }
        }
        #endregion

        #region 批量停用员工
        /// <summary>
        /// 批量停用员工
        /// </summary>
        /// <param name="idList"></param>
        public void DisableEmployee(IList<Guid> idList)
        {
            if (idList == null || !idList.Any())
                return;

            foreach (var id in idList)
            {
                var model = EmployeeRepository.Get(id);
                if (model == null)
                    continue;

                model.Status = EnumEmployeeStatus.Disable;
                this.EmployeeRepository.Update(model);
            }
        }
        #endregion
    }
}
