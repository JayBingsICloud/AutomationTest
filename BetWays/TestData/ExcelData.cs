using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutomationTest.TestData
{
    class ExcelData
    {
        public class DataSheet
        {
         //   public string name { get;, set; }

         //   public string email { get;, set; }

        //    public string website { get; , set; }

         //   public string comment { get; , set; }


        }

        public static System.Data.DataSet GetExcelData(string Workbook)
        {


            
            DataSet SeleniumElementSet = new DataSet();
            var excelApp = new Excel.Application();
            var datatable = new System.Data.DataTable();
            string[] strrow = new string[2];

            int rCnt = 0;
            int cCnt = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open((AppDomain.CurrentDomain.BaseDirectory + "\\" + Workbook), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
            int worksheetcount = xlWorkBook.Worksheets.Count;
            //int wks = 1;
            for (int wks = 1; wks <= worksheetcount; wks++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(wks);
                String datatablename = xlWorkSheet.Name;
                range = xlWorkSheet.UsedRange;
                //Console.WriteLine(wks);

                var dt = new System.Data.DataTable(datatablename);

                int rowCount = range.Rows.Count;
                int colCount = range.Columns.Count;
                //int colCount = 3;
                string[] headers = new string[colCount];
                for (cCnt = 1; cCnt <= colCount; cCnt++)
                {

                    headers[cCnt - 1] = (Convert.ToString((range.Cells[1, cCnt] as Excel.Range).Value2));
                    dt.Columns.Add(headers[cCnt - 1]);
                    //Console.WriteLine(headers[cCnt - 1]);
                }
                for (rCnt = 2; rCnt <= rowCount; rCnt++)
                {
                    var array = new object[colCount];

                    for (cCnt = 1; cCnt <= colCount; cCnt++)
                    {
                        array[cCnt - 1] = (Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2));

                    }

                    dt.Rows.Add(array);


                }
                SeleniumElementSet.Tables.Add(dt);
            }
            xlApp.Quit();

            return SeleniumElementSet;
        }


    }
            }
