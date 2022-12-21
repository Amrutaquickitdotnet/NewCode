using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TestProject1;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExamples
{
	public class Example_031_RightClickWithAlert
	{
		IWebDriver driver;
		String Link = "http://swisnl.github.io/jQuery-contextMenu/demo.html";

		[OneTimeSetUp]
		public void Setup()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl(Link);
		}
		[Test, Order(1)]
		public void RightMove()
		{

			IWebElement e = driver.FindElement(By.XPath("//span[@class='context-menu-one btn btn-neutral']"));
			Actions act = new Actions(driver);

			act.MoveToElement(e);
			Thread.Sleep(2000);

			act.ContextClick(e).Build().Perform();
			Thread.Sleep(5000);

			IWebElement copy = driver.FindElement(By.XPath("/html/body/ul/li[3]"));
			act.KeyDown(Keys.ArrowDown).Build().Perform();
			act.KeyDown(Keys.ArrowDown).Build().Perform();
			act.KeyDown(Keys.ArrowDown).Build().Perform();
			copy.Click();

		
			

			
		
		}
	}
}
