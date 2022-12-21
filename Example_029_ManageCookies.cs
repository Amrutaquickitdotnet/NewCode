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
	internal class Example_029_ManageCookies
	{

		public WebDriver driver;

		
		[OneTimeSetUp]
		public void Setup()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();

		}

		[Test, Order(1)]
		public void Addcookies()
		{

			
				String Weblink = "https://www.facebook.com";
				// Navigate to Url
				driver.Navigate().GoToUrl(Weblink);

				// Adds the cookie into current browser context
				driver.Manage().Cookies.AddCookie(new Cookie("key", "value"));

				Console.WriteLine("Added Cookie");


			var cookie = driver.Manage().Cookies.GetCookieNamed("key");
			Console.WriteLine("Cookie name is :"+cookie);


			driver.Manage().Cookies.AddCookie(new Cookie("Name", "Amruta"));
			driver.Manage().Cookies.AddCookie(new Cookie("City", "Pune"));
			driver.Manage().Cookies.AddCookie(new Cookie("Country", "India"));
			
			var Cookie1 = driver.Manage().Cookies.GetCookieNamed("Name");

			var Cookie2 = driver.Manage().Cookies.GetCookieNamed("City");
			var Cookie3 = driver.Manage().Cookies.GetCookieNamed("Country");

			Console.WriteLine("Getting cookies by name:"+ Cookie1);
			Console.WriteLine("Getting cookies by City:" + Cookie2);
			Console.WriteLine("Getting cookies by Country:" + Cookie3);



			// delete a cookie with name 'City'	
			driver.Manage().Cookies.DeleteCookieNamed("City");

			

			// Selenium .net bindings also provides a way to delete
			// cookie by passing cookie object of current browsing context

			driver.Manage().Cookies.DeleteAllCookies();

			Console.WriteLine("Cookies Deleted");
		}

	}
		
			
		
				
}

