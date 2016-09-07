using Anchi.ERP.Domain.RepairOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;

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
