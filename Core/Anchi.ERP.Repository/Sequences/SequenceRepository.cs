using Anchi.ERP.Domain.Sequences;
using Anchi.ERP.Domain.Sequences.Enum;
using Anchi.ERP.IRepository.Sequences;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Repository.Sequences
{
    /// <summary>
    /// 序列仓储层实现
    /// </summary>
    public class SequenceRepository : ISequenceRepository
    {
        #region 构造函数和属性
        private SequenceRepository()
        {
            // 在每次启动的时候从数据库读取出来当作初始值
            this.DbContext = new AnchiDbContext();
            using (var context = DbContext.Open())
            {
                SequenceList = context.Select<Sequence>();
            }
        }

        private IList<Sequence> SequenceList
        {
            get;
        }

        private AnchiDbContext DbContext
        {
            get;
        }

        #region 序列仓储层实例
        static object _instanceLocker = new object();
        static SequenceRepository repository = null;
        /// <summary>
        /// 序列仓储层实例
        /// </summary>
        public static SequenceRepository Instance
        {
            get
            {
                if (repository == null)
                {
                    lock (_instanceLocker)
                    {
                        if (repository == null)
                        {
                            repository = new SequenceRepository();
                        }
                    }
                }
                return repository;
            }
        }
        #endregion

        #endregion

        #region 获取序列的下一个值
        /// <summary>
        /// 获取序列的下一个值
        /// </summary>
        /// <param name="sequenceType"></param>
        /// <returns></returns>
        public long GetNextValue(EnumSequenceType sequenceType)
        {
            var sequence = SequenceList.FirstOrDefault(item => item.Type == sequenceType);
            if (sequence == null)
                throw new Exception(string.Format("暂不支持该类型序列：{0}", sequence));

            var sequenceValue = sequence.GetNextValue();

            // 保存到数据库
            SaveSequence(sequence);

            return sequenceValue;
        }
        #endregion

        #region 异步将变更保存到数据库
        /// <summary>
        /// 异步将变更保存到数据库
        /// </summary>
        /// <param name="model"></param>
        private void SaveSequence(Sequence model)
        {
            using (var context = DbContext.Open())
            {
                context.Update(model);
            }
        }
        #endregion
    }
}
