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
	public class Example_009_RadioSelection
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
		public void radio()
		{
			// As we can see, all the radio buttons are being created using the HTML tag <input> and have an attribute named "type", 
			//which has a value "radio", which signifies that the type of the input element is a radio button.

			//Now, let's see how we can locate and perform specific actions on the Radion Buttons using Selenium WebDriver?
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollBy(0,550)");
			IWebElement radioElement = driver.FindElement(By.Id("radio2"));
			Thread.Sleep(5000);

			radioElement.Click();
			TestContext.Progress.WriteLine("Radio is Selected");
			Thread.Sleep(5000);
		}
	}
}

