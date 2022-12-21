using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace QuickitdotnetSelenium
{
	public class Example_007_ClassName
	{
		IWebDriver driver;

		[SetUp]
		public void Launchbrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			
			driver.Manage().Window.Maximize();

		}


		[Test]
		public void InspectElementByClassName()
		{
			driver.Url = "https://www.practo.com";
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
			driver.FindElement(By.ClassName("btn-border nav-login nav-interact ")).Click();

		}
	}
}