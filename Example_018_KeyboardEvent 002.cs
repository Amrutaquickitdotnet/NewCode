using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace QuickitdotnetSelenium
{
	public class KeyboardEvent_002
	{

		IWebDriver driver;

		[OneTimeSetUp]
		public void Launchbrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Manage().Window.Maximize();

		}


		[Test]
		[Order(1)]
		public void OpenUrl()
		{
			driver.Url = "https://jqueryui.com/autocomplete";
		}

		[Test]
		[Order(2)]
		public void KyboardEvent()
		{

			IWebElement frame1 = driver.FindElement(By.ClassName("demo-frame"));
			Thread.Sleep(8000);

			driver.SwitchTo().Frame(frame1);

			Thread.Sleep(8000);


		IWebElement tags =	driver.FindElement(By.XPath("//input[@class='ui-autocomplete-input']"));
			tags.SendKeys("c");
			Thread.Sleep(5000);
			Actions act = new Actions(driver);
			act.KeyDown(Keys.ArrowDown);
			act.Build().Perform();
			Thread.Sleep(5000);


		}

	}
}
