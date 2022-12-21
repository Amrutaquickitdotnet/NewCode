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
	public class Example_022_TakingScreenshot
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
			driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php");
				 driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);
		}

		[Test]
		[Order(2)]
		public void login()
		{

			IWebElement Username = driver.FindElement(By.XPath("//input[@name='username']"));

			Username.SendKeys("Admin");

			IWebElement Password = driver.FindElement(By.XPath("//input[@name='password']"));

			Password.SendKeys("admin123");

			IWebElement LoginButton = driver.FindElement(By.XPath("//button[@type='submit']"));

			LoginButton.Click();

			Thread.Sleep(8000);

			//((ITakesScreenshot)driver).GetScreenshot()

			ITakesScreenshot iscreenshot = driver as ITakesScreenshot;
			Screenshot screenshot = iscreenshot.GetScreenshot();
			screenshot.SaveAsFile(@"D:\Images\Screenshot.png", ScreenshotImageFormat.Png);

		}





	}
}
