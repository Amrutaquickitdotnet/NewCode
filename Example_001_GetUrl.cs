using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace QuickitdotnetSelenium
{
	
	public class Example_001_GetUrl
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
		[Order(1)]
		public void OpenUrl()
		{
			driver.Url = "https://www.google.com";
		}
	}
}