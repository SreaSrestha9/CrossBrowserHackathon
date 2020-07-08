using System;
using System.Collections.Generic;
using System.Text;
using Applitools.Selenium;
using HackathonApplitools.PageServices;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HackathonApplitools
{
    
    public class ModernTestsV2 : Base
    {
        [Test]
        public void CrossDeviceElementsTest()
        {
            homePage = new HomePage(Urls.Version2);
            _eyes.Open(homePage.Driver, "Cross-Device Elements Test", "Test 1", Resolution800);
            _eyes.Check(Target.Window().Fully().WithName("Cross-Device Elements Test"));
        }

        [Test]
        public void ShoppingExperienceTest()
        {
            homePage = new HomePage(Urls.Version2);
            homePage.ClickOnFilterOptionByHeaderAndOption("colors", "Black");
            homePage.ClickFilterButton();
            _eyes.Open(homePage.Driver, "Filter Results", "Task 2", Resolution800);
            _eyes.Check("Filter Results", Target.Region(By.Id("product_grid")).Fully());
        }

        [Test]
        public void ProductDetailTest()
        {
            homePage = new HomePage(Urls.Version2);
            productPage = homePage.ClickOnProductImageByProductName("Appli Air x Night");
            SiteDriver.WaitForCondition(productPage.IsPageHeaderPresent);
            _eyes.Open(homePage.Driver, "Product Details test", "Task 3", Resolution800);
            _eyes.Check(Target.Window().Fully().WithName("Product Details test"));
        }
    }
}
