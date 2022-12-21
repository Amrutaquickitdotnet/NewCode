using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
	internal class setdimension
	{
		WebDriver driver;

		[OneTimeSetUp]
		public void Setup()
		{

			driver = new ChromeDriver();
			Console.WriteLine(driver.Manage().Window.Size);

			var size = driver.Manage().Window.Size;
			size.Width = 480;
			size.Height = 900;
			driver.Manage().Window.Size = size;
			Console.WriteLine(driver.Manage().Window.Size);
		}


		[Test]
		public void launchBrowser()
		{
			driver.Navigate().GoToUrl("http://quickitdotnet.co.in/");




		}
	}
}
