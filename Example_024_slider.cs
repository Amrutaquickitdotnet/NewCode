using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace QuickitdotnetSelenium
{
	public class slider
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


		[Test]
		[Order(1)]
		public void OpenUrl()
		{
			driver.Url = "https://jqueryui.com/slider/";
		}

		[Test]
		[Order(2)]
		public void SliderTest() {
		IWebElement frame1 =	driver.FindElement(By.ClassName("demo-frame"));
			Thread.Sleep(8000);

			driver.SwitchTo().Frame(frame1);

			Thread.Sleep(8000);

			IWebElement Slider = driver.FindElement(By.Id("slider"));

			Actions move = new Actions(driver);

			//move.DragAndDropToOffset(Slider, 10, 70).Build().Perform();

			move.ClickAndHold(Slider);
			move.MoveByOffset(10, 70);
			move.Release(Slider).Build().Perform();


			
		}
	}
}

