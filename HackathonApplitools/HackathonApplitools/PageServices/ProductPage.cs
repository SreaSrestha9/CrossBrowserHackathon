using System;
using System.Collections.Generic;
using System.Text;
using HackathonApplitools.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HackathonApplitools.PageServices
{
    public class ProductPage
    {

        public IWebDriver Driver { get { return SiteDriver.Driver; } }
        private static IJavaScriptExecutor _javascriptexecutor;

        #region Public Methods

        public bool IsPageHeaderPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.PageHeaderCssSelector, How.CssSelector);

        #endregion
    }
}
