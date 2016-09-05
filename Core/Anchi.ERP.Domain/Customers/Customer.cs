using Anchi.ERP.Domain.Cars;
using System.Collections.Generic;

namespace Anchi.ERP.Domain.Customers
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class Customer : BaseDomain
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get; set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
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

        private IList<Car> carList;
        /// <summary>
        /// 车辆信息
        /// </summary>
        public virtual IList<Car> CarList
        {
            get
            {
                if (carList == null)
                    carList = new List<Car>();

                return carList;
            }
            set
            {
                carList = value;
            }
        }
    }
}
