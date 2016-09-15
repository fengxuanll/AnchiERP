using Anchi.ERP.Data.Repository.Projects;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrders.Filter;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Data.Repository.Repairs
{
    /// <summary>
    /// 维修单项目仓储层
    /// </summary>
    public class RepairOrderProjectRepository : BaseRepository<RepairOrderProject>
    {
        #region 构造函数和属性
        public RepairOrderProjectRepository() : this(new ProjectRepository()) { }
        public RepairOrderProjectRepository(ProjectRepository projectRepository)
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
        public IList<RepairOrderProject> Find(Guid repairOrderId)
        {
            var filter = new FindRepairOrderProjectFilter();
            filter.RepairOrderId = repairOrderId;
            var modelList = base.Find<RepairOrderProject>(filter);
            foreach (var model in modelList)
            {
                model.Project = ProjectRepository.Get(model.ProjectId);
            }
            return modelList;
        }
        #endregion  
    }
}
