using Anchi.ERP.Data.Projects;
using Anchi.ERP.Domain.RepairOrder;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Data.Repairs
{
    /// <summary>
    /// 维修单项目仓储层
    /// </summary>
    public class RepairOrderItemRepository : BaseRepository<RepairOrderItem>
    {
        #region 构造函数和属性
        public RepairOrderItemRepository() : this(new ProjectRepository()) { }
        public RepairOrderItemRepository(ProjectRepository projectRepository)
        {
            this.ProjectRepository = projectRepository;
        }

        ProjectRepository ProjectRepository { get; }
        #endregion

        #region 根据维修单ID获取项目列表
        /// <summary>
        /// 根据维修单ID获取项目列表
        /// </summary>
        /// <param name="repairOrderId"></param>
        /// <returns></returns>
        public IList<RepairOrderItem> Find(Guid repairOrderId)
        {
            IList<RepairOrderItem> modelList = null;
            using (var db = DbFactory.Open())
            {
                modelList = db.Select<RepairOrderItem>(item => item.RepairOrderId == repairOrderId);
            }
            modelList = modelList ?? new List<RepairOrderItem>();

            foreach (var model in modelList)
            {
                model.Project = ProjectRepository.GetById(model.ProjectId);
            }

            return modelList;
        }
        #endregion  
    }
}
