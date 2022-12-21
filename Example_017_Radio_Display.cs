using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExamples
{
	public class Example_017_Radio_Display
	{
		public WebDriver driver;

		[OneTimeSetUp]
		public void Setup()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}

		


		[Test]
		[Order(1)]
		public void launchBrowser()
		{
			driver.Navigate().GoToUrl("https://www.quickitdotnet.co.in/practice-project");

		}

		[Test]
		[Order(2)]
		public void radio()
		{

			Thread.Sleep(2000);
			
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollBy(0,560)");

			IWebElement Otherradio = driver.FindElement((By.XPath("//input[@class='form-check-input']")));
			Thread.Sleep(2000);


			Boolean selectState = Otherradio.Displayed;

			//performing click operation only if element is not selected
			if (selectState == false)
			{
				Otherradio.Click();
				Console.WriteLine("Other button is enabled");
			}
			
			else
			{
				Console.WriteLine("Other button is disabled");
			}
			Thread.Sleep(2000);
			Assert.IsFalse(!Otherradio.Enabled, "Other button is disabled");

		}
	}
}

