//using System;
//using System.Collections.Generic;
//using System.Text;
//using HackathonApplitools.PageServices;
//using NUnit.Framework;

//namespace HackathonApplitools
//{
//    public class HomeTraditional
//    { 
//        public HomePage homePage;

//        [SetUp]
//        public void Initialize()
//        {
//            Console.WriteLine("Test Initialized");
//        }

//        [Test]
//        public void Verify_Header_bar_contents()
//        {

//            homePage = new HomePage(Urls.Version1);
//            //Assert.IsTrue(homePage.IsAppliFashionLogoPresent(),"Is AppliFashion Logo present?");

//        }




//        [TearDown]
//        public void TestCleanUp()
//        {
//            SiteDriver.Close();
//        }
//    }
//}
