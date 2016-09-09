using Anchi.ERP.Common;
using Anchi.ERP.Data.Repairs;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrder.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        #region 创建数据
        /// <summary>
        /// 创建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RepairOrder Create(RepairOrder model)
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

            model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
            model.Amount = model.ItemList.Sum(item => item.UnitPrice * item.Quantity) + model.ProductList.Sum(item => item.UnitPrice * item.Quantity);
            model.SettlementStatus = model.SettlementStatus == 0 ? EnumSettlementStatus.Waiting : model.SettlementStatus;
            model.Status = model.Status == 0 ? EnumRepairOrderStatus.Repairing : model.Status;

            RepairOrderRepository.Create(model);
            return model;
        }
        #endregion
    }
}
