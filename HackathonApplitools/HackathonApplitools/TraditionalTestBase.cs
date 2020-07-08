using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using HackathonApplitools.PageServices;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace HackathonApplitools
{
    public class TraditionalTestBase
    {
        public IWebDriver driver;
        public HomePage homePage;

        
        public static IEnumerable<string> BrowserToRunWith()
        {
            string[] browsers = { "chrome", "firefox", "edge", "chrometablet", "firefoxtablet", "edgetablet", "" };
            foreach (var b in browsers)
            {
                yield return b;
            }

        }

        public bool HackathonReport(int task, string testName, string browser, bool compatisonResult)
        {

            using (StreamWriter fs = new StreamWriter("traditional-V1-TestResults.txt", true))
            {
                string ReportContent = string.Format("Task: {0}, Test Name: {1}, Browser {2}, Status: {3}", task,
                    testName, browser, compatisonResult);


                fs.WriteLine(ReportContent);
            }

            //returns the result so that it can be used for further Assertions in the test code.
            return compatisonResult;
        }
    
        public void Setup(string browserName)
        {
            homePage= new HomePage();
            if (browserName.Equals("chrome"))
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Size = new Size(1200,700);
            }
            else if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Size = new Size(1200, 700);
            }

            else if (browserName.Equals("edge"))
            {
                driver = new EdgeDriver();
                driver.Manage().Window.Size = new Size(1200, 700);
            }
            else if(browserName.Equals("chrometablet"))
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Size = new Size(768,700);
            }
            else if (browserName.Equals("firefoxtablet"))
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Size = new Size(768, 700);
            }
            else if (browserName.Equals("edgetablet"))
            {
                driver = new EdgeDriver();
                driver.Manage().Window.Size = new Size(768, 700);
            }
            else
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Size = new Size(500, 700);
            }

        }

        public void Start(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }


    }
}
