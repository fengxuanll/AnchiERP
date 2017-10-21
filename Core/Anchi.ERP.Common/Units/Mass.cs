using Anchi.ERP.Common.Globalization;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Common.Units
{
    /// <summary>
    /// 质量单位
    /// </summary>
    [Serializable]
    public class Mass : Object
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Mass()
        {
            this.Unit = MassUnit.g;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        public Mass(decimal value)
            : this()
        {
            this.Value = value;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="unit">单位</param>
        public Mass(decimal value, MassUnit unit)
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
        public Mass(decimal value, int? precision)
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
        public Mass(decimal value, int? precision, MassUnit unit)
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
        public Mass(decimal value, int? precision, MassUnit unit, MidpointRounding rouding)
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
        public virtual MassUnit Unit
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
        /// 注意：因为精度问题，会导致转换后的Value四舍五入
        /// </summary>
        /// <param name="unit">目标单位</param>
        public void Conversion(MassUnit unit)
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
        public void Conversion(MassUnit unit, int? precision)
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
            Mass m = obj as Mass;
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

        public static Mass operator +(Mass value1, Mass value2)
        {
            return new Mass(value1.Value + Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static Mass operator -(Mass value1, Mass value2)
        {
            return new Mass(value1.Value - Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static Mass operator *(Mass value1, Mass value2)
        {
            return new Mass(value1.Value * Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static Mass operator /(Mass value1, Mass value2)
        {
            return new Mass(value1.Value / Conversion(value1.Unit, value2.Unit, value2.Value), value1.Precision, value1.Unit, value1.Rounding);
        }

        public static bool operator >(Mass value1, Mass value2)
        {
            if (object.Equals(value1, value2))
                return true;
            if (object.Equals(value1, null))
                return false;
            if (object.Equals(value2, null))
                return true;
            return value1.Value > Conversion(value1.Unit, value2.Unit, value2.Value);
        }

        public static bool operator <(Mass value1, Mass value2)
        {
            if (object.Equals(value1, value2))
                return true;
            if (object.Equals(value1, null))
                return true;
            if (object.Equals(value2, null))
                return false;
            return value1.Value < Conversion(value1.Unit, value2.Unit, value2.Value);
        }

        public static bool operator >=(Mass value1, Mass value2)
        {
            return !(value1 < value2);
        }

        public static bool operator <=(Mass value1, Mass value2)
        {
            return !(value1 > value2);
        }

        public static bool operator ==(Mass value1, Mass value2)
        {
            if (object.ReferenceEquals(value1, value2))
                return true;
            if (object.Equals(value1, null) || object.Equals(value2, null))
                return false;
            return value1.Value == Conversion(value1.Unit, value2.Unit, value2.Value);
        }

        public static bool operator !=(Mass value1, Mass value2)
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
        public static decimal Conversion(MassUnit sourceUnit, MassUnit targetUnit, decimal sourceValue = 1)
        {
            if (sourceUnit == targetUnit)
                return sourceValue;
            //设计思路：全部转为KG的基数，然后再比较两个单位的差。  
            decimal conversionBase = Get_KG_Base(sourceUnit) / Get_KG_Base(targetUnit);
            sourceValue = sourceValue * conversionBase;
            return sourceValue;
        }

        static decimal[] kg_Series_To_KG_Base = null;
        //公制单位相对于千克的进阶数。数组的下标就是各个单位枚举值。
        static decimal[] KG_Series_To_KG_Base
        {
            get
            {
                if (kg_Series_To_KG_Base == null)
                {
                    //0表示现在不支持
                    kg_Series_To_KG_Base = new decimal[] { 0, 0, 0, 0, 0, 0, 0, 0.000001m, 0.001m, 1, 1000, 1000000, 1000000000, 1000000000000, 1000000000000000 };
                }
                return kg_Series_To_KG_Base;
            }
        }

        static decimal[] inch_Series_To_KG_Base = null;
        //英制单位相对于千克的进阶数。数组的下标就是各个单位枚举值。英制枚举值从100开始，所以枚举值和Inch_Series_To_M_Base下标的对应差100.
        static decimal[] Inch_Series_To_KG_Base
        {
            get
            {
                if (inch_Series_To_KG_Base == null)
                {
                    inch_Series_To_KG_Base = new decimal[] { 0.0000648m, 0.00177184375m, 0.0283495m, 0.4536m, 6.3504m, 12.7008m, 50.8032m, 1016.064m };
                }
                return inch_Series_To_KG_Base;
            }
        }

        /// <summary>
        /// 返回相对于千克的进阶，即换算基数。
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        static decimal Get_KG_Base(MassUnit unit)
        {
            int unitInt = (int)unit;
            if (unitInt >= 0 && unitInt <= 99)
            {
                return KG_Series_To_KG_Base[unitInt];
            }
            unitInt = unitInt - 100;
            if (unitInt >= 0 && unitInt <= 99)
            {
                return Inch_Series_To_KG_Base[unitInt];
            }
            throw new NotImplementedException(string.Format("没有实现单位：{0}的换算", unit.ToString()));
        }
        #endregion
    }

    /// <summary>
    /// 质量单位类型
    /// 注：
    /// 1、枚举值的定义是有意义的。克系列的单位，上下两个枚举值的进制是1000。这个规律快速的找到两个克系列单位的换算公式：a = b * (a枚举值-b枚举值)*1000
    /// </summary>
    public enum MassUnit
    {
        #region 公制单位系列。公制单位系列的单位，上下两个枚举值的进制是1000。这个规律快速的找到两个克系列单位的换算公式：a = b * (a枚举值-b枚举值)*1000
        ///// <summary>
        ///// 攸克：10^-27
        ///// </summary>
        //yg = 0,

        ///// <summary>
        ///// 介克：10^-24
        ///// </summary>
        //zg = 1,

        ///// <summary>
        ///// 阿克：10^-21
        ///// </summary>
        //ag = 2,

        ///// <summary>
        ///// 飛克：10^-18
        ///// </summary>
        //fg = 3,

        ///// <summary>
        ///// 皮克：10^-15
        ///// </summary>
        //pg = 4,

        ///// <summary>
        ///// 納克：10^-12
        ///// </summary>
        //ng = 5,

        ///// <summary>
        ///// 微克：10^-9
        ///// </summary>
        //ug = 6,

        /// <summary>
        /// 毫克：10^-6
        /// </summary>
        mg = 7,

        /// <summary>
        /// 克：10^-3
        /// </summary>
        g = 8,

        /// <summary>
        /// 千克：10^-0
        /// </summary>
        kg = 9,

        /// <summary>
        /// 吨，兆克：10^3
        /// </summary>
        Mg = 10,

        ///// <summary>
        ///// 吉克：10^6
        ///// </summary>
        //Gg = 11,

        ///// <summary>
        ///// 兆克：10^9
        ///// </summary>
        //Tg = 12,

        ///// <summary>
        ///// 拍克：10^12
        ///// </summary>
        //Pg = 13,

        ///// <summary>
        ///// 艾克：10^15
        ///// </summary>
        //Eg = 14,

        ///// <summary>
        ///// 皆克：10^18
        ///// </summary>
        //Zg = 15,

        ///// <summary>
        ///// 佑克：10^21
        ///// </summary>
        //Yg = 16

        #endregion

        #region 英制

        /// <summary>
        /// 1 格令（grain）= 64.8 毫克
        /// </summary>
        grain = 100,

        /// <summary>
        /// 1 打兰（drachm）= 1/16 盎司（ounce） = 1.77 克
        /// </summary>
        drachm = 101,

        /// <summary>
        /// 1 盎司 = 1/16 磅（pound）= 28.3 克
        /// </summary>
        ounce = 102,

        /// <summary>
        /// 1磅 = 7000 格令 = 454 克
        /// </summary>
        pound = 103,

        /// <summary>
        /// 1 英石（stone）= 14 磅 = 6.35 千克
        /// </summary>
        stone = 104,

        /// <summary>
        /// 1 夸特（quarter）= 2 英石 = 28 磅 = 12.7 千克
        /// </summary>
        quarter = 105,

        /// <summary>
        /// 1 英担（hundredweight）= 4 夸特 = 112 磅 = 50.8 千克
        /// </summary>
        hundredweight = 106,

        /// <summary>
        /// 1英吨（ton）= 20 英担 = 2240 磅 = 1016 千克
        /// </summary>
        ton = 107,

        #endregion
    }

    /// <summary>
    /// 质量单位类型拓展
    /// </summary>
    public static class MassUnitExtension
    {
        static Dictionary<MassUnit, GlobalString> unitNameDict = null;
        static Dictionary<MassUnit, GlobalString> UnitNameDict
        {
            get
            {
                if (unitNameDict == null)
                {
                    unitNameDict = new Dictionary<MassUnit, GlobalString>();
                    //#region 攸克
                    //unitNameDict[MassUnit.yg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.yg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "攸克"), new LocalString(LanguageCodes.EN, "yg"));
                    //#endregion
                    //#region 介克
                    //unitNameDict[MassUnit.zg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.zg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "介克"), new LocalString(LanguageCodes.EN, "zg"));
                    //#endregion
                    //#region 阿克
                    //unitNameDict[MassUnit.ag] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.ag].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "阿克"), new LocalString(LanguageCodes.EN, "ag"));
                    //#endregion
                    //#region 飛克
                    //unitNameDict[MassUnit.fg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.fg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "飛克"), new LocalString(LanguageCodes.EN, "fg"));
                    //#endregion
                    //#region 皮克
                    //unitNameDict[MassUnit.pg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.pg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "皮克"), new LocalString(LanguageCodes.EN, "pg"));
                    //#endregion
                    //#region 納克
                    //unitNameDict[MassUnit.ng] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.ng].AddOrUpdate(new LocalString(LanguageCodes.ZH, "納克"), new LocalString(LanguageCodes.EN, "ng"));
                    //#endregion
                    //#region 微克
                    //unitNameDict[MassUnit.ug] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.ug].AddOrUpdate(new LocalString(LanguageCodes.ZH, "微克"), new LocalString(LanguageCodes.EN, "ug"));
                    //#endregion
                    #region 毫克
                    unitNameDict[MassUnit.mg] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[MassUnit.mg].AddOrUpdate(new LocalString(LanguageCodes.ZH, "毫克"), new LocalString(LanguageCodes.EN, "mg"));
                    #endregion
                    #region 克
                    unitNameDict[MassUnit.g] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[MassUnit.g].AddOrUpdate(new LocalString(LanguageCodes.ZH, "克"), new LocalString(LanguageCodes.EN, "g"));
                    #endregion
                    #region 千克
                    unitNameDict[MassUnit.kg] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[MassUnit.kg].AddOrUpdate(new LocalString(LanguageCodes.ZH, "千克"), new LocalString(LanguageCodes.EN, "kg"));
                    #endregion
                    #region 吨
                    unitNameDict[MassUnit.Mg] = new GlobalString(LanguageCodes.EN);
                    unitNameDict[MassUnit.Mg].AddOrUpdate(new LocalString(LanguageCodes.ZH, "吨"), new LocalString(LanguageCodes.EN, "Mg"));
                    #endregion
                    //#region 吉克
                    //unitNameDict[MassUnit.Gg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.Gg].AddOrUpdate(new LocalString(LanguageCodes.ZH, "吉克"), new LocalString(LanguageCodes.EN, "Gg"));
                    //#endregion
                    //#region 兆克
                    //unitNameDict[MassUnit.Tg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.Tg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "兆克"), new LocalString(LanguageCodes.EN, "Tg"));
                    //#endregion
                    //#region 拍克
                    //unitNameDict[MassUnit.Pg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.Pg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "拍克"), new LocalString(LanguageCodes.EN, "Pg"));
                    //#endregion
                    //#region 艾克
                    //unitNameDict[MassUnit.Eg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.Eg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "艾克"), new LocalString(LanguageCodes.EN, "Eg"));
                    //#endregion
                    //#region 皆克
                    //unitNameDict[MassUnit.Zg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.Zg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "皆克"), new LocalString(LanguageCodes.EN, "Zg"));
                    //#endregion
                    //#region 佑克
                    //unitNameDict[MassUnit.Yg] = new GlobalString(LanguageCodes.EN);
                    //unitNameDict[MassUnit.Yg].AddOrUpdateLocalStrings(new LocalString(LanguageCodes.ZH, "佑克"), new LocalString(LanguageCodes.EN, "Yg"));
                    //#endregion
                }
                return unitNameDict;
            }
        }

        /// <summary>
        /// 获取单位的多语言描述
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string GetName(this MassUnit unit)
        {
            if (UnitNameDict.ContainsKey(unit))
                return UnitNameDict[unit].GetValue();
            return unit.ToString();
        }
    }
}
