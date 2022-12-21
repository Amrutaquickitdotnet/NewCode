using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace QuickitdotnetSelenium
{
	public class Example_003_ById
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
		public void OpenUrl()
		{
			driver.Url = "https://www.zee5.com/register";
		IWebElement NameElement =	driver.FindElement(By.Name("userName"));
			if (NameElement.Displayed) {
				TestContext.Progress.WriteLine("Yes I can see the WebElement");
			}
			else
			{
				TestContext.Progress.WriteLine("Something wents wrong");
			}
		}
	}
}