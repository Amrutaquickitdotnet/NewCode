using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace SeleniumExamples
{


	[TestFixture]
	public class GenerateReport
	{

		static AventStack.ExtentReports.ExtentReports extent = null;
		public WebDriver driver;
		ExtentTest test = null;


		[OneTimeSetUp]
		public void ExtentStart()
		{



			extent = new AventStack.ExtentReports.ExtentReports();
			var Htmlreporter = new ExtentHtmlReporter(@"D:\seleniumc#\SeleniumExamples\ExtentReports\Report.html");
			extent = new AventStack.ExtentReports.ExtentReports();
			extent.AttachReporter(Htmlreporter);



		}




		[OneTimeSetUp]
		public void LaunchBrowser()
		{

			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();


		}

		[Test]

		public void Login()
		{


			test = extent.CreateTest("Test1").Info("Test Srarted");
			driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
			test.Log(Status.Info, "chrome browser launched");
		
			
			Thread.Sleep(6000);
			IWebElement Username = driver.FindElement(By.XPath("//input[@name='username']"));


			Username.SendKeys("Admin");

			IWebElement Password = driver.FindElement(By.XPath("//input[@name='password']"));

			Password.SendKeys("admin123");

			IWebElement LoginButton = driver.FindElement(By.XPath("//button[@type='submit']"));

			LoginButton.Click();

			test.Log(Status.Pass, "User Landing on Dashboard Page");
		}



	}

}
	


