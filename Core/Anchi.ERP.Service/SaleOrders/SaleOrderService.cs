using Anchi.ERP.Data.SaleOrders;
using Anchi.ERP.Domain.SaleOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
