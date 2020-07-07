using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using HackathonApplitools.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;

namespace HackathonApplitools.PageServices
{
    public class HomePage
    {
        public IWebDriver Driver { get { return SiteDriver.Driver; } }
        private static IJavaScriptExecutor _javascriptexecutor;

        #region Constructor

        public HomePage(string url)
        {
            SiteDriver.Start(url);
        }
        #endregion

        #region Public Methods

        //Logo
        public bool IsAppliFashionLogoPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.AppliFashionLogoCssSelector, How.CssSelector);

        public void ClickAppliFashionLogo() =>
            SiteDriver.FindElement(HomePageObjects.AppliFashionLogoCssSelector, How.CssSelector).Click();

        //Main Menu
        public List<string> GetMainMenuHeader() =>
            SiteDriver.FindDisplayedElementsText(HomePageObjects.MainMenuHeaderCssSelector, How.CssSelector);

        //Navbar
        public bool IsSearchInputPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.SearchInputCssSelector, How.CssSelector);

        public string GetDefaultSearchInputValue() =>
            SiteDriver.FindElement(HomePageObjects.SearchInputCssSelector, How.CssSelector).Text;

        public bool IsSearchButtonPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.SearchButtonCssSelector, How.CssSelector);

        public bool IsAccountWishlistCartIconPresentByIconName(string icon) =>
            JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.AccountWishlistCartCssTemplate, icon));

        //SideFilter

        public List<string> GetSideFilterHeaders() =>
            SiteDriver.FindDisplayedElementsText(HomePageObjects.SideFilterHeadersCssSelector, How.CssSelector);

        public void ClickSideFilterByHeader(string header) => JavascriptExecutor
            .FindElement(string.Format(HomePageObjects.SideFilterCssTemplate, header)).Click();

        public bool IsSideFilterOpenedByHeader(string header) => JavascriptExecutor
            .FindElement(string.Format(HomePageObjects.SideFilterCssTemplate, header))
            .GetAttribute("class").Contains("opened");

        public List<string> GetSideFilterOptionsByHeader(string header) =>
            JavascriptExecutor.FindElements(string.Format(HomePageObjects.SideFilterListCssTemplate, header));

        public void ClickOnFilterOptionByHeaderAndOption(string header, string option) => JavascriptExecutor
            .FindElement(string.Format(HomePageObjects.SideFilterOptionCssTemplate, header, option))
            .Click();

        public string GetQuantityOfFilterOptionByHeaderAndOption(string header, string option)
            => JavascriptExecutor
                .FindElement(string.Format(HomePageObjects.SideFilterOptionQuantityCssTemplate, header, option)).Text;

        public string IsCheckBoxSelected(string header, string option)
        {
           var obj =  _javascriptexecutor.ExecuteScript(
                "return window.getComputedStyle(document.querySelector('.checkmark'),':after')\r\n    .getPropertyValue('content');\"");
           return obj.ToString();
        }

        public bool IsCheckBoxSelectedByHeaderAndOption(string header, string option)
        {
            return JavascriptExecutor.FindElement(string.Format(HomePageObjects.SideFilterCheckboxCssTemplate, header, option)).Selected;
        }
        public bool IsFilterResetButtonPresentByButtonName(string name) =>
            JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.SideFilterButtonCssTemplate, name));

        public bool IsFilterResetButtonDisabledByButtonId(string id) => JavascriptExecutor
            .IsElementPresent(string.Format(HomePageObjects.SideFilterButtonDisabledCssTemplate, id));

        //Top Banner
        public bool IsTopBannerPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.TopBannerCssSelector, How.CssSelector);

        //ToolBox
        public string GetSelectedSortOption() =>
            SiteDriver.FindElement(HomePageObjects.SelectedSortOptionCssSelector, How.CssSelector).Text;

        public List<string> GetSortOptions() =>
            SiteDriver.FindDisplayedElementsText(HomePageObjects.SortOptionsCssSelector, How.CssSelector);

        public bool IsGridViewIconPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.GridViewIconCssSelector, How.CssSelector);

        public bool IsListViewIconPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.ListViewIconCssSelector, How.CssSelector);

        //Products
        public int GetProductsCount() =>
            SiteDriver.FindElements(HomePageObjects.ProductsCssSelector, How.CssSelector).Count();

        #endregion
    }
}
