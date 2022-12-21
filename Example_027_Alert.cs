using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExamples
{
	public class Example_027_Alert
	{
		public WebDriver driver;
		String url = "http://the-internet.herokuapp.com/javascript_alerts";
		[OneTimeSetUp]
		public void Setup()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}


		[Test, Order(1)]
		public void Test_alert()
		{

			driver.Navigate().GoToUrl(url);
			Thread.Sleep(8000);

			String button_xpath = "//button[.='Click for JS Alert']";

			var expectedAlertText = "I am a JS Alert";

			// putting fluent wait in selenium

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			IWebElement AlertButton = wait.Until(SeleniumExtras.WaitHelpers
					.ExpectedConditions
					.ElementExists(By.XPath(button_xpath)));

			AlertButton.Click();

			var Alert_win = driver.SwitchTo().Alert();

			Assert.That(Alert_win.Text, Is.EqualTo(expectedAlertText));

			Alert_win.Accept();
			IWebElement ClickResult = wait.Until(SeleniumExtras.WaitHelpers
					.ExpectedConditions
					.ElementExists(By.Id("result")));

			Console.WriteLine(ClickResult.Text);

			if (ClickResult.Text == "You successfully clicked an alert")
			{


				Console.WriteLine("Alert Test is Successful");
			}






		}
		[Test, Order(2)]
		public void Test_sendalert_text()
		{

			driver.Navigate().GoToUrl(url);
			var expectedAlertpromptText = "I am a JS prompt";

			String button_Xpath= "//button[.='Click for JS Prompt']";


			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			IWebElement ConfirmButton = wait.Until(SeleniumExtras.WaitHelpers
					.ExpectedConditions
					.ElementExists(By.XPath(button_Xpath)));

			ConfirmButton.Click();

			var Alert_win1 = driver.SwitchTo().Alert();

			Alert_win1.SendKeys("Welcome to quickitdotnet");
			Thread.Sleep(10000);

			Assert.That(Alert_win1.Text, Is.EqualTo(expectedAlertpromptText));
			Thread.Sleep(3000);
			
			Alert_win1.Accept();

		

			Thread.Sleep(5000);
			IWebElement clickresult =  driver.FindElement(By.Id("result"));

			Console.WriteLine(clickresult.Text);


			if (clickresult.Text == "You entered: This is test")
			{

				Console.WriteLine("Send Text Alert Test Successful");
			}
			else {
				Console.WriteLine("Something went wrong");
			}
		}
	}

}