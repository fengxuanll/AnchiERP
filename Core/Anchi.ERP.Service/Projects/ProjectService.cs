using Anchi.ERP.Repository.Projects;
using Anchi.ERP.Domain.Projects;
using System;

namespace Anchi.ERP.Service.Projects
{
    /// <summary>
    /// 维修项目管理服务类
    /// </summary>
    public class ProjectService : BaseService<Project>
    {
        #region 构造函数和属性
        public ProjectService() : this(new ProjectRepository()) { }

        public ProjectService(ProjectRepository projectRepository) : base(projectRepository)
        {
            this.ProjectRepository = projectRepository;
        }

        ProjectRepository ProjectRepository { get; }
        #endregion

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

            var temp = GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                ProjectRepository.Create(model);
            }
            else
            {
                temp.Code = model.Code;
                temp.Name = model.Name;
                temp.Remark = model.Remark;
                temp.UnitPrice = model.UnitPrice;
                ProjectRepository.Update(temp);
            }
            return model;
        }
        #endregion
    }
}
