using Anchi.ERP.Common;
using Anchi.ERP.Data.Repairs;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrder.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Service.Repairs
{
    /// <summary>
    /// 维修单服务类
    /// </summary>
    public class RepairOrderService : BaseService<RepairOrder>
    {
        #region 构造函数和属性
        public RepairOrderService() : this(new RepairOrderRepository())
        {
        }

        public RepairOrderService(RepairOrderRepository repairOrderRepository)
        {
            this.RepairOrderRepository = repairOrderRepository;
            base.Repository = repairOrderRepository;
        }

        RepairOrderRepository RepairOrderRepository
        {
            get;
        }
        #endregion

        #region 创建维修单
        /// <summary>
        /// 创建维修单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RepairOrder SaveOrUpdate(RepairOrder model)
        {
            if (model.CustomerId == Guid.Empty)
                throw new Exception("请选择客户。");

            if (model.RepairOn <= SqlDateTime.Min)
                throw new Exception("请选择开单日期。");

            if (model.ReceptionById == Guid.Empty)
                throw new Exception("请选择接待人。");

            if (!model.ItemList.Any() && !model.ProductList.Any())
                throw new Exception("请选择维修项目和配件明细。");

            if (model.ItemList.Any(item => item.EmployeeId == Guid.Empty))
                throw new Exception("请选择维修项目的维修人。");

            model.Amount = model.ItemList.Sum(item => item.UnitPrice * item.Quantity) + model.ProductList.Sum(item => item.UnitPrice * item.Quantity);

            var temp = GetById(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.Status = EnumRepairOrderStatus.Repairing;
                model.SettlementStatus = EnumSettlementStatus.Waiting;
                model.CreatedOn = DateTime.Now;

                RepairOrderRepository.Create(model);
            }
            else
            {
                model.Status = model.Status == 0 ? temp.Status : model.Status;
                model.SettlementStatus = model.SettlementStatus == 0 ? temp.SettlementStatus : model.SettlementStatus;
                RepairOrderRepository.Update(model);
            }
            return model;
        }
        #endregion

        #region 设置维修单为已完工
        /// <summary>
        /// 设置维修单为已完工
        /// </summary>
        /// <param name="IdList"></param>
        public void SetComplete(IList<Guid> IdList)
        {
            if (IdList == null || !IdList.Any())
                return;

            foreach (var Id in IdList)
            {
                var model = GetById(Id);
                if (model == null)
                    return;

                if (model.Status != EnumRepairOrderStatus.Repairing)
                    throw new Exception("只能将维修中的维修单设置为已完工。");

                RepairOrderRepository.Complete(model);
            }
        }
        #endregion
    }
}
