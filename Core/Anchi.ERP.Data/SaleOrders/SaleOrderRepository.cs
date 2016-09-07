using Anchi.ERP.Domain.SaleOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;

namespace Anchi.ERP.Data.SaleOrders
{
    /// <summary>
    /// 销售单仓储类
    /// </summary>
    public class SaleOrderRepository : BaseRepository<SaleOrder>
    {
        #region 构造函数和属性
        public SaleOrderRepository() : this(new SaleOrderItemRepository()) { }

        public SaleOrderRepository(SaleOrderItemRepository saleOrderItemRepository)
        {
            this.SaleOrderItemRepository = saleOrderItemRepository;
        }

        SaleOrderItemRepository SaleOrderItemRepository
        {
            get;
        }
        #endregion

        #region 创建销售单
        /// <summary>
        /// 创建销售单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(SaleOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    tran.Commit();
                }
            }
        }
        #endregion

        #region 修改销售单
        /// <summary>
        /// 修改销售单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int Update(SaleOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    tran.Commit();
                }
            }
            return 0;
        }
        #endregion

        #region 获取销售单信息
        /// <summary>
        /// 获取销售单信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override SaleOrder GetById(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                return null;
            }
        }
        #endregion
    }
}
