using Anchi.ERP.Domain.RepairOrder;
using ServiceStack.OrmLite;
using System;

namespace Anchi.ERP.Data.Repairs
{
    /// <summary>
    /// 
    /// </summary>
    public class RepairOrderRepository : BaseRepository<RepairOrder>
    {
        #region 构造函数和属性
        public RepairOrderRepository() : this(new RepairOrderItemRepository(), new RepairProductItemRepository()) { }

        public RepairOrderRepository(RepairOrderItemRepository repairOrderItemRepository, RepairProductItemRepository repairProductItemRepository)
        {
            this.RepairOrderItemRepository = repairOrderItemRepository;
            this.RepairProductItemRepository = repairProductItemRepository;
        }

        RepairOrderItemRepository RepairOrderItemRepository
        {
            get;
        }

        RepairProductItemRepository RepairProductItemRepository
        {
            get;
        }
        #endregion

        #region 创建维修单
        /// <summary>
        /// 创建维修单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(RepairOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    model.CreatedOn = DateTime.Now;
                    db.Insert(model);
                    // 插入维修项目
                    foreach (var item in model.ItemList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }
                    // 插入使用配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 修改维修单
        /// <summary>
        /// 修改维修单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int Update(RepairOrder model)
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

        #region 获取维修单
        /// <summary>
        /// 获取维修单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override RepairOrder GetById(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                return null;
            }
        }
        #endregion
    }
}
