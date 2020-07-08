using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using HackathonApplitools.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;


namespace HackathonApplitools.PageServices
{
    public class HomePage
    {
        public IWebDriver Driver { get { return SiteDriver.Driver; } }
        private static IJavaScriptExecutor _javascriptexecutor;

        public IWebDriver _Driver
        {
            get { return SiteDriver._Driver; }
        }

        #region Constructor

        public HomePage(string url)
        {
            SiteDriver.Start(url);
        }

        public HomePage()
        {
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
            SiteDriver.FindElement(HomePageObjects.SearchInputCssSelector, How.CssSelector).GetAttribute("placeholder");

        public bool IsSearchButtonPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.SearchButtonCssSelector, How.CssSelector);

        public bool IsAccountWishlistIconPresentByIconName(string icon) =>
            JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.AccountWishlistCssTemplate, icon));

        public bool IsCartIconPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.CartCssSelector, How.CssSelector);

        public string GetCartQuanity() =>
            SiteDriver.FindElement(HomePageObjects.CartQuantityCssSelector, How.CssSelector).Text;

        //SideFilter

        public List<string> GetSideFilterHeaders() =>
            SiteDriver.FindDisplayedElementsText(HomePageObjects.SideFilterHeadersCssSelector, How.CssSelector);

        public void ClickSideFilterByHeader(string header) => JavascriptExecutor
            .FindElement(string.Format(HomePageObjects.SideFilterCssTemplate, header)).Click();

        public bool IsSideFilterOpenedByHeader(string header) => JavascriptExecutor
            .FindElement(string.Format(HomePageObjects.SideFilterCssTemplate, header))
            .GetAttribute("class").Contains("opened");

        public List<string> GetSideFilterOptionsByHeader(string header)
        {
            var options = JavascriptExecutor.FindElements(string.Format(HomePageObjects.SideFilterListCssTemplate, header))
                .Select(x=>x.Split('\n')[0]).ToList();
            return options;

        }


        public void ClickOnFilterOptionByHeaderAndOptionModern(string header, string option) => JavascriptExecutor
            .FindElementModern(string.Format(HomePageObjects.SideFilterOptionCssTemplate, header, option))
            .Click();

        public void ClickOnFilterOptionByHeaderAndOption(string header, string option) => JavascriptExecutor
            .FindElement(string.Format(HomePageObjects.SideFilterOptionCssTemplate, header, option))
            .Click();

        public string GetQuantityOfFilterOptionByHeaderAndOption(string header, string option)
            => JavascriptExecutor
                .FindElement(string.Format(HomePageObjects.SideFilterOptionQuantityCssTemplate, header, option)).Text;

        public bool IsSidefilterQuantityPresentByHeaderAndOption(string header, string option) => JavascriptExecutor
            .IsElementPresent(string.Format(HomePageObjects.SideFilterOptionQuantityCssTemplate, header, option));
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
            JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.SideFilterResetButtonCssTemplate, name));

        public bool IsFilterResetButtonDisabledByButtonId(string id) => JavascriptExecutor
            .IsElementPresent(string.Format(HomePageObjects.SideFilterButtonDisabledCssTemplate, id));

        public void ClickFilterButtonModern()
        {
            JavascriptExecutor.FindElementModern(string.Format(HomePageObjects.SideFilterResetButtonCssTemplate, "Filter")).Click();
            SiteDriver.WaitToLoadNew(100);
        }

        public void ClickFilterButton()
        {
            JavascriptExecutor.FindElement(string.Format(HomePageObjects.SideFilterResetButtonCssTemplate, "Filter")).Click();
            SiteDriver.WaitToLoadNew(100);
        }

        //Top Banner
        public bool IsTopBannerPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.TopBannerCssSelector, How.CssSelector);

        //ToolBox
        public string GetSelectedSortOption() =>
            SiteDriver.FindElement(HomePageObjects.SelectedSortOptionCssSelector, How.CssSelector).Text.Trim();

        public bool IsSortOptionPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.SelectedSortOptionCssSelector, How.CssSelector);
        public List<string> GetSortOptions() =>
            SiteDriver.FindDisplayedElementsText(HomePageObjects.SortOptionsCssSelector, How.CssSelector).Select(x=>x.Trim()).ToList();

        public bool IsGridViewIconPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.GridViewIconCssSelector, How.CssSelector);

        public bool IsListViewIconPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.ListViewIconCssSelector, How.CssSelector);

        //Products
        public string GetProductsCount() =>
            SiteDriver.FindElements(HomePageObjects.ProductsCssSelector, How.CssSelector).Count().ToString();

        public ProductPage ClickOnProductImageByProductNameModern(string name)
        {
            SiteDriver.FindElementModern(string.Format(HomePageObjects.ProductDetailLinkByImageCssTemplate, name), How.CssSelector).Click();
            return new ProductPage();
        }
        public ProductPage ClickOnProductImageByProductName(string name)
        {
            SiteDriver.FindElement(string.Format(HomePageObjects.ProductDetailLinkByImageCssTemplate, name), How.CssSelector).Click();
            return new ProductPage();
        }

        public bool IsDiscountBannerPresentById(string id) => JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.ProductWithRibbonCssTemplate, id));

        public bool IsCountDownPresentById(string id) => JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.ProductWithCountdownCssTemplate, id));

        public List<string> GetProductsNewProductsNewPrice() =>  SiteDriver.FindDisplayedElementsText(
            HomePageObjects.ProductNewPricesCssSelector, How.CssSelector);

        public string GetOldPriceList(string id) => JavascriptExecutor
            .FindElement(string.Format(HomePageObjects.OldPriceCssTemplate, id)).Text;

        public string GetFilteredProductNameById(string id) => SiteDriver
            .FindElement(string.Format(HomePageObjects.ProductInFilteredProductCssTemplate, id),
                How.CssSelector).GetAttribute("alt");

       public bool IsAddToFavoriteCompareCartPresentByIds(string productId, string iconId) =>
            SiteDriver.IsElementPresent(
                string.Format(HomePageObjects.AddToFavoriteCompareCartCssTemplate, productId, iconId), How.CssSelector);

       //footer
       public bool IsFooterHeaderPresentByFooterName(string name) =>
           JavascriptExecutor.IsElementPresent(string.Format(ProductDetailPageObject.FooterHeaderCssTemplate, name));

       public List<string> GetQuickLinks() =>
           JavascriptExecutor.FindElements(ProductDetailPageObject.QuickLinksListCssSelector);

       public bool IsHomeIconPresentInContacts() =>
           JavascriptExecutor.IsElementPresent(ProductDetailPageObject.ContactsHomeIconCssSelector);

       public string GetContactLocation() =>
           SiteDriver.FindElement(ProductDetailPageObject.ContactLocationCssSelector,How.CssSelector).Text.Replace("\r\n"," ");

       public bool IsMailIconPresentInContact() =>
           JavascriptExecutor.IsElementPresent(ProductDetailPageObject.ContactEmailIconCssSelector);

       public string GetEmailAddressOfContact() =>
           JavascriptExecutor.FindElement(ProductDetailPageObject.EmailCssSelector).Text;

       public List<string> GetLanguages() =>
           SiteDriver.FindDisplayedElementsText(ProductDetailPageObject.LanguageListCssSelector, How.CssSelector);

       public string GetSelectedLanguaue() =>
           SiteDriver.FindElement(ProductDetailPageObject.SelectedLanguageCssSelector, How.CssSelector).Text;

       public List<string> GetCurrencies() =>
           SiteDriver.FindDisplayedElementsText(ProductDetailPageObject.CurrencySelector, How.CssSelector);

       public string GetSelectedCurrency() =>
           SiteDriver.FindElement(ProductDetailPageObject.SelectedCurrencyCssSelector, How.CssSelector).Text;

       public bool IsAddtionalLinksPresentByLinkName(string name) =>
           JavascriptExecutor.IsElementPresent(string.Format(ProductDetailPageObject.AdditionalLinkCssTemplate, name));

       public bool IsKeepInTouchPresent() =>
           SiteDriver.IsElementPresent(ProductDetailPageObject.KeepInTouchCssSelector, How.CssSelector);

       public bool IsEmailInputPresent() => SiteDriver.IsElementPresent(ProductDetailPageObject.EmailInputCssSelector, How.CssSelector);

       public bool IsSubmitIconPresent() =>
           SiteDriver.IsElementPresent(ProductDetailPageObject.SubmitButtonCssSelector, How.CssSelector);

       #endregion

    }
}
