namespace Anchi.ERP.Common.Excel
{
    /// <summary>
    /// Excel列验证项
    /// </summary>
    public class ColumnValidItem
    {
        private string _Name;
        private string _DataModelName;
        private EnumItemType _ItemType;
        private EnumValueType _ValueType;
        private string _DropDownSource;
        private string _DropDownValue;
        private EnumValidType _ValidType;
        private EnumValidQualifier _ValidQualifier;
        private string _ValidMax;
        private string _ValidMin;
        private string _ValidFormula;
        private string _InputMessage;
        private string _ErrorMessage;
        private int _Width = -1;
        private string _Remarks;
        private int _Order;

        /// <summary>
        /// 项名称 
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (this._Name != value)
                    this._Name = value;
            }
        }

        /// <summary>
        /// 项对应实体类的字段名 
        /// </summary>
        public string DataModelName
        {
            get
            {
                return _DataModelName;
            }
            set
            {
                if (this._DataModelName != value)
                    this._DataModelName = value;
            }
        }

        /// <summary>
        /// 项类型 
        /// </summary>
        public EnumItemType ItemType
        {
            get
            {
                return _ItemType;
            }
            set
            {
                if (this._ItemType != value)
                    this._ItemType = value;
            }
        }

        /// <summary>
        /// 值类型 
        /// </summary>
        public EnumValueType ValueType
        {
            get
            {
                return _ValueType;
            }
            set
            {
                if (this._ValueType != value)
                    this._ValueType = value;
            }
        }

        /// <summary>
        /// 下拉列表对应Code表Type(也当作动态生成字段) 
        /// </summary>
        public string DropDownSource
        {
            get
            {
                return _DropDownSource;
            }
            set
            {
                if (this._DropDownSource != value)
                    this._DropDownSource = value;
            }
        }

        /// <summary>
        /// 下拉列表项数据 
        /// </summary>
        public string DropDownValue
        {
            get
            {
                return _DropDownValue;
            }
            set
            {
                if (this._DropDownValue != value)
                    this._DropDownValue = value;
            }
        }

        /// <summary>
        /// 验证类型 
        /// </summary>
        public EnumValidType ValidType
        {
            get
            {
                return _ValidType;
            }
            set
            {
                if (this._ValidType != value)
                    this._ValidType = value;
            }
        }

        /// <summary>
        /// 数据关系 
        /// </summary>
        public EnumValidQualifier ValidQualifier
        {
            get
            {
                return _ValidQualifier;
            }
            set
            {
                if (this._ValidQualifier != value)
                    this._ValidQualifier = value;
            }
        }

        /// <summary>
        /// 数据最大值 
        /// </summary>
        public string ValidMax
        {
            get
            {
                return _ValidMax;
            }
            set
            {
                if (this._ValidMax != value)
                    this._ValidMax = value;
            }
        }

        /// <summary>
        /// 数据最小值 
        /// </summary>
        public string ValidMin
        {
            get
            {
                return _ValidMin;
            }
            set
            {
                if (this._ValidMin != value)
                    this._ValidMin = value;
            }
        }

        /// <summary>
        /// 自定义验证公式 
        /// </summary>
        public string ValidFormula
        {
            get
            {
                return _ValidFormula;
            }
            set
            {
                if (this._ValidFormula != value)
                    this._ValidFormula = value;
            }
        }

        /// <summary>
        /// 输入时提醒信息 
        /// </summary>
        public string InputMessage
        {
            get
            {
                return _InputMessage;
            }
            set
            {
                if (this._InputMessage != value)
                    this._InputMessage = value;
            }
        }

        /// <summary>
        /// 错误时提醒信息 
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                if (this._ErrorMessage != value)
                    this._ErrorMessage = value;
            }
        }

        /// <summary>
        /// 宽度 
        /// </summary>
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (this._Width != value)
                    this._Width = value;
            }
        }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                if (this._Remarks != value)
                    this._Remarks = value;
            }
        }

        /// <summary>
        /// 排序 
        /// </summary>
        public int Order
        {
            get
            {
                return _Order;
            }
            set
            {
                if (this._Order != value)
                    this._Order = value;
            }
        }
    }

    #region 导出验证项-类型
    /// <summary>
    /// 导出验证项-类型
    /// </summary>
    public enum EnumItemType
    {
        /// <summary>
        /// 必有项
        /// </summary>
        MustHave = 0,
        /// <summary>
        /// 必填项
        /// </summary>
        MustFill = 1,
        /// <summary>
        /// 选填项
        /// </summary>
        SelectFill = 2
    }
    #endregion

    #region 导出验证项-值类型
    /// <summary>
    /// 导出验证项-值类型
    /// </summary>
    public enum EnumValueType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        String = 0,
        /// <summary>
        /// 数字
        /// </summary>
        Number = 1,
        /// <summary>
        /// 日期
        /// </summary>
        DateTime = 2,
        /// <summary>
        /// 列表
        /// </summary>
        List = 3
    }
    #endregion

    #region 导出验证项-验证类型
    /// <summary>
    /// 导出验证项-验证类型
    /// </summary>
    public enum EnumValidType
    {
        /// <summary>
        /// 任何值
        /// </summary>
        AnyValue = 0,
        /// <summary>
        /// 整数
        /// </summary>
        Integer = 1,
        /// <summary>
        /// 小数
        /// </summary>
        Decimal = 2,
        /// <summary>
        /// 序列
        /// </summary>
        List = 3,
        /// <summary>
        /// 日期
        /// </summary>
        DateTime = 4,
        /// <summary>
        /// 时间
        /// </summary>
        Time = 5,
        /// <summary>
        /// 文本长度
        /// </summary>
        TextLength = 6,
        /// <summary>
        /// 自定义
        /// </summary>
        Customize = 7
    }
    #endregion

    #region 导出验证项-数据关系
    /// <summary>
    /// 导出验证项-数据关系
    /// </summary>
    public enum EnumValidQualifier
    {
        /// <summary>
        /// 介于
        /// </summary>
        Between = 0,
        /// <summary>
        /// 未介于
        /// </summary>
        NotBetween = 1,
        /// <summary>
        /// 等于
        /// </summary>
        Equal = 2,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual = 3,
        /// <summary>
        /// 大于
        /// </summary>
        MoreThan = 4,
        /// <summary>
        /// 小于
        /// </summary>
        LessThan = 5,
        /// <summary>
        /// 大于或等于
        /// </summary>
        MoreThanOrEqual = 6,
        /// <summary>
        /// 小于或等于
        /// </summary>
        LessThanOrEqual = 7
    }
    #endregion
}
