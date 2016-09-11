using Anchi.ERP.Data.SaleOrders;
using Anchi.ERP.Domain.RepairOrder.Enum;
using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.Domain.SaleOrders.Enum;
using Anchi.ERP.ServiceModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Service.SaleOrders
{
    /// <summary>
    /// 销售管理服务类
    /// </summary>
    public class SaleOrderService : BaseService<SaleOrder>
    {
        #region 构造函数和属性
        public SaleOrderService() : this(new SaleOrderRepository()) { }

        public SaleOrderService(SaleOrderRepository saleOrderRepository) : base(saleOrderRepository)
        {
            this.SaleOrderRepository = saleOrderRepository;
        }

        SaleOrderRepository SaleOrderRepository { get; }
        #endregion

        #region 保存销售单
        /// <summary>
        /// 保存销售单
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrUpdate(SaleOrder model)
        {
            if (model == null)
                return;

            if (model.CustomerId == Guid.Empty)
                throw new Exception("请选择客户。");

            if (model.SaleById == Guid.Empty)
                throw new Exception("请选择销售人。");

            if (!model.ProductList.Any())
                throw new Exception("请选择销售配件。");

            if (model.ProductList.Any(item => item.Quantity == 0))
                throw new Exception("请填写销售配件的数量。");

            model.Amount = model.ProductList.Sum(item => item.UnitPrice * item.Quantity);

            var temp = SaleOrderRepository.GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.Status = EnumSaleOrderStatus.Initial;
                model.SettlementStatus = EnumSettlementStatus.Waiting;
                model.CreatedOn = DateTime.Now;

                SaleOrderRepository.Create(model);
            }
            else
            {
                temp.CustomerId = model.CustomerId;
                temp.SaleById = model.SaleById;
                temp.SaleOn = model.SaleOn;
                temp.Remark = model.Remark;
                temp.ProductList = model.ProductList;

                SaleOrderRepository.Update(temp);
            }
        }
        #endregion

        #region 设置已出库
        /// <summary>
        /// 设置已出库
        /// </summary>
        /// <param name="IdList"></param>
        public void Outbound(IList<Guid> IdList)
        {
            if (IdList == null || !IdList.Any())
                return;

            foreach (var item in IdList)
            {
                var order = SaleOrderRepository.GetById(item);
                if (order == null)
                    continue;

                if (order.Status != EnumSaleOrderStatus.Initial)
                    throw new Exception("只有对待出库的财务单做出库操作。");

                SaleOrderRepository.Outbound(order);
            }
        }
        #endregion

        #region 结算销售单
        /// <summary>
        /// 结算销售单
        /// </summary>
        /// <param name="model"></param>
        public void Settlement(SaleSettlementModel model)
        {
            if (model == null)
                return;

            var order = SaleOrderRepository.GetModel(model.SaleOrderId);
            if (order == null)
                throw new Exception("销售单不存在。");

            if (order.Status != EnumSaleOrderStatus.Outbound)
                throw new Exception("只能结算已出库的销售单。");

            if (order.SettlementStatus == EnumSettlementStatus.Completed)
                throw new Exception("只能结算未结算的销售单。");

            order.SettlementOn = DateTime.Now;
            order.SettlementStatus = EnumSettlementStatus.Completed;
            order.SettlementAmount = model.SettlementAmount;
            order.SettlementRemark = model.SettlementRemark;

            SaleOrderRepository.UpdateModel(order);
        }
        #endregion
    }
}
