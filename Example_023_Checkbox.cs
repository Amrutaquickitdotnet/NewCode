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
	public class Example_023_Checkbox
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
			driver.Navigate().GoToUrl("https:/www.amazon.in");
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		[Test, Order(2)]
		[TestCase("Get It in 2 Days")]
		
		public void verifycheckbox(string displayText)
		{

			IWebElement searchbox = driver.FindElement(By.Id("twotabsearchtextbox"));
			searchbox.SendKeys("Mobiles");

			IWebElement searchbutton = driver.FindElement(By.Id("nav-search-submit-button"));
			searchbutton.Click();
			Thread.Sleep(1000);
			IWebElement checkbox = driver.FindElement(By.XPath("(//li[@aria-label='" + displayText + "'])//input"));
			Thread.Sleep(3000);
			IWebElement checkboxi = driver.FindElement(By.XPath("(//li[@aria-label='" + displayText + "'])//i"));
			checkboxi.Click();
		

		}
	}
}
