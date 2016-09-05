using Anchi.ERP.Data.Suppliers;
using Anchi.ERP.Domain.Suppliers;
using System;

namespace Anchi.ERP.Service.Suppliers
{
    /// <summary>
    /// 
    /// </summary>
    public class SupplierService : BaseService<Supplier>
    {
        public SupplierService() : this(new SupplierRepository())
        { }

        public SupplierService(SupplierRepository supplierRepository)
        {
            this.SupplierRepository = supplierRepository;
            base.Repository = supplierRepository;
        }

        SupplierRepository SupplierRepository
        { get; }

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

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("请输入供应商名称。");

            var temp = GetById(model.Id);
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
