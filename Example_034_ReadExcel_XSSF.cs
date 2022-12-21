using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace SeleniumExamples
{
	internal class Example_034_ReadExcel_XSSF
	{

		[Test, Order(1)]
		public void ReadExcel()
		{
			string excelpath = "D:\\Amruta\\Testexcelprogram.xlsx";
			FileStream inputstream = null;
			try
			{
				inputstream = new FileStream(excelpath, FileMode.Open, FileAccess.Read);
			}
			catch (FileNotFoundException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}


			XSSFWorkbook workbook = null;
			try
			{
				workbook = new XSSFWorkbook(inputstream);
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			ISheet sheet = workbook.GetSheet("Sheet1");

			// Using for loop

			int rows = sheet.LastRowNum;
			int cols = sheet.GetRow(1).LastCellNum;

			for (int r = 0; r < rows; r++)
			{

				IRow row = sheet.GetRow(r);

				for (int c = 0; c < cols; c++)
				{

					ICell cell = row.GetCell(c);
					switch (cell.CellType)
					{
						case CellType.String:
							Console.Write(cell.StringCellValue + "\t");
							break;
						case CellType.Numeric:
							Console.Write(cell.NumericCellValue + "\t");
							break;
						case CellType.Boolean:
							Console.Write(cell.BooleanCellValue + "\t");
							break;

					}

				}

				Console.WriteLine();
			}

		}
	}
}

