using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Anchi.ERP.Common.Extensions;

namespace Anchi.ERP.Common.Excel
{

    /// <summary>
    /// NPOI帮助操作类
    /// </summary>
    public class NPOIHelper<T> where T : new()
    {
        /// <summary>
        /// NPOI工作薄
        /// </summary>
        HSSFWorkbook hssfworkbook = null;
        /// <summary>
        /// 
        /// </summary>
        T t;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public NPOIHelper()
        {
            t = new T();
        }
        #endregion

        #region 初始化文件信息
        /// <summary>
        /// 初始化文件信息
        /// </summary>
        private void InitializeWorkbook()
        {
            //实例对象
            hssfworkbook = new HSSFWorkbook();

            #region 右击文件 属性信息
            {
                var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = string.Empty;
                hssfworkbook.DocumentSummaryInformation = dsi;

                var si = PropertySetFactory.CreateSummaryInformation();
                si.Author = string.Empty; //填加xls文件作者信息
                si.ApplicationName = string.Empty; //填加xls文件创建程序信息
                si.LastAuthor = string.Empty; //填加xls文件最后保存者信息
                si.Comments = string.Empty; //填加xls文件作者信息
                si.Title = string.Empty; //填加xls文件标题信息
                si.Subject = string.Empty;//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                hssfworkbook.SummaryInformation = si;
            }
            #endregion
        }

        /// <summary>
        /// 初始化文件信息
        /// </summary>
        /// <param name="path"></param>
        private void InitializeWorkbook(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("找不到当前路径文件");

            try
            {
                using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
            }
            catch
            {
                throw new ApplicationException("Excel模板不是标准格式");
            }
        }
        #endregion

        #region 获取导入的列表
        /// <summary>
        /// 获取导入的列表
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="itemList">项集合</param>
        /// <returns></returns>
        public List<T> GetImportList(string path, List<ColumnValidItem> itemList)
        {
            var table = this.GetImportData(path, itemList);
            return this.ReflectionObject(table, itemList);
        }
        #endregion

        #region 获取导入的EXCEL列集合
        /// <summary>
        /// 获取导入的
        /// </summary>
        /// <param name="path">EXCEL路径</param>
        /// <returns></returns>
        public List<string> GetImportColumn(string path)
        {
            this.InitializeWorkbook(path);

            var sheet = hssfworkbook.GetSheetAt(0);
            var rows = sheet.GetRowEnumerator();

            List<string> columnList = new List<string>();

            ICell cell = null;
            while (rows.MoveNext())
            {
                var row = (HSSFRow)rows.Current;
                if (row.RowNum == 0)
                {
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        cell = row.GetCell(i);
                        if (cell != null && !string.IsNullOrEmpty(cell.ToString()))
                            columnList.Add(cell.ToString());
                    }
                    break;
                }
            }
            return columnList;
        }
        #endregion

        #region DataTable反射到实体
        /// <summary>
        /// DataTable反射到实体
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="itemList">项集合</param>
        /// <returns></returns>
        private List<T> ReflectionObject(DataTable dt, List<ColumnValidItem> itemList)
        {
            var tList = new List<T>();

            var tarType = t.GetType();
            var filedValue = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                t = new T();
                foreach (DataColumn col in dt.Columns)
                {
                    if (!itemList.Exists(v => v.Name == col.ColumnName))
                        continue;

                    var validItem = itemList.FirstOrDefault(v => v.Name == col.ColumnName);
                    var pit = tarType.GetProperty(validItem.DataModelName);
                    if (pit != null)
                    {
                        filedValue = dt.Rows[i][col.ColumnName] == DBNull.Value ? string.Empty : dt.Rows[i][col.ColumnName].ToString().Trim();
                        switch (validItem.ValidType)
                        {
                            case EnumValidType.DateTime:
                                filedValue = string.IsNullOrEmpty(filedValue) ? DateTime.MinValue.ToShortDateString() : filedValue;
                                pit.SetValue(t, DateTime.Parse(filedValue), null);
                                break;
                            default:
                                pit.SetValue(t, filedValue, null);
                                break;
                        }
                    }
                }
                tList.Add(t);
            }
            return tList;
        }
        #endregion

        #region 获取导入的EXCEL数据
        /// <summary>
        /// 获取导入的EXCEL数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable GetImportData(string path)
        {
            this.InitializeWorkbook(path);

            var sheet = hssfworkbook.GetSheetAt(0);
            var rows = sheet.GetRowEnumerator();

            var table = new DataTable();
            DataRow tableRow = null;
            while (rows.MoveNext())
            {
                var row = (HSSFRow)rows.Current;
                if (row.RowNum != 0)//数据行
                {
                    tableRow = table.NewRow();
                    table.Rows.Add(tableRow);
                }
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell == null)
                        continue;

                    var cellValue = cell.ExtToString().Trim();
                    if (row.RowNum == 0)
                    {   //标题（列表）
                        if (!table.Columns.Contains(cellValue) && !string.IsNullOrWhiteSpace(cellValue))
                            table.Columns.Add(cellValue);
                    }
                    else if (cell.ColumnIndex < table.Columns.Count)
                    {   //数据行
                        tableRow[cell.ColumnIndex] = cellValue;
                    }
                }
            }
            return table;
        }
        #endregion

        #region 获取导入的EXCEL数据
        /// <summary>
        /// 获取导入的EXCEL数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public DataTable GetImportData(string path, List<ColumnValidItem> itemList)
        {
            this.InitializeWorkbook(path);

            var sheet = hssfworkbook.GetSheetAt(0);
            var rows = sheet.GetRowEnumerator();

            var table = new DataTable();
            DataRow tableRow = null;
            ColumnValidItem validItem = null;
            while (rows.MoveNext())
            {
                var row = (HSSFRow)rows.Current;
                if (row.RowNum != 0)//数据行
                {
                    tableRow = table.NewRow();
                    table.Rows.Add(tableRow);
                }
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);

                    if (cell == null)
                        continue;

                    var cellValue = cell.ExtToString().Trim();
                    if (row.RowNum == 0)//标题（列表）
                    {
                        if (!table.Columns.Contains(cellValue) && !string.IsNullOrEmpty(cellValue))
                            table.Columns.Add(cellValue);
                    }
                    else if (cell.ColumnIndex < table.Columns.Count)//数据行
                    {
                        validItem = itemList.FirstOrDefault(v => v.Name == table.Columns[cell.ColumnIndex].ColumnName);
                        if (validItem != null)
                        {
                            try
                            {
                                switch (validItem.ValueType)
                                {
                                    case EnumValueType.String:
                                        tableRow[cell.ColumnIndex] = cell.StringCellValue.Trim();
                                        break;
                                    case EnumValueType.DateTime:
                                        DateTime currDate = DateTime.MinValue;
                                        if (cell.ToString().Contains("-") || cell.ToString().Contains("/"))
                                            currDate = cell.DateCellValue;
                                        tableRow[cell.ColumnIndex] = currDate.ToShortDateString();
                                        break;
                                    default:
                                        tableRow[cell.ColumnIndex] = cellValue;
                                        break;
                                }
                            }
                            catch
                            {
                                tableRow[cell.ColumnIndex] = cellValue;
                            }
                        }
                    }
                }
            }
            return table;
        }
        #endregion

        #region 生成EXCEL
        /// <summary>
        /// 生成EXCEL
        /// </summary>
        /// <param name="filePath">要保存的文件路径 eg:test.xls</param>
        /// <param name="sheetName">Excel工作薄名称 </param>
        /// <param name="table">数据数组</param>
        /// <param name="rowTitle">标题数组</param>
        public void WriteExcelFile(string filePath, string sheetName, DataTable table, List<ColumnValidItem> rowTitle)
        {
            // 初始化Excel信息
            this.InitializeWorkbook();
            // 填充数据
            this.DTExcel(sheetName, table, rowTitle);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                hssfworkbook.Write(stream);
            }
        }

        /// <summary>
        /// 生成EXCEL
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        /// <param name="entityList"></param>
        /// <param name="hidColIndexs"></param>
        /// <param name="itemList"></param>
        public void WriteExcelFile(string filePath, string sheetName, List<T> entityList, List<ColumnValidItem> itemList, params int[] hidColIndexs)
        {
            // 初始化Excel信息
            this.InitializeWorkbook();
            // 填充数据
            this.DTExcel(sheetName, entityList, itemList, hidColIndexs);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                hssfworkbook.Write(stream);
            }
        }
        #endregion

        #region 填充数据
        /// <summary>
        /// 将DataTable数据写入到Excel
        /// </summary>
        /// <param name="sheetName">工作薄名称</param>
        /// <param name="table">数据</param>
        /// <param name="rowTitle">标题数组</param>
        /// <param name="hidColIndexs"></param>
        private void DTExcel(string sheetName, DataTable table, List<ColumnValidItem> rowTitle, params int[] hidColIndexs)
        {
            var sheet1 = hssfworkbook.CreateSheet(sheetName);
            sheet1.CreateFreezePane(0, 1, 0, 1);

            foreach (int index in hidColIndexs)
            {
                sheet1.SetColumnHidden(index, true);
            }

            var sheet2 = hssfworkbook.CreateSheet("ShtDictionary");
            //隐藏ShtDictionary工作薄
            hssfworkbook.SetSheetHidden(1, true);
            //创建标题行且赋值
            this.CreateTitleRow(sheet1, rowTitle);

            var cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.0");
            if (table != null)
            {
                //填充数据项
                for (int xcount = 0; xcount < table.Rows.Count; xcount++)
                {
                    DataRow row = table.Rows[xcount];
                    var hsBodyRow = sheet1.CreateRow(xcount + 1);//数据行+1(第0行是标题)

                    for (int ycBody = 0; ycBody < rowTitle.Count; ycBody++)
                    {
                        if (rowTitle[ycBody] == null)
                            continue;

                        var value = string.Empty;
                        if (table.Columns.Contains(rowTitle[ycBody].DataModelName))
                            value = row[rowTitle[ycBody].DataModelName].ToString();

                        var cell = hsBodyRow.CreateCell(ycBody);
                        if (!string.IsNullOrEmpty(value))
                            cell.SetCellValue(value);

                        if (rowTitle[ycBody].ValidType == EnumValidType.Decimal)
                            cell.CellStyle = cellStyle;
                    }
                }
            }
        }

        /// <summary>
        /// 将DataTable数据写入到Excel
        /// </summary>
        /// <param name="sheetName">工作薄名称</param>
        /// <param name="entitys">数据数组</param>
        /// <param name="rowTitle">标题数组</param>
        /// <param name="hidColIndexs">需要隐藏的列索引集合</param>
        private void DTExcel(string sheetName, List<T> entitys, List<ColumnValidItem> rowTitle, params int[] hidColIndexs)
        {
            var sheet1 = hssfworkbook.CreateSheet(sheetName);
            sheet1.CreateFreezePane(0, 1, 0, 1);
            foreach (int index in hidColIndexs)
            {
                sheet1.SetColumnHidden(index, true);
            }

            var sheet2 = hssfworkbook.CreateSheet("ShtDictionary");
            //隐藏ShtDictionary工作薄
            hssfworkbook.SetSheetHidden(1, true);
            //创建标题行且赋值
            this.CreateTitleRow(sheet1, rowTitle);
            if (entitys != null)
            {
                var tarType = t.GetType();
                //填充数据项
                for (int xcount = 0; xcount < entitys.Count; xcount++)
                {
                    t = entitys[xcount];

                    var hsBodyRow = sheet1.CreateRow(xcount + 1);//数据行+1(第0行是标题)
                    for (int ycBody = 0; ycBody < rowTitle.Count; ycBody++)
                    {
                        if (rowTitle[ycBody] != null)
                        {
                            if (!string.IsNullOrEmpty(rowTitle[ycBody].DataModelName))
                            {
                                var pit = tarType.GetProperty(rowTitle[ycBody].DataModelName);
                                if (pit != null)
                                {
                                    var cellValue = pit.GetValue(t, null).ExtToString();
                                    hsBodyRow.CreateCell(ycBody).SetCellValue(cellValue);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将DataTable数据写入到Excel
        /// </summary>
        /// <param name="sheetName">工作薄名称</param>
        /// <param name="table">数据表</param>
        private void DTExcel(string sheetName, DataTable table)
        {
            var sheet1 = hssfworkbook.CreateSheet(sheetName);
            sheet1.CreateFreezePane(0, 1, 0, 1);

            //创建标题行且赋值
            var hsTitleRow = sheet1.GetRow(0) ?? sheet1.CreateRow(0);
            ICell cell = null;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                cell = hsTitleRow.GetCell(i) ?? hsTitleRow.CreateCell(i);
                cell.SetCellValue(table.Columns[i].ColumnName);
            }

            if (table.Rows.Count > 0)
            {
                IRow hsBodyRow = null;
                //填充数据项
                for (int xcount = 0; xcount < table.Rows.Count; xcount++)
                {
                    hsBodyRow = sheet1.GetRow(xcount + 1) ?? sheet1.CreateRow(xcount + 1);//数据行+1(第0行是标题)
                    for (int ycBody = 0; ycBody < table.Columns.Count; ycBody++)
                    {
                        hsBodyRow.CreateCell(ycBody).SetCellValue(table.Rows[xcount][ycBody].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 创建标题行
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="rowTitle"></param>
        private void CreateTitleRow(ISheet sheet, List<ColumnValidItem> rowTitle)
        {
            var ShtDictionary = hssfworkbook.GetSheet("ShtDictionary") ?? hssfworkbook.CreateSheet("ShtDictionary");

            IRow hsTitleRow = sheet.CreateRow(0);
            hsTitleRow.HeightInPoints = 20;
            //单元格格式是文本与居中
            var formatCellStyle1 = hssfworkbook.CreateCellStyle();
            formatCellStyle1.Alignment = HorizontalAlignment.Center;
            formatCellStyle1.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
            //单元格格式是常规与居中
            var formatCellStyle2 = hssfworkbook.CreateCellStyle();
            formatCellStyle2.Alignment = HorizontalAlignment.Center;
            //日期
            var formatCellStyle3 = hssfworkbook.CreateCellStyle();
            formatCellStyle3.Alignment = HorizontalAlignment.Center;
            var format = hssfworkbook.CreateDataFormat();
            formatCellStyle3.DataFormat = format.GetFormat("yyyy-m-d");

            var cellStyle1 = hssfworkbook.CreateCellStyle();
            cellStyle1.Alignment = HorizontalAlignment.Center;
            var font1 = hssfworkbook.CreateFont();
            font1.Color = HSSFColor.Red.Index;
            font1.FontHeightInPoints = 12;
            font1.FontName = "宋体";
            cellStyle1.SetFont(font1);

            var cellStyle2 = hssfworkbook.CreateCellStyle();
            cellStyle2.Alignment = HorizontalAlignment.Center;
            var font2 = hssfworkbook.CreateFont();
            font2.FontHeightInPoints = 12;
            font2.FontName = "宋体";
            cellStyle2.SetFont(font2);

            ICell cell = null;
            ColumnValidItem validItem = null;

            for (int i = 0; i < rowTitle.Count; i++)
            {
                validItem = rowTitle[i];
                if (validItem != null)
                {
                    cell = hsTitleRow.CreateCell(i);
                    cell.SetCellValue(validItem.Name);
                    //列宽度
                    sheet.SetColumnWidth(i, validItem.Width == 0 ? 80 * 50 : validItem.Width * 50);

                    #region 项类型

                    switch (validItem.ItemType)//是否以红色标记
                    {
                        case EnumItemType.MustHave:
                        case EnumItemType.MustFill:
                            cell.CellStyle = cellStyle1;
                            break;
                        case EnumItemType.SelectFill:
                            cell.CellStyle = cellStyle2;
                            break;
                    }
                    #endregion

                    #region 值类型

                    switch (validItem.ValueType)//值类型
                    {
                        case EnumValueType.String:
                            sheet.SetDefaultColumnStyle(i, formatCellStyle1);
                            break;
                        case EnumValueType.Number:
                            sheet.SetDefaultColumnStyle(i, formatCellStyle2);
                            break;
                        case EnumValueType.DateTime:
                            sheet.SetDefaultColumnStyle(i, formatCellStyle3);
                            break;
                        case EnumValueType.List:
                            int count = this.CreateColumnList(validItem, i, ShtDictionary);
                            var regions = new CellRangeAddressList(1, 65535, i, i);
                            var constraint = DVConstraint.CreateFormulaListConstraint(string.Format("ShtDictionary!${0}${1}:${0}${2}", Chr(i), 1, count));
                            var dataValidate = new HSSFDataValidation(regions, constraint);
                            ((HSSFSheet)sheet).AddValidationData(dataValidate);
                            break;
                    }
                    #endregion

                    this.ValidAndMessage(validItem, i, sheet);//验证类型
                }
            }
        }
        #endregion

        #region 创建下拉列表
        /// <summary>
        /// 创建下拉列表
        /// </summary>
        /// <param name="validItem"></param>
        /// <param name="colIndex"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private int CreateColumnList(ColumnValidItem validItem, int colIndex, ISheet sheet)
        {
            int length = 0;
            if (!string.IsNullOrEmpty(validItem.DropDownValue))
            {
                var splitArray = validItem.DropDownValue.Split(new string[] { "$_$" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < splitArray.Length; i++)
                {
                    GetRow(sheet, i).CreateCell(colIndex).SetCellValue(splitArray[i]);
                }
                length = splitArray.Length;
            }

            if (length == 0)
                throw new ApplicationException(validItem.Name + "不能为空");

            return length;
        }
        #endregion

        #region 验证与提示
        /// <summary>
        /// 验证与提示
        /// </summary>
        /// <param name="validItem"></param>
        /// <param name="colIndex"></param>
        /// <param name="sheet"></param>
        private void ValidAndMessage(ColumnValidItem validItem, int colIndex, ISheet sheet)
        {
            DVConstraint constraint = null;
            HSSFDataValidation dataValidate = null;
            switch (validItem.ValidType)//验证类型
            {
                case EnumValidType.Integer:
                    constraint = DVConstraint.CreateNumericConstraint(ValidationType.INTEGER, (int)validItem.ValidQualifier, validItem.ValidMin, validItem.ValidMax);
                    break;
                case EnumValidType.Decimal:
                    constraint = DVConstraint.CreateNumericConstraint(ValidationType.DECIMAL, (int)validItem.ValidQualifier, validItem.ValidMin, validItem.ValidMax);
                    break;
                case EnumValidType.DateTime:
                    constraint = DVConstraint.CreateDateConstraint((int)validItem.ValidQualifier, validItem.ValidMin, validItem.ValidMax, "yyyy-MM-dd");
                    break;
                case EnumValidType.TextLength:
                    constraint = DVConstraint.CreateNumericConstraint(ValidationType.TEXT_LENGTH, (int)validItem.ValidQualifier, validItem.ValidMin ?? "1", validItem.ValidMax ?? "200");
                    break;
                case EnumValidType.Customize:
                    constraint = DVConstraint.CreateCustomFormulaConstraint(string.Format(validItem.ValidFormula, Chr(colIndex)));
                    break;
            }
            if (constraint != null)
            {
                CellRangeAddressList regions = null;
                if (validItem.ValidType == EnumValidType.Customize && validItem.ValidFormula == "COUNTIF({0}:{0},\"*@*.*\")=1")//邮件格式验证
                {
                    int rowCount = 2000;//只支持前2000行邮件格式验证
                    for (int i = 0; i < rowCount; i++)
                    {
                        constraint = DVConstraint.CreateCustomFormulaConstraint(string.Format("COUNTIF({0}{1},\"*@*.*\")=1", Chr(colIndex), i + 2));
                        regions = new CellRangeAddressList(i + 1, i + 1, colIndex, colIndex);
                        dataValidate = new HSSFDataValidation(regions, constraint);
                        dataValidate.CreatePromptBox(validItem.Name, validItem.InputMessage);
                        dataValidate.CreateErrorBox(validItem.Name, validItem.ErrorMessage);

                        ((HSSFSheet)sheet).AddValidationData(dataValidate);
                    }
                }
                else
                {
                    regions = new CellRangeAddressList(1, 65535, colIndex, colIndex);
                    dataValidate = new HSSFDataValidation(regions, constraint);
                    dataValidate.CreatePromptBox(validItem.Name, validItem.InputMessage);
                    dataValidate.CreateErrorBox(validItem.Name, validItem.ErrorMessage);

                    ((HSSFSheet)sheet).AddValidationData(dataValidate);
                }
            }
        }
        #endregion

        #region 根据行索引返回对应行对象
        /// <summary>
        /// 根据行索引返回对应行对象
        /// </summary>
        /// <param name="sheet">工作薄</param>
        /// <param name="rowIndex">行索引</param>
        /// <returns></returns>
        static private IRow GetRow(ISheet sheet, int rowIndex)
        {
            return sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
        }
        #endregion

        #region ASCII转换
        /// <summary>
        /// 字符转数字
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            throw new Exception("Character is not valid.");
        }

        /// <summary>
        /// ASCII码转字符
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string Chr(int asciiCode)
        {
            int mode = asciiCode % 26 + 65;

            if (mode >= 0 && mode <= 255)
            {
                var asciiEncoding = new ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)mode };
                string strCharacter = asciiEncoding.GetString(byteArray);

                if (asciiCode / 26 > 0)
                {
                    asciiEncoding = new ASCIIEncoding();
                    byteArray = new byte[] { (byte)(asciiCode / 26 - 1 + 65) };
                    return asciiEncoding.GetString(byteArray) + strCharacter;
                }
                return (strCharacter);
            }
            throw new Exception("ASCII Code is not valid.");
        }
        #endregion
    }
}
