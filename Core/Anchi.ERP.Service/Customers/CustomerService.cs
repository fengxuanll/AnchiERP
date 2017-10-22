using Anchi.ERP.Domain.Customers;
using Anchi.ERP.IRepository.Customers;
using Anchi.ERP.Repository.Customers;
using System;

namespace Anchi.ERP.Service.Customers
{
    /// <summary>
    /// 客户管理服务层
    /// </summary>
    public class CustomerService : BaseService<Customer>
    {
        #region 构造函数和属性
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            this.CustomerRepository = customerRepository;
        }

        ICustomerRepository CustomerRepository { get; }
        #endregion

        #region 保存用户
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Customer SaveOrUpdate(Customer model)
        {
            if (model == null)
                throw new Exception("提交数据错误。");

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("请输入客户姓名。");

            var temp = GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                this.CustomerRepository.Create(model);
            }
            else
            {
                temp.Address = model.Address;
                temp.CarNumber = model.CarNumber;
                temp.Name = model.Name;
                temp.Remark = model.Remark;
                temp.Tel = model.Tel;

                this.CustomerRepository.Update(temp);
            }
            return model;
        }
        #endregion
    }
}
