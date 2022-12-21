using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumExamples
{
	internal class Example_032_DatePicker
	{
		public WebDriver driver;
		[OneTimeSetUp]
		public void LaunchBrowser()
		{

			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();


		}
		[Test, Order(1)]
			
			
			  public void SelectDate() { 
				driver.Navigate().GoToUrl("http://seleniumpractise.blogspot.com/2016/08/how-to-handle-calendar-in-selenium.html"); // launch the url.

				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // wait for 10 seconds for the page to load.

				driver.FindElement(By.XPath("//*[text()='Date: ']/input")).Click(); // find the calendar input field and click on it.

				List<IWebElement> tableContent = new List<IWebElement>(driver.FindElements(By.XPath("//table[@class='ui-datepicker-calendar']//td"))); // get all the dates.

				foreach (IWebElement ele in tableContent) // use foreach iterate each cell.
				{
					string date = ele.Text; // get the text of the element.

					if (date.Equals("20")) // check if the date is 20
					{
						ele.Click(); // if date is 20, select it.
						break;
					}
				
				}
			Thread.Sleep(6000);
			//driver.Close(); // close the driver.
		}
		}
	}

