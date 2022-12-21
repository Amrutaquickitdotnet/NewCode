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
using NPOI.Util.Collections;
using System.Security.Cryptography.X509Certificates;

namespace SeleniumExamples
{
	internal class Example_035_ReadProperties
	{
		WebDriver driver;

		FileStream fs;
		Properties p;
		[OneTimeSetUp]
		public void Setup()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}

		[Test, Order(1)]
		public void ReadData()
		{

			string path = @"D:\Amruta\ReadData.properties";
			// This example will give you idea about File handling with properties 
		
			try
			{
				fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
			}
			catch (FileNotFoundException e1)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e1.ToString());
				Console.Write(e1.StackTrace);
			}


			 p = new Properties();
			try
			{
				System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

				p.Load(fs);
				
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}

		}
		[Test, Order(2)]
		public void Login()
		{
			 
			driver.Manage().Window.Maximize();
			
			driver.Navigate().GoToUrl(p["url"]);

			Thread.Sleep(2000);
			driver.FindElement(By.Name("username")).SendKeys(p["Username"]);
			driver.FindElement(By.Name("password")).SendKeys(p["Password"]);
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();
		}



	}

}
