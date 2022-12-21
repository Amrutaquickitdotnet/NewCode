using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExamples
{
	public  class Example_003_checkTitle
	{
		public WebDriver driver;
		[OneTimeSetUp]
		public void LaunchBrowser() {

			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();


		}
		[Test]
		[Order(1)]
		public void OpenUrl() {
			
			driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
			driver.Manage().Window.Maximize();
			//implicit , explicit
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);

		}

		[Test]
		[Order(2)]
		public void CheckTitle() {

		IWebElement  title = 	driver.FindElement(By.XPath("//h5[@class='oxd-text oxd-text--h5 orangehrm-login-title']"));
			String expectedTitle = title.Text;


			if (expectedTitle.Equals("LOGIN", System.StringComparison.Ordinal)) {
				TestContext.Progress.WriteLine("Title is present ");
			}
			else
			{
				TestContext.Progress.WriteLine(" Title is not present");
				Assert.That("LOGin", Is.EqualTo(expectedTitle));
			}

	
		}
	}
}
