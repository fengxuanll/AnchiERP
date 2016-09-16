using Anchi.ERP.Common;
using Anchi.ERP.Repository.Purchases;
using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using Anchi.ERP.Domain.RepairOrder.Enum;
using Anchi.ERP.ServiceModel.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Service.Purchases
{
    /// <summary>
    /// 采购管理服务类
    /// </summary>
    public class PurchaseService : BaseService<PurchaseOrder>
    {
        #region 构造函数和属性
        public PurchaseService() : this(new PurchaseOrderRepository()) { }

        public PurchaseService(PurchaseOrderRepository purchaseOrderRepository) : base(purchaseOrderRepository)
        {
            this.PurchaseOrderRepository = purchaseOrderRepository;
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

            var temp = PurchaseOrderRepository.GetModel(model.Id);
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

        #region 结算采购单
        /// <summary>
        /// 结算采购单
        /// </summary>
        /// <param name="model"></param>
        public void Settlement(PurchaseSettlementModel model)
        {
            if (model == null)
                return;

            if (model.SettlementAmount <= 0)
                throw new Exception("请填写结算金额。");

            var order = PurchaseOrderRepository.GetModel(model.PurchaseOrderId);
            if (order == null)
                throw new Exception("采购单不存在。");

            if (order.Status != EnumPurchaseOrderStatus.Completed)
                throw new Exception("只能结算已全部到货的采购单。");

            if (order.SettlementStatus != EnumSettlementStatus.Waiting && order.SettlementStatus != EnumSettlementStatus.PartCompleted)
                throw new Exception("只能结算待结算的采购单。");

            order.SettlementOn = DateTime.Now;
            order.SettlementStatus = EnumSettlementStatus.Completed;
            order.SettlementAmount = model.SettlementAmount;
            order.SettlementRemark = model.SettlementRemark;

            PurchaseOrderRepository.UpdateModel(order);
        }
        #endregion

        #region 设置已到货
        /// <summary>
        /// 设置已到货
        /// </summary>
        /// <param name="Id"></param>
        public void SetArrival(IList<Guid> IdList)
        {
            if (IdList == null || !IdList.Any())
                return;

            foreach (var Id in IdList)
            {
                var order = PurchaseOrderRepository.GetModel(Id);
                if (order == null)
                    continue;

                if (order.Status != EnumPurchaseOrderStatus.Purchasing)
                    throw new Exception("只能将采购中的采购单设置为已到货。");

                PurchaseOrderRepository.SetArrival(order);
            }
        }
        #endregion
    }
}
