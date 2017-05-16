using CarlosAg.ExcelXmlWriter;
using Deviation.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Deviation
{
  

    public class Deviation
    {
        private static String path = Directory.GetCurrentDirectory();
        private static String Output = path+@"\DeviationLab1.xls";

        ///<summary>there are 10 items in the dataset and solve the summation items in the mean formula and calculate the intermediate value for standard deviation formula </summary>
        ///<param name="lstData">List Type as Integer 10 Item , passed by reference, that contains all the data as Type Integer >/param>
        ///<example>Author      : THANAWAT PHORNPHOMSRI</example>
        ///<example>Date Start  : 05/2/2017 11:00</example>
        ///<example>Date END    : 25/2/2017 14:00</example>
        ///<example>Contact     : thanawat.phor@ku.th</example>
        /// 


        /// -------------------------------- BEGIN Main Program-------------------------
        /// <summary>List Type as Integer 10 Item  and average list </summary>
        /// <param name="lstData">List Type as Integer 10 Item , passed by reference, that contains all the data as Type Integer >/param>
        /// <param name="avg">Calculation function Average in List </param>
        /// <param name="div">Calculation function Deviation in List </param>
        ///<returns>value divation type double </returns> 
        ///<example>lstData[0]  =10 ; </example>
        ///<permission cref="THANAWAT"/>
        /// -------------------------------- End Main Program-------------------------

        public static void Main(String[] args)
        {
            ////////////////
            DeivationList listDeviation = new DeivationList();
            List<DeviationEntity> lstDeviation = getInput();
            listDeviation.ListDeviationEntity = lstDeviation;
            listDeviation.AvgX = getAverage(lstDeviation);
            listDeviation.ListDeviationEntity = getDeviation(lstDeviation, listDeviation.AvgX);
            listDeviation = SumDeviationCal(lstDeviation,listDeviation);
            GenerateExcel(Output, listDeviation);
            
        }

        /// <summary>List Type as Integer 10 Item  and average list </summary>
        /// <param name="lstData">List Type as Integer 10 Item , passed by reference, that contains all the data as Type Integer >/param>
        /// <param name="sum">Summary In List </param>
        /// <param name="cnt">Count Number in List </param>
        ///<returns>value avergae type double </returns>
        ///<example>lstData[0]  = 10 ; </example>
        ///<permission cref="THANAWAT_20170222"/>

        public static double getAverage(List<DeviationEntity> lstDeviation)
        {
            double sum = 0, cnt = 0;
            foreach (DeviationEntity dEntity in lstDeviation)
            {
                cnt += 1;
                sum += dEntity.NumX;
            }
            double avg = sum / cnt;
            return avg;
        }
        /// <summary>Calculation Function Deviation in List </summary>
        /// <param name="lstData">List Type as Integer 10 Item , passed by reference, that contains all the data as Type Integer >/param>
        /// <param name="_pow">Deviation Function Math pow</param>
        /// <param name="avg"> Average in List </param>
        /// <param name="_deviat">Calculation  result Deviation</param>
        ///<example>lstData[0]  =10 ; </example>
        ///<permission cref="THANAWAT_20170222"/>
        public static List<DeviationEntity> getDeviation(List<DeviationEntity> lstDeviation,double avg)
        {

            
            int i = 0;
            foreach (DeviationEntity dEntity in lstDeviation)
            {
                DeviationEntity dENtityTemp = new DeviationEntity();
                dENtityTemp.NumDeviation = Math.Pow((dEntity.NumX - avg), 2); 
                lstDeviation[i].NumDeviation = dENtityTemp.NumDeviation;
                i++;
            }
            return lstDeviation;
            //double _deviat = (_pow) / (_cnt - 1);
            //return Math.Sqrt(_deviat);
        }

        public static DeivationList  SumDeviationCal(List<DeviationEntity> listDeviationEntity, DeivationList dList)
        {
            List<DeviationEntity>  list = dList.ListDeviationEntity;
            foreach (DeviationEntity dEntity in list)
            {
                dList.SumX += dEntity.NumX;
                dList.SumDeviation += dEntity.NumDeviation ;
            }
            double _deviat = Math.Sqrt(dList.SumDeviation / (list.Count-1));
            dList.DeviationPow1 = _deviat;
            return dList;
        }
        /// <summary>getInput for random integer and Save to List</summary>
        /// <param name="lstData">List Type as Integer 10 Item </param>
        ///<example>lstData  =(186,699,132,272); </example>
        /// <paramref name="lstdata">Integer</paramref>
        public static List<DeviationEntity> getInput()
        {
            //List Data Random Integer 10 Item
            int[] dNum = { 186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601 };
            int i = 0;
            List<DeviationEntity> lstDeviationEntity = new List<DeviationEntity>();
            foreach (int item in dNum)
            {
                i++;
                DeviationEntity entity = new DeviationEntity();
                entity.NumSeq = i;
                entity.NumX = item;
                lstDeviationEntity.Add(entity);

            }
            return lstDeviationEntity;
        }
        public static void GenerateExcel(String OutputFileName, DeivationList lstDeviation)
        {

            Workbook workbook = new Workbook();
            workbook.ExcelWorkbook.ActiveSheetIndex = (3);
            workbook.ExcelWorkbook.WindowTopX = (100);
            workbook.ExcelWorkbook.WindowTopY = (200);
            workbook.ExcelWorkbook.WindowHeight = (7000);
            workbook.ExcelWorkbook.WindowWidth = (10000);
            workbook.Properties.Author = ("CarlosAg");
            workbook.Properties.Title = "DeviationApp";
            workbook.Properties.Created = (DateTime.Now);
            workbook.Styles.Add("HeaderStyle").Font.FontName = ("Cordia New");

            WorksheetStyle worksheetStyle1 = workbook.Styles.Add("Default");

            worksheetStyle1.Font.FontName = "Cordia New";
            worksheetStyle1.Font.Size = 14;
            worksheetStyle1.Font.Bold = (true);
            worksheetStyle1.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            worksheetStyle1.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            worksheetStyle1.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            worksheetStyle1.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

            Worksheet worksheet1 = workbook.Worksheets.Add("DeviationSheet");
            worksheet1.Table.Columns.Add(new WorksheetColumn(120)); //1
            worksheet1.Table.Columns.Add(new WorksheetColumn(120));//2
            worksheet1.Table.Columns.Add(new WorksheetColumn(120));//3

            /// Header 
            /// 
            WorksheetRow worksheetRow1 = worksheet1.Table.Rows.Add();
            worksheetRow1.Cells.Add("");

            worksheetRow1 = worksheet1.Table.Rows.Add();
            worksheetRow1.Cells.Add("N (seq)");
            worksheetRow1.Cells.Add("X (input)");
            worksheetRow1.Cells.Add("(Xi - Xavg)^2");

            WorksheetStyle style33 = workbook.Styles.Add("s31");
            style33.Font.FontName = "Cordia New";
            style33.Font.Size = 14;
            style33.Font.Bold = false;
            style33.Interior.Pattern = StyleInteriorPattern.Solid;
            style33.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            style33.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            style33.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            style33.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            
            WorksheetStyle style = workbook.Styles.Add("s32");
            style.Font.FontName = "Cordia New";
            style.Font.Size = 14;
            style.Font.Bold = false;
            style.NumberFormat = "#,###,##0";

            WorksheetCell worksheetCell = null;
            foreach (DeviationEntity dnEntity in lstDeviation.ListDeviationEntity)
            {
                worksheetRow1 = worksheet1.Table.Rows.Add();

                worksheetCell = new WorksheetCell(dnEntity.NumSeq.ToString(), DataType.Number, "s31");
                worksheetRow1.Cells.Add(worksheetCell);

                worksheetCell = new WorksheetCell(dnEntity.NumX.ToString(), DataType.Number, "s31");
                worksheetRow1.Cells.Add(worksheetCell);

                worksheetCell = new WorksheetCell(dnEntity.NumDeviation.ToString(), DataType.Number, "s31");
                worksheetRow1.Cells.Add(worksheetCell);

            }
            worksheetRow1 = worksheet1.Table.Rows.Add();

            worksheetCell = new WorksheetCell("Result Summary", DataType.String, "s31");
            worksheetRow1.Cells.Add(worksheetCell);

            worksheetCell = new WorksheetCell("Sum (X) : "+lstDeviation.SumX, DataType.String, "s31");
            worksheetRow1.Cells.Add(worksheetCell);
            worksheetCell = new WorksheetCell("Sum (Deviation) : " + lstDeviation.SumDeviation, DataType.String, "s31");
            worksheetRow1.Cells.Add(worksheetCell);
            worksheetRow1 = worksheet1.Table.Rows.Add();

            worksheetCell = new WorksheetCell("", DataType.String, "s31");
            worksheetRow1.Cells.Add(worksheetCell);
            worksheetCell = new WorksheetCell("Result Power Deviation", DataType.String, "s31");
            worksheetRow1.Cells.Add(worksheetCell);

            worksheetCell = new WorksheetCell(lstDeviation.DeviationPow1.ToString(), DataType.Number, "s31");
            worksheetRow1.Cells.Add(worksheetCell);

            workbook.Save(OutputFileName);
            Process.Start(OutputFileName);
            Console.WriteLine("Please Enter Finish Program (Y/N)");
            Console.Read();
        }

    }

}