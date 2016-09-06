using Anchi.ERP.Data.Employees;
using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Employees.Enum;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Service.Employees
{
    /// <summary>
    /// 员工服务类
    /// </summary>
    public class EmployeeService : BaseService<Employee>
    {
        #region 构造函数和属性
        public EmployeeService() : this(new EmployeeRepository())
        {
        }

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
            base.Repository = employeeRepository;
        }

        EmployeeRepository EmployeeRepository
        {
            get;
        }
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

            var temp = GetById(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                model.Status = EnumEmployeeStatus.Normal;
                EmployeeRepository.Create(model);
            }
            else
            {
                EmployeeRepository.Update(model);
            }
            return model;
        }
        #endregion

        #region 获取所有在职的员工
        /// <summary>
        /// 获取所有在职的员工
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetNormalList()
        {
            return EmployeeRepository.GetListByStatus(EnumEmployeeStatus.Normal);
        }
        #endregion
    }
}
