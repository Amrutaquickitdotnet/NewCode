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
	public  class Example_006_checkvalidation
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
		public void CheckValidation() {
			IWebElement Password = driver.FindElement(By.Name("password"));
			Password.SendKeys("admin123");
		IWebElement  LoginButton = 	driver.FindElement(By.XPath("//button[@type='submit']"));
			LoginButton.Click();
          IWebElement Spanmessage = driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-input-field-error-message oxd-input-group__message']"));

			String Title = Spanmessage.Text;
			if (Title.Equals("Required"))
			{
				TestContext.Progress.WriteLine("Validation is present");
			}
			else {

				TestContext.Progress.WriteLine("Validation is not present");
			}




		}
	}
}
