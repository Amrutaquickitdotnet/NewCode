using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
	internal class Example_016_Frame
	{
		IWebDriver driver;
		String url = "http://the-internet.herokuapp.com/javascript_alerts";

		[OneTimeSetUp]
		public void start_Browser()
		{

			driver = new ChromeDriver();


			driver.Manage().Window.Maximize();

		}

		[Test, Order(1)]
		public void test_frame_left()
		{
			String test_url = "http://the-internet.herokuapp.com/nested_frames";

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			driver.Url = test_url;

			/**************** Switching to the Left Frame ****************/
			/* Switch to the Parent frame before switching to any of the Child frames */
			driver.SwitchTo().ParentFrame();

			/* Since the top frame is a Framset, switch to that frameset first */
			driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'frame-top']")));

			/* As we are already in the frameset, we can now switch to the new frame */
			driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'frame-left']")));

			/* Reference - https://stackoverflow.com/questions/37791547/selenium-webdriver-get-current-frame-before-switch */

			IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
			var currentFrame = jsExecutor.ExecuteScript("return self.name");
			Console.WriteLine(currentFrame);
		}

		[Test, Order(2)]
		public void test_frame_middle()
		{
			String test_url = "http://the-internet.herokuapp.com/nested_frames";

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			driver.Url = test_url;

			/**************** Switching to the Left Frame ****************/
			/* Switch to the Parent frame before switching to any of the Child frames */
			driver.SwitchTo().ParentFrame();

			/* Since the top frame is a Framset, switch to that frameset first */
			driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'frame-top']")));

			/* As we are already in the frameset, we can now switch to the new frame */
			driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'frame-middle']")));

			/* Reference - https://stackoverflow.com/questions/37791547/selenium-webdriver-get-current-frame-before-switch */

			IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
			var currentFrame = jsExecutor.ExecuteScript("return self.name");
			Console.WriteLine(currentFrame);
		}

		[Test, Order(3)]
		public void test_frame_right()
		{
			String test_url = "http://the-internet.herokuapp.com/nested_frames";

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			driver.Url = test_url;

			/**************** Switching to the Left Frame ****************/
			/* Switch to the Parent frame before switching to any of the Child frames */
			driver.SwitchTo().ParentFrame();

			/* Since the top frame is a Framset, switch to that frameset first */
			driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'frame-top']")));

			/* As we are already in the frameset, we can now switch to the new frame */
			driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'frame-right']")));

			/* Reference - https://stackoverflow.com/questions/37791547/selenium-webdriver-get-current-frame-before-switch */

			IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
			var currentFrame = jsExecutor.ExecuteScript("return self.name");
			Console.WriteLine(currentFrame);
		}

		[Test, Order(4)]
		public void test_single_frame()
		{
			String test_url = "http://the-internet.herokuapp.com/nested_frames";

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			driver.Url = test_url;

			/**************** Switching to the Left Frame ****************/
			/* Switch to the Parent frame before switching to any of the Child frames */
			driver.SwitchTo().ParentFrame();

			/* Directly switch to the new frame */
			driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name = 'frame-bottom']")));

			/* Reference - https://stackoverflow.com/questions/37791547/selenium-webdriver-get-current-frame-before-switch */

			IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
			var currentFrame = jsExecutor.ExecuteScript("return self.name");
			Console.WriteLine(currentFrame);
		}

	}
}
