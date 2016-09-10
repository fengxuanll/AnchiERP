using Anchi.ERP.Common;
using Anchi.ERP.Data.Purchases;
using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using Anchi.ERP.Domain.RepairOrder.Enum;
using System;
using System.Linq;

namespace Anchi.ERP.Service.Purchases
{
    /// <summary>
    /// 采购服务类
    /// </summary>
    public class PurchaseService : BaseService<PurchaseOrder>
    {
        #region 构造函数和属性
        public PurchaseService() : this(new PurchaseOrderRepository()) { }

        public PurchaseService(PurchaseOrderRepository purchaseOrderRepository)
        {
            this.PurchaseOrderRepository = purchaseOrderRepository;
            base.Repository = purchaseOrderRepository;
        }

        PurchaseOrderRepository PurchaseOrderRepository
        {
            get;
        }
        #endregion

        #region 保存采购单
        /// <summary>
        /// 保存采购单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PurchaseOrder SaveOrUpdate(PurchaseOrder model)
        {
            if (model.SupplierId == Guid.Empty)
                throw new Exception("请选择供应商。");

            if (model.PurchaseById == Guid.Empty)
                throw new Exception("请选择采购人。");

            if (!model.ProductList.Any())
                throw new Exception("请选择采购配件。");

            if (model.ProductList.Any(item => item.Quantity == 0))
                throw new Exception("请填写采购配件的数量。");

            model.Amount = model.ProductList.Sum(item => item.UnitPrice * item.Quantity);

            var temp = GetById(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                model.Status = EnumPurchaseOrderStatus.Purchasing;
                model.SettlementStatus = EnumSettlementStatus.Waiting;
                PurchaseOrderRepository.Create(model);
            }
            else
            {
                model.CreatedOn = model.CreatedOn > SqlDateTime.Min ? model.CreatedOn : temp.CreatedOn;
                model.Status = model.Status == 0 ? temp.Status : model.Status;
                model.SettlementStatus = model.SettlementStatus == 0 ? temp.SettlementStatus : model.SettlementStatus;
                PurchaseOrderRepository.Update(model);
            }

            return model;
        }
        #endregion
    }
}
