using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExamples
{
	public class Example_006
	{
		WebDriver driver;
		[OneTimeSetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}


		[Test]
		[Order(1)]
		public void launchBrowser()
		{

			driver.Navigate().GoToUrl("https://www.facebook.com/");
			
		}

		
		[Test]
		[Order(2)]
		public void countryDropdown()
		{
			try
			{

			IWebElement Signup = 	driver.FindElement(By.LinkText("Create New Account"));
				Signup.Click();
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
			    IWebElement monthdropdown =	driver.FindElement(By.XPath("//select[@id='month']"));
				
				SelectElement se = new SelectElement(monthdropdown);
				se.SelectByText("Jan");
				Thread.Sleep(5000);
				se.SelectByValue("4");
				Thread.Sleep(5000);
				se.SelectByIndex(2);
				IList<IWebElement> allCountries = se.Options;

				// print size of items in the list
				Console.WriteLine("There are " + allCountries.Count + " listed in the dropdown");
				Console.WriteLine("Countries list are:");
				foreach (IWebElement countriesList in allCountries)
				{
					TestContext.Progress.WriteLine(countriesList.Text);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
