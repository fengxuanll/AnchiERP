using Anchi.ERP.Data.Projects;
using Anchi.ERP.Domain.Projects;
using System;

namespace Anchi.ERP.Service.Projects
{
    public class ProjectService : BaseService<Project>
    {
        public ProjectService() : this(new ProjectRepository()) { }

        public ProjectService(ProjectRepository projectRepository)
        {
            this.ProjectRepository = projectRepository;
            base.Repository = projectRepository;
        }

        ProjectRepository ProjectRepository
        {
            get;
        }

        #region 保存维修项目
        /// <summary>
        /// 保存维修项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Project SaveOrUpdate(Project model)
        {
            if (model == null)
                throw new Exception("提交数据错误。");

            if (string.IsNullOrWhiteSpace(model.Code))
                throw new Exception("请输入项目编码。");

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("请输入项目名称。");

            if (model.UnitPrice <= 0)
                throw new Exception("请输入正确的项目单价，必须为大于0的数字。");

            var temp = GetById(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                ProjectRepository.Create(model);
            }
            else
            {
                ProjectRepository.Update(model);
            }
            return model;
        }
        #endregion
    }
}
