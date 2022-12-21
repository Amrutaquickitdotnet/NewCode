using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace QuickitdotnetSelenium
{
	public class Example_010_ByLinkText
	{
		IWebDriver driver;

		[SetUp]
		public void Launchbrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.Url = "https://www.facebook.com";
			driver.Manage().Window.Maximize();

		}


		[Test]
		public void OpenUrl()
		{
			
		driver.FindElement(By.Id("email")).SendKeys("Tester");
			
		}
	}
}