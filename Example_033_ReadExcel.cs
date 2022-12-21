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

namespace SeleniumExamples
{
	internal class Example_033_ReadExcel
	{



		[Test, Order(1)]
		public void ReadExcel()
		{

			string data = "D:\\Amruta\\Testexcelprogram.xls";

			FileStream fs = new FileStream(data, FileMode.Open, FileAccess.Read); //FileIputStream => to read Data from xls

			HSSFWorkbook wb = new HSSFWorkbook(fs);

			HSSFSheet sh = (HSSFSheet)wb.GetSheet("Sheet1");


			//	int TotalRows = sh.getLastRowNum();
			int TotalRows = sh.LastRowNum;

			for (int row = 0; row < TotalRows; row++)
			{
				IRow rObj = sh.GetRow(row);

				int TotalColumns = rObj.LastCellNum;
				for (int column = 0; column <= TotalColumns; column++)
				{

					ICell ce = rObj.GetCell(column);

					if (ce != null)
					{

						//string str = ce.getStringCellValue();
						string str = ce.StringCellValue;

						if (!string.ReferenceEquals(str, null))
						{



							Console.Write(str + "\t");
						}
					}

				}
				Console.WriteLine(" ");
			}

		}
	}
	}

