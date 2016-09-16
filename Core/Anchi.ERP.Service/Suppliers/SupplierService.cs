using Anchi.ERP.Repository.Suppliers;
using Anchi.ERP.Domain.Suppliers;
using System;

namespace Anchi.ERP.Service.Suppliers
{
    /// <summary>
    /// 供应商管理服务类
    /// </summary>
    public class SupplierService : BaseService<Supplier>
    {
        #region 构造函数和属性
        public SupplierService() : this(new SupplierRepository()) { }

        public SupplierService(SupplierRepository supplierRepository) : base(supplierRepository)
        {
            this.SupplierRepository = supplierRepository;
        }

        SupplierRepository SupplierRepository { get; }
        #endregion

        #region 保存供应商
        /// <summary>
        /// 保存供应商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Supplier SaveOrUpdate(Supplier model)
        {
            if (model == null)
                throw new Exception("提交数据错误。");

            if (string.IsNullOrWhiteSpace(model.CompanyName))
                throw new Exception("请输入供应商名称。");

            var temp = GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                SupplierRepository.Create(model);
            }
            else
            {
                SupplierRepository.Update(model);
            }
            return model;
        }
        #endregion
    }
}
