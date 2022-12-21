using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
	internal class mousemove
	{
		public WebDriver driver;
		[OneTimeSetUp]
		public void LaunchBrowser()
		{

			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();


		}
		[Test]
		[Order(1)]
		public void OpenUrl()
		{

			driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
			driver.Manage().Window.Maximize();
			
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);

		}

		[Test]
		[Order(2)]
		public void Login()
		{
			IWebElement Username = driver.FindElement(By.XPath("//input[@name='username']"));

			Username.SendKeys("Admin");
			IWebElement Password = driver.FindElement(By.Name("password"));
			Password.SendKeys("admin123");
			IWebElement LoginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
			LoginButton.Click();
		}

		[Test]
		[Order(3)]
		public void mouseaction()
		{
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
			IWebElement PIM = driver.FindElement(By.XPath("//*[@id='app']/div[1]/div[1]/aside/nav/div[2]/ul/li[2]/a/span"));
			Actions act = new Actions(driver);
			act.MoveToElement(PIM).Perform();
			PIM.Click();
			IWebElement Configuration =driver.FindElement(By.XPath("//*[@id='app']/div[1]/div[1]/header/div[2]/nav/ul/li[1]/span"));
					 act.MoveToElement(Configuration).Perform();
			Configuration.Click();
			IWebElement CustomField =driver.FindElement(By.XPath("//*[@id='app']/div[1]/div[1]/header/div[2]/nav/ul/li[1]/ul/li[2]/a"));
			act.MoveToElement(CustomField).Perform();
			CustomField.Click();
		}
	}
}