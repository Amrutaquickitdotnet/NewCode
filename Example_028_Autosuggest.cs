using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

	public class Autosuggest
	{
		WebDriver driver;
		[OneTimeSetUp]
		public void Setup()
		{


			driver = new ChromeDriver();

			driver.Navigate().GoToUrl("https://duckduckgo.com/");
			driver.Manage().Window.Maximize();
			
			Thread.Sleep(3000);
		}

		[Test, Order(1)]
		public void keyup()
		{

			
			IWebElement element = driver.FindElement(By.XPath("//*[@id='search_form_input_homepage']"));

			element.SendKeys("Selenium WebDriver");

			/* Submit the Search */
			element.Submit();

			/* Perform wait to check the output */
			System.Threading.Thread.Sleep(2000);
		}


	}
	}


		

