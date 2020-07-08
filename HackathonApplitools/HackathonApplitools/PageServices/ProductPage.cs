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
        //private static IJavaScriptExecutor _javascriptexecutor;

        #region Public Methods

        public bool IsPageHeaderPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.PageHeaderCssSelector, How.CssSelector);

        public bool IsAppliFashionLogoPresent() => SiteDriver.IsElementPresent(HomePageObjects.AppliFashionLogoCssSelector, How.CssSelector);

        public bool IsMainHeaderPresent(string header) =>
            JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.MainMenuHeaderCssTemplate, header));

        public bool IsSearchInputPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.SearchInputCssSelector, How.CssSelector);

        public bool IsSearchButtonPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.SearchButtonCssSelector, How.CssSelector);

        public bool IsAccountWishlistIconPresentByIconName(string icon) =>
            JavascriptExecutor.IsElementPresent(string.Format(HomePageObjects.AccountWishlistCssTemplate, icon));

        public bool IsCartIconPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.CartCssSelector, How.CssSelector);

        public bool IsCartQuantityPresent() =>
            SiteDriver.IsElementPresent(HomePageObjects.CartQuantityCssSelector, How.CssSelector);

        public bool IsProductImagePresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.ProductImageCssSelector, How.CssSelector);

        public bool IsProductStarReviewPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.ProductStarCssSelector, How.CssSelector);

        public bool IsProductReviewPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.ProductReviewCssSelector, How.CssSelector);

        public bool IsProductDetailLabel(string label) =>
            SiteDriver.IsElementPresent(string.Format(ProductDetailPageObject.ProductDetailLabelCssTemplate,label), How.CssSelector);

        public bool IsSizeInputPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.ProductSelectorCssSelector, How.CssSelector);

        public bool IsSelectedsizeSmall() =>
            SiteDriver.FindElement(ProductDetailPageObject.SelectedProduct, How.CssSelector).Text.Contains("Small (S)");

        public bool IsQuantityIncreaseIconPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.IncreaseButtonCssSelector, How.CssSelector);
        public bool IsQuantityDecreaseIconPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.DecreaseButtonCssSelector, How.CssSelector);

        public bool IsQuantityPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.QuantityCssSelector, How.CssSelector);

        public bool IsDiscountBannerPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.DiscountCssSelector, How.CssSelector);

        public bool IsNewPriceCorrect() =>
            SiteDriver.FindElement(ProductDetailPageObject.NewPriceCssSelector, How.CssSelector).Text.Contains("$33.00");

        public bool IsOldPriceCorrect() =>
            SiteDriver.FindElement(ProductDetailPageObject.OldPriceCssSelector, How.CssSelector).Text.Contains("$48.00");

        public bool IsAddToCartButtonPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.AddToCartCssSelector, How.CssSelector);

        public bool IsProductDescriptionPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.ProductDescriptionCssSelector, How.CssSelector);


        //footer
        public bool IsFooterHeaderPresentByFooterName(string name) =>
            JavascriptExecutor.IsElementPresent(string.Format(ProductDetailPageObject.FooterHeaderCssTemplate, name));

        public List<string> GetQuickLinks() =>
            JavascriptExecutor.FindElements(ProductDetailPageObject.QuickLinksListCssSelector);

        public bool IsHomeIconPresentInContacts() =>
            JavascriptExecutor.IsElementPresent(ProductDetailPageObject.ContactsHomeIconCssSelector);

        public bool ISContactLocationPresent() =>
            JavascriptExecutor.IsElementPresent(ProductDetailPageObject.ContactLocationCssSelector);

        public bool IsMailIconPresentInContact() =>
            JavascriptExecutor.IsElementPresent(ProductDetailPageObject.ContactEmailIconCssSelector);

        public bool IsEmailAddressOfContactPresent() =>
            JavascriptExecutor.FindElement(ProductDetailPageObject.EmailCssSelector).Text.Contains("srd@applitools.com");

        

        public bool IsSelectedLanguaueEnglish() =>
            SiteDriver.FindElement(ProductDetailPageObject.SelectedLanguageCssSelector, How.CssSelector).Text.Contains("English");

        public bool IsCurrencyDollars() =>
            SiteDriver.FindElement(ProductDetailPageObject.SelectedCurrencyCssSelector, How.CssSelector).Text.Contains("US Dollars");

        

        public bool IsAddtionalLinksPresentByLinkName(string name) =>
            JavascriptExecutor.IsElementPresent(string.Format(ProductDetailPageObject.AdditionalLinkCssTemplate, name));

       

        public bool IsEmailInputPresent() => SiteDriver.IsElementPresent(ProductDetailPageObject.EmailInputCssSelector, How.CssSelector);

        public bool IsSubmitIconPresent() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.SubmitButtonCssSelector, How.CssSelector);

        public bool IsApplitools2020Present() =>
            SiteDriver.IsElementPresent(ProductDetailPageObject.Applitools2020CssSelector, How.CssSelector);

        #endregion

    }
}
