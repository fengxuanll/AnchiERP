using Anchi.ERP.Data.Customers;
using Anchi.ERP.Domain.Customers;
using System;

namespace Anchi.ERP.Service.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerService : BaseService<Customer>
    {
        public CustomerService() : this(new CustomerRepository())
        { }

        public CustomerService(CustomerRepository customerRepository)
        {
            this.CustomerRepository = customerRepository;
            base.Repository = customerRepository;
        }

        CustomerRepository CustomerRepository
        { get; }

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

            var temp = GetById(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                CustomerRepository.Create(model);
            }
            else
            {
                CustomerRepository.Update(model);
            }
            return model;
        }
        #endregion
    }
}
