using Anchi.ERP.Data.Repairs;
using Anchi.ERP.Domain.RepairOrder;
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


    }
}
