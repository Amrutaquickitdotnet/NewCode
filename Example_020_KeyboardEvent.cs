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
	public class KeyboardEvent
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
			driver.Url = "https://google.co.in";
		}

		[Test]
		[Order(2)]
		public void KyboardEvent()
		{
			driver.Url = "https://google.co.in";

			IWebElement Link = driver.FindElement(By.LinkText("Gmail"));


			Actions act = new Actions(driver);

			//below are mouse action code
			//act.MoveToElement(Link).Build().Perform();
			//Link.Click();
						 // below code with help of Keyboard Keys
			act.KeyDown(Keys.Shift).Click(Link).KeyUp(Keys.Shift).Build().Perform();
						  // shift => Keydown
		}

	}
}
