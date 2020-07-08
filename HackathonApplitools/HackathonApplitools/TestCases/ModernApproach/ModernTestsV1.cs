using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using HackathonApplitools.PageServices;
using NUnit.Framework;
using Configuration = Applitools.Selenium.Configuration;
using ScreenOrientation = Applitools.VisualGrid.ScreenOrientation;

namespace HackathonApplitools
{
   
    
    public class ModernTestsV1 :Base
    {
        

        [Test]
        public void CrossDeviceElementsTest()
        {
            homePage = new HomePage(Urls.Version1);
            _eyes.Open(homePage.Driver, "Cross-Device Elements Test", "Test 1", Resolution800);
            _eyes.Check(Target.Window().Fully().WithName("Cross-Device Elements Test"));
        }

        [Test]
        public void ShoppingExperienceTest()
        {
            homePage = new HomePage(Urls.Version1);
            homePage.ClickOnFilterOptionByHeaderAndOptionModern("colors", "Black");
            homePage.ClickFilterButtonModern();
            _eyes.Open(homePage._Driver, "Filter Results", "Task 2", Resolution800);
            _eyes.Check("Filter Results", Target.Region(By.Id("product_grid")).Fully());
        }

        [Test]
        public void ProductDetailTest()
        {
            homePage = new HomePage(Urls.Version1);
            productPage = homePage.ClickOnProductImageByProductNameModern("Appli Air x Night");
            SiteDriver.WaitForConditionModern(productPage.IsPageHeaderPresent);
            _eyes.Open(homePage.Driver, "Product Details test", "Task 3", Resolution800);
            _eyes.Check(Target.Window().Fully().WithName("Product Details test"));
        }

       
    }
}
