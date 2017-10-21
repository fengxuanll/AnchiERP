using Anchi.ERP.Common.Globalization;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Common.Units
{
    /// <summary>
    /// 长度单位
    /// </summary>
    [Serializable]
    public class Length : Object
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Length()
        {
            this.Unit = LengthUnit.cm;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        public Length(decimal value)
            : this()
        {
            this.Value = value;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="unit">单位</param>
        public Length(decimal value, LengthUnit unit)
            : this(value)
        {
            this.Unit = unit;
            this.Round();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="precision">精度</param>
        public Length(decimal value, int? precision)
            : this(value)
        {
            this.Precision = precision;
            this.Round();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="precision">精度</param>
        /// <param name="unit">单位</param>
        public Length(decimal value, int? precision, LengthUnit unit)
            : this(value)
        {
            this.Unit = unit;
            this.Precision = precision;
            this.Round();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="precision">精度</param>
        /// <param name="unit">单位</param>
        /// <param name="unit">指定数学舍入方法应如何处理两个数字间的中间值</param>
        public Length(decimal value, int? precision, LengthUnit unit, MidpointRounding rouding)
            : this(value)
        {
            this.Unit = unit;
            this.Precision = precision;
            this.Rounding = rouding;
            this.Round();
        }

        #endregion

        #region 字段属性

        /// <summary>
        /// 质量单位类型
        /// </summary>
        public virtual LengthUnit Unit
        {
            get;
            set;
        }

        /// <summary>
        /// 获取精度设置，如果不设置，则保留原Value的精度。
        /// </summary>
        public int? Precision
        {
            get;
            set;
        }

        /// <summary>
        /// 指定数学舍入方法应如何处理两个数字间的中间值。
        /// </summary>
        public MidpointRounding Rounding
        {
            get;
            set;
        }

        /// <summary>
        /// 值
        /// </summary>
        public decimal Value
        {
            get;
            set;
        }

        #endregion

        #region 单位转换

        /// <summary>
        /// 转换单位。
        /// 注意：坑因为精度问题，会导致转换后的Value四舍五入
        /// </summary>
        /// <param name="unit">目标单位</param>
        public void Conversion(LengthUnit unit)
        {
            this.Value = Conversion(this.Unit, unit, this.Value);
            this.Round();
            this.Unit = unit;
        }

        /// <summary>
        /// 转换单位。
        /// 注意：坑因为精度问题，会导致转换后的Value四舍五入
        /// </summary>
        /// <param name="unit">目标单位</param>
        /// <param name="precision">精度，如果是null，代表没有精度。</param>
        public void Conversion(LengthUnit unit, int? precision)
        {
            this.Precision = precision;
            this.Value = Conversion(this.Unit, unit, this.Value);
            this.Round();
            this.Unit = unit;
        }

        #endregion

        #region 重载

        public override bool Equals(object obj)
        {
            Length m = obj as Length;
            if (object.ReferenceEquals(this, m))
                return true;
            if (object.Equals(m, null))
                return false;
            return this.Value == Conversion(this.Unit, m.Unit, m.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.Value.ToString(), this.Unit.GetName());
        }

        #endregion

        #region 调整精度

        /// <summary>
        /// 调整精度
        /// </summary>
        protected void Round()
        {
            if (this.Precision.HasValue)
            {
                this.Value = decimal.Round(this.Value, this.Precision.Value, this.Rounding);
            }
        }

        /// <summary>
        /// 调整精度
        /// </summary>
        /// <param name="precision">精度</param>
        public void Round(int precision)
        {
            this.Precision = precision;
            this.Round();
        }

        /// <summary>
        /// 调整精度
        /// </summary>
        /// <param name="rounding">指定数学舍入方法应如何处理两个数字间的中间值。</param>
        public void Round(MidpointRounding rounding)
        {
            this.Rounding = rounding;
            this.Round();
        }

        /// <summary>
        /// 调整精度
        /// </summary>
        /// <param name="precision">精度</param>
        /// <param name="rounding">指定数学舍入方法应如何处理两个数字间的中间值。</param>
        public void Round(int precision, MidpointRounding rounding)
        {
            this.Precision = precision;
            this.Rounding = rounding;
            this.Round();
        }

        #endregion

        #region 运算符重载

        public static Length operator +(Length value1, Length value2)
        {
            return new Length(value1.Value + Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static Length operator -(Length value1, Length value2)
        {
            return new Length(value1.Value - Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static Length operator *(Length value1, Length value2)
        {
            return new Length(value1.Value * Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static Length operator /(Length value1, Length value2)
        {
            return new Length(value1.Value / Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static bool operator >(Length value1, Length value2)
        {
            if (object.Equals(value1, value2))
                return true;
            if (object.Equals(value1, null))
                return false;
            if (object.Equals(value2, null))
                return true;
            return value1.Value > Conversion(value1.Unit, value2.Unit, value2.Value);
        }

        public static bool operator <(Length value1, Length value2)
        {
            if (object.Equals(value1, value2))
                return true;
            if (object.Equals(value1, null))
                return true;
            if (object.Equals(value2, null))
                return false;
            return value1.Value < Conversion(value1.Unit, value2.Unit, value2.Value);
        }

        public static bool operator >=(Length value1, Length value2)
        {
            return !(value1 < value2);
        }

        public static bool operator <=(Length value1, Length value2)
        {
            return !(value1 > value2);
        }

        public static bool operator ==(Length value1, Length value2)
        {
            if (object.ReferenceEquals(value1, value2))
                return true;
            if (object.Equals(value1, null) || object.Equals(value2, null))
                return false;
            return value1.Value == Conversion(value1.Unit, value2.Unit, value2.Value);
        }

        public static bool operator !=(Length value1, Length value2)
        {
            if (object.ReferenceEquals(value1, value2))
                return false;
            if (object.Equals(value1, null) || object.Equals(value2, null))
                return true;
            return value1.Value != Conversion(value1.Unit, value2.Unit, value2.Value);
        }

        /// <summary>
        /// 单位换算
        /// </summary>
        /// <param name="sourceUnit">源单位</param>
        /// <param name="targetUnit">目标单位</param>
        /// <param name="sourceValue">源值</param>
        /// <returns>转成目标单位需要的倍数</returns>
        public static decimal Conversion(LengthUnit sourceUnit, LengthUnit targetUnit, decimal sourceValue = 1)
        {
            if (sourceUnit == targetUnit)
                return sourceValue;
            //设计思路：全部转为米的基数，然后再比较两个单位的差。  
            decimal conversionBase = Get_M_Base(sourceUnit) / Get_M_Base(targetUnit);
            sourceValue = sourceValue * conversionBase;
            return sourceValue;
        }

        static decimal[] m_Series_To_M_Base = null;
        //公制单位相对于米的进阶数。数组的下标就是各个单位枚举值。
        static decimal[] M_Series_To_M_Base
        {
            get
            {
                if (m_Series_To_M_Base == null)
                {
                    m_Series_To_M_Base = new decimal[] { 0.000000001m, 0.000001m, 0.001m, 0.01m, 0.1m, 1, 1000, 1000000, 1000000000, 1000000000000, 1000000000000000 };
                }
                return m_Series_To_M_Base;
            }
        }

        static decimal[] inch_Series_To_M_Base = null;
        //英制单位相对于米的进阶数。数组的下标就是各个单位枚举值。英制枚举值从100开始，所以枚举值和Inch_Series_To_M_Base下标的对应差100.
        static decimal[] Inch_Series_To_M_Base
        {
            get
            {
                if (inch_Series_To_M_Base == null)
                {
                    inch_Series_To_M_Base = new decimal[] { 0.0254m, 0.3048m, 0.9144m, 1609.344m };
                }
                return inch_Series_To_M_Base;
            }
        }

        /// <summary>
        /// 返回相对于米的进阶，即换算基数。
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        static decimal Get_M_Base(LengthUnit unit)
        {
            int unitInt = (int)unit;
            if (unitInt >= 0 && unitInt <= 99)
            {
                return M_Series_To_M_Base[unitInt];
            }
            unitInt = unitInt - 100;
            if (unitInt >= 0 && unitInt <= 99)
            {
                return Inch_Series_To_M_Base[unitInt];
            }
            throw new NotImplementedException(string.Format("没有实现单位：{0}的换算", unit.ToString()));
        }
        #endregion
    }

    /// <summary>
    /// 长度单位
    /// </summary>
    public enum LengthUnit
    {
        /// <summary>
        /// 纳米：10^-9
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        nm = 0,

        /// <summary>
        /// 微米：10^-6
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        um = 1,

        /// <summary>
        /// 毫米：10^-3
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        mm = 2,

        /// <summary>
        /// 厘米：10^-2
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        cm = 3,

        /// <summary>
        /// 分米：10^-1
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        dm = 4,

        /// <summary>
        /// 米：10^0
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        m = 5,

        /// <summary>
        /// 千米：10^3
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        km = 6,

        /// <summary>
        /// 兆米：10^6
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        Mm = 7,

        /// <summary>
        /// 京米：10^9
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        Gm = 8,

        /// <summary>
        /// 太米：10^12
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        Tm = 9,

        /// <summary>
        /// 拍米：10^15
        /// </summary>
        /// <remarks>
        /// 公制
        /// </remarks>
        Pm = 10,

        /// <summary>
        /// 英寸
        /// </summary>
        /// <remarks>
        /// 英制
        /// </remarks>
        inch = 100,

        /// <summary>
        /// 英尺
        /// </summary>
        /// <remarks>
        /// 英制
        /// </remarks>
        foot = 101,

        /// <summary>
        /// 码
        /// </summary>
        /// <remarks>
        /// 英制
        /// </remarks>
        yard = 102,

        /// <summary>
        /// 英里
        /// </summary>
        /// <remarks>
        /// 英制
        /// </remarks>
        mile = 103,

        //英制：英寸 in，英尺 ft,码 yd，英里 mi，海里 nmi，英寻 fm，弗隆 fur
        //市制：里，丈，尺，寸，分，厘，毫
    }

    /// <summary>
    /// 长度单位类型拓展
    /// </summary>
    public static class LengthUnitExtension
    {
        static Dictionary<LengthUnit, GlobalString> unitNameDict = null;
        static Dictionary<LengthUnit, GlobalString> UnitNameDict
        {
            get
            {
                if (unitNameDict == null)
                {
                    unitNameDict = new Dictionary<LengthUnit, GlobalString>();
                    #region 纳米
                    unitNameDict[LengthUnit.nm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.nm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "纳米"), new LocalString(LanguageCodes.EN, "nm"));
                    #endregion
                    #region 微米
                    unitNameDict[LengthUnit.um] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.um].AddOrUpdate(new LocalString(LanguageCodes.ZH, "微米"), new LocalString(LanguageCodes.EN, "um"));
                    #endregion
                    #region 毫米
                    unitNameDict[LengthUnit.mm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.mm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "毫米"), new LocalString(LanguageCodes.EN, "mm"));
                    #endregion
                    #region 厘米
                    unitNameDict[LengthUnit.cm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.cm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "厘米"), new LocalString(LanguageCodes.EN, "cm"));
                    #endregion
                    #region 分米
                    unitNameDict[LengthUnit.dm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.dm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "分米"), new LocalString(LanguageCodes.EN, "dm"));
                    #endregion
                    #region 米
                    unitNameDict[LengthUnit.m] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.m].AddOrUpdate(new LocalString(LanguageCodes.ZH, "米"), new LocalString(LanguageCodes.EN, "m"));
                    #endregion
                    #region 千米
                    unitNameDict[LengthUnit.km] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.km].AddOrUpdate(new LocalString(LanguageCodes.ZH, "千米"), new LocalString(LanguageCodes.EN, "km"));
                    #endregion
                    #region 兆米
                    unitNameDict[LengthUnit.Mm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.Mm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "兆米"), new LocalString(LanguageCodes.EN, "Mm"));
                    #endregion
                    #region 京米
                    unitNameDict[LengthUnit.Gm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.Gm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "京米"), new LocalString(LanguageCodes.EN, "Gm"));
                    #endregion
                    #region 太米
                    unitNameDict[LengthUnit.Tm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.Tm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "太米"), new LocalString(LanguageCodes.EN, "Tm"));
                    #endregion
                    #region 拍米
                    unitNameDict[LengthUnit.Pm] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.Pm].AddOrUpdate(new LocalString(LanguageCodes.ZH, "拍米"), new LocalString(LanguageCodes.EN, "Pm"));
                    #endregion
                    #region 英寸
                    unitNameDict[LengthUnit.inch] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.inch].AddOrUpdate(new LocalString(LanguageCodes.ZH, "英寸"), new LocalString(LanguageCodes.EN, "in"));
                    #endregion
                    #region 英尺
                    unitNameDict[LengthUnit.foot] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.foot].AddOrUpdate(new LocalString(LanguageCodes.ZH, "英尺"), new LocalString(LanguageCodes.EN, "ft"));
                    #endregion
                    #region 码
                    unitNameDict[LengthUnit.yard] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.yard].AddOrUpdate(new LocalString(LanguageCodes.ZH, "码"), new LocalString(LanguageCodes.EN, "yd"));
                    #endregion
                    #region 英里
                    unitNameDict[LengthUnit.mile] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[LengthUnit.mile].AddOrUpdate(new LocalString(LanguageCodes.ZH, "英里"), new LocalString(LanguageCodes.EN, "mi"));
                    #endregion
                }
                return unitNameDict;
            }
        }

        /// <summary>
        /// 获取单位的多语言描述
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string GetName(this LengthUnit unit)
        {
            if (UnitNameDict.ContainsKey(unit))
                return UnitNameDict[unit].GetValue();
            return unit.ToString();
        }
    }
}
