using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace TestProject1
{
	internal class Alert
	{
		

		IWebDriver driver;
		String url = "http://the-internet.herokuapp.com/javascript_alerts"	 ;

		[OneTimeSetUp]
		public void start_Browser()
		{

			driver = new ChromeDriver();

			
			driver.Manage().Window.Maximize();

		}

		[Test, Order(1)]
		public void test_alert()
		{
			driver.Navigate().GoToUrl(url);
			String button_xpath = "//button[.='Click for JS Alert']";
			var expectedAlertText = "I am a JS Alert";

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			


			IWebElement alertButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(button_xpath)));
			alertButton.Click();

			var alert_win = driver.SwitchTo().Alert();
			Assert.That(alert_win.Text, Is.EqualTo(expectedAlertText));

			alert_win.Accept();

			/* IWebElement clickResult = driver.FindElement(By.Id("result")); */

			var clickResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("result")));

			Console.WriteLine(clickResult.Text);

			if (clickResult.Text == "You successfuly clicked an alert")
			{
				Console.WriteLine("Alert Test Successful");
			}
		}

		[Test, Order(2)]
		public void test_confirm()

		{
			driver.Navigate().GoToUrl(url);
			String button_css_selector = "button[onclick='jsConfirm()']";
			var expectedAlertText = "I am a JS Confirm";

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			

			IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));

			confirmButton.Click();

			var confirm_win = driver.SwitchTo().Alert();
			confirm_win.Accept();

			Assert.That(confirm_win.Text, Is.EqualTo(expectedAlertText));

			IWebElement clickResult = driver.FindElement(By.Id("result"));
			Console.WriteLine(clickResult.Text);

			if (clickResult.Text == "You clicked: Ok")
			{
				Console.WriteLine("Confirm Test Successful");
			}
		}

		[Test, Order(3)]
		public void test_dismiss()
		{
			driver.Navigate().GoToUrl(url);

			String button_css_selector = "button[onclick='jsConfirm()']";

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			var expectedAlertText = "I am a JS Confirm";

			IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));

			confirmButton.Click();

			var confirm_win = driver.SwitchTo().Alert();
			confirm_win.Dismiss();

			Assert.That(confirm_win.Text, Is.EqualTo(expectedAlertText));

			IWebElement clickResult = driver.FindElement(By.Id("result"));
			Console.WriteLine(clickResult.Text);

			if (clickResult.Text == "You clicked: Cancel")
			{
				Console.WriteLine("Dismiss Test Successful");
			}
		}

		[Test, Order(4)]
		public void test_sendalert_text()
		{
			driver.Navigate().GoToUrl(url);

			String button_css_selector = "button[onclick='jsPrompt()']";
			

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			

			IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));
			confirmButton.Click();

			var alert_win = driver.SwitchTo().Alert();
			Thread.Sleep(12000);
			alert_win.SendKeys("Welcome to quickitdotnet");
			Thread.Sleep(12000);
			alert_win.Accept();
			Thread.Sleep(8000);

			IWebElement clickResult = driver.FindElement(By.Id("result"));
			Console.WriteLine(clickResult.Text);

			if (clickResult.Text == "You entered: This is a test alert message")
			{
				Console.WriteLine("Send Text Alert Test Successful");
			}
		}
	}
}
