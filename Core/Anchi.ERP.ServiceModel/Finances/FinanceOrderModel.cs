using Anchi.ERP.Common.Extensions;
using Anchi.ERP.Domain.Finances.Enum;
using System;

namespace Anchi.ERP.ServiceModel.Finances
{
    /// <summary>
    /// 财务单列表实体
    /// </summary>
    public class FinanceOrderModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 关联Id
        /// </summary>
        public Guid RelationId
        {
            get; set;
        }

        /// <summary>
        /// 关联数据编码
        /// </summary>
        public string RelationCode
        {
            get; set;
        }

        /// <summary>
        /// 类型
        /// </summary>
        public EnumFinanceOrderType Type
        {
            get; set;
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            get
            {
                return Type.GetDisplayName();
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn
        {
            get; set;
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }
    }
}
