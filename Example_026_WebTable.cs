using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExamples
{
	public class Example_026_WebTable
	{
		public WebDriver driver;

		[OneTimeSetUp]
		public void Setup()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}
		[Test, Order(1)]
		public void TestTable()
		{

			driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");
			Thread.Sleep(8000);

			// xpath of html table
			var elemTable = driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));

			// Fetch all Row of the table
			List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
			String strRowData = "";

			// Traverse each row
			foreach (var elemTr in lstTrElem)
			{
				// Fetch the columns from a particuler row
				List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
				if (lstTdElem.Count > 0)
				{
					// Traverse each column
					foreach (var elemTd in lstTdElem)
					{
						// "\t\t" is used for Tab Space between two Text
						strRowData = strRowData + elemTd.Text + "\t";
					}
				}
				else
				{
					// To print the data into the console
					Console.WriteLine("*******This is Header Row*******"+"\n");
					Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t"));
				}
				Console.WriteLine(strRowData);
				strRowData = String.Empty;
			}
			Console.WriteLine("");
		}
	}
		}

