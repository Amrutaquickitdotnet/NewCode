using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.IO; // we need this namespace for working with  directories and files, a reference needs to be added for this
using System.IO.Compression;// we need this namespace for working with zip files , a reference needs to be added for this
using System.Threading.Tasks;

namespace SeleniumExamples
{
	internal class DownloadFile
	{
		string currentFile = string.Empty;
		static string name = string.Empty;
		bool result = false;

		IWebDriver driver;

		[OneTimeSetUp]
		public void Initialize()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
		}


		[Test, Order(1)]
		public void Download_Demo()
		{
			driver.Navigate().GoToUrl("D:/Amruta");//browse the URL 
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			name = driver.FindElement(By.LinkText("Amruta.zip")).Text; //we store the zip filename in a variable 
			driver.FindElement(By.LinkText("Amruta.zip")).Click();//this downloads the zip file
			Task.Delay(5000).Wait();//wait for sometime till download is completed
			string path = "C:\\Users\\AjayV\\Downloads";//the path of the folder where the zip file will be downloaded

			if (Directory.Exists(path)) //we check if the directory or folder exists
			{
				bool result = CheckFile("C:\\Users\\AjayV\\Downloads\\Amruta.zip"); // boolean result true or false is stored after checking the zip file name
				if (result == true)
				{
					ExtractFiles();// if the zip file is present , this method is called to extract files within the zip file
				}

				else
				{
					Assert.Fail("The file does not exist.");// if the zip file is not present, then the  test fails
				}
			}
			else
			{
				Assert.Fail("The directory or folder does not exist.");//if the directory or folder does not exist, then the test fails
			}
		}


		//[TestCase("D:\Amruta\Amruta.zip\ReadData.properties")]
		public bool CheckFile(string name) // the name of the zip file which is obtained, is passed in this method
		{
			currentFile = name; // the zip filename is stored in a variable
			if (File.Exists(currentFile)) //helps to check if the zip file is present
			{
				return true; //if the zip file exists return boolean true
			}
			else
			{
				return false; // if the zip file does not exist return boolean false
			}
		}

		 
		public void ExtractFiles()
		{
			 
			string newExtractFolder = @"D:\Amruta\Amruta\Downloads\Extract";

			if (Directory.Exists(newExtractFolder)){
				Directory.Delete(newExtractFolder, true);
			}
			// we provide a path ( i.e. @"C:\Users\abc\Downloads\) and a name (i.e. Extract) for the new folder which will store files within the zip file
			ZipFile.ExtractToDirectory(currentFile, newExtractFolder);
			// we extract contents of the zip file to the  new folder which has been created
			VerifyFiles(newExtractFolder); //we call this method and pass the path of the folder where extracted files are stored
		}

		public void VerifyFiles(string newExtractFolder)
		{
			string[] fileEntries = Directory.GetFiles(newExtractFolder);// we obtain and store files within the "Extract" folder in an array 
			List<string> listItemsName = new List<string>();//we create a list of string which will store these  files individually
			for (int i = 0; i < fileEntries.Length; i++)
			{
				string[] split = fileEntries[i].Split('\\');
				listItemsName.Add(split.Last());
			}
			List<string> originalList = new List<string> { "ReadData.properties", "Testexcelprogram.xls" , "selenium-server-4.7.2.jar" };// the files which we expect to be  present
			result = originalList.Count == listItemsName.Count && originalList.All(listItemsName.Contains);
			//compare two lists if they have the same number of items and 
			//check that all items are same, by using contains we ensure that both lists have same items, 
			//irrespective of the order(ascending or descending) of items within the lists
			if (result == true)
			{
				Console.WriteLine("The expected files are present.");
				DeleteFilesAndDirectory();//delete the test data
				Assert.Pass("The expected files are present.");
			}
			else
			{
				Console.WriteLine("The expected files are not present.");
				DeleteFilesAndDirectory();//delete the test data
				Assert.Fail("The expected files are not present.");
			}
		}

		[Test, Order(3)]
		public void DeleteFilesAndDirectory()
		{
			if (Directory.Exists(@" D:\Amruta\Extract"))
			{
				Directory.Delete(@" D:\Amruta\Extract", true);//cleanup created folder which has any content inside it.
																		   //true ensures that folder is deleted even if it is not empty. 
			}
			if (File.Exists(currentFile))
			{
				File.Delete(currentFile); //delete the downloaded zip file
			}
		}


	}
}
