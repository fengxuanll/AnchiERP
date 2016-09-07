using Anchi.ERP.Data.Purchases;
using Anchi.ERP.Domain.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    }
}
