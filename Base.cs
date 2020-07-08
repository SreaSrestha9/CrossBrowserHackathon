using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using HackathonApplitools.PageServices;
using NUnit.Framework;
using Configuration = Applitools.Selenium.Configuration;

namespace HackathonApplitools
{
    public class Base
    {
        public Eyes _eyes;
        public VisualGridRunner runner;
        public HomePage homePage;
        public ProductPage productPage;
        public Configuration config;
        public Size Resolution800 = new Size(800, 600);

        [SetUp]
        public void Initialize()
        {
            //Initialize the Runner for your test.
            runner = new VisualGridRunner(10);

            // Initialize the eyes SDK (IMPORTANT: make sure your API key is set in the APPLITOOLS_API_KEY env variable).
            _eyes = new Eyes(runner);


            // Initialize eyes Configuration
            config = new Configuration();
            config.SetApiKey("TlTMI102RD5Kl0PGlP1SLRTb6x5Idiomwl5YuF79ibDBs110");
            config.SetBatch(new BatchInfo("UFG Hackathon"));
            // Add browsers with different viewports
            config.AddBrowser(1200, 700, BrowserType.CHROME);
            config.AddBrowser(1200, 700, BrowserType.FIREFOX);
            config.AddBrowser(1200, 700, BrowserType.EDGE_CHROMIUM);
            config.AddBrowser(768, 700, BrowserType.CHROME);
            config.AddBrowser(768, 700, BrowserType.FIREFOX);
            config.AddBrowser(768, 700, BrowserType.EDGE_CHROMIUM);

            // Add mobile emulation devices in Portrait mode
            config.AddDeviceEmulation(DeviceName.iPhone_X, ScreenOrientation.Portrait);
            config.AddDeviceEmulation(DeviceName.Pixel_2, ScreenOrientation.Portrait);

            // Set the configuration object to eyes
            _eyes.SetConfiguration(config);


        }

        [TearDown]
        public void TestCleanUp()
        {
            _eyes.CloseAsync();
            SiteDriver.Close();
            TestResultsSummary allTestResults = runner.GetAllTestResults();
            Console.WriteLine(allTestResults);
        }
    }
}
