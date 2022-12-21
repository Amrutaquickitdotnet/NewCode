using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;

namespace QuickitdotnetSelenium
{
	internal class Example_030_Pop_Up_Test
	{
		IWebDriver driver;

		[OneTimeSetUp]
		public void Launchbrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Manage().Window.Maximize();

		}

		[Test, Order(1)]
		public void Test_window_ops()
		{
			String test_url = "https://www.webroot.com/services/popuptester1.htm";
			String expected_win_title = "";

			driver.Url = test_url;

			/* Not a good practice to use Thread.Sleep as it is a blocking call */
			/* Used here for demonstration */
			System.Threading.Thread.Sleep(8000);

			String windowTitle = GetCurrWindowTitle();
			String mainWindow = GetMainWinHandle(driver);
			Assert.IsTrue(CloseAllWindows(mainWindow));

			/* Addition of delay for checking the output */
			System.Threading.Thread.Sleep(4000);
			Assert.IsTrue(windowTitle.Contains(expected_win_title), "Title does not match - Test Failed");
		}

	
		public String GetCurrWindowTitle()
		{
			String windowTitle = driver.Title;
			return windowTitle;
		}




		/* API - Get Window Handle */
		public String GetMainWinHandle(IWebDriver driver)
		{
			return driver.CurrentWindowHandle;
		}

		/* The test website open-ups number of pop-ups */
		/* API - Close all the pop-ups and return to the primary window */


		public Boolean CloseAllWindows(String currWindowHandle)
		{
			IList<string> totWindowHandles = new List<string>(driver.WindowHandles);

			foreach (String WindowHandle in totWindowHandles)
			{
				Console.WriteLine(WindowHandle);
				if (!WindowHandle.Equals(currWindowHandle))
				{
					driver.SwitchTo().Window(WindowHandle);
					driver.Close();
				}
			}

			driver.SwitchTo().Window(currWindowHandle);
			if (driver.WindowHandles.Count == 1)
				return true;
			else
				return false;
		}


	}


}

