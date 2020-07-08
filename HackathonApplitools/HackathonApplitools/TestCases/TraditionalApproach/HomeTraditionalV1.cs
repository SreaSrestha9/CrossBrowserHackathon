using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using HackathonApplitools.PageServices;
using NUnit.Framework;

namespace HackathonApplitools
{
    public class HomeTraditionalV1:TraditionalTestBase
    {
       
       

        [Test]
        [TestCaseSource(typeof(TraditionalTestBase), nameof(BrowserToRunWith))]
        public void Verify_Header_bar_contents(string browserName)
        {
            Setup(browserName);
            
           //List<string> headerList = new List<string>{ "HOME", "MEN", "WOMEN", "RUNNING", "TRAINING" };
            //var searchBoxPlaceholder = "Search over 10,000 shoes!";
            
            Start(Urls.Version1);
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt",1, "IsAppliFashionLogoPresent", browserName,homePage.IsAppliFashionLogoPresent()));
           // Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsAppliFashionLogoPresent", browserName, homePage.GetMainMenuHeader().ShouldBeEqual(headerList,"Does header list match?"));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsSearchInputPresent", browserName, homePage.IsSearchInputPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsSearchButtonPresent", browserName, homePage.IsSearchButtonPresent()));
            //Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsAppliFashionLogoPresent", browserName, homePage.GetDefaultSearchInputValue().ShouldBeEqual(searchBoxPlaceholder,"Placeholder should match"));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsAccountWishlistIconPresentByIconName", browserName, homePage.IsAccountWishlistIconPresentByIconName("Account")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsAccountWishlistIconPresentByIconName", browserName, homePage.IsAccountWishlistIconPresentByIconName("Wishlist")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsAccountWishlistIconPresentByIconName", browserName, homePage.IsAccountWishlistIconPresentByIconName("Wishlist")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsCartIconPresent", browserName, homePage.IsCartIconPresent()));
            //Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsAppliFashionLogoPresent", browserName, homePage.GetCartQuanity().ShouldBeEqual("2", "cart quantity should match"));
        }

        [Test]
        [TestCaseSource(typeof(TraditionalTestBase), nameof(BrowserToRunWith))]
        public void Verify_side_filter_and_shopping_experience(string browserName)
        {
            Setup(browserName);
            Start(Urls.Version1);
            var sideFilterHeaders = new List<string> { "type", "colors", "brands", "price" };
            var typeList = new List<string> { "Soccer", "Basketball", "Running", "Training" };
            var colorList = new List<string> { "Black", "White", "Blue", "Green", "Yellow" };
            var brandsList = new List<string> { "Adibas", "Mykey", "Bans", "Over Armour", "ImBalance" };
            var priceList = new List<string> { "$0 - $50", "$50 - $100", "$100 - $150", "$150 - $500" };
            var buttons = new List<string> { "Filter", "Reset" };
            var ids = new List<string> { "filterBtn", "resetBtn" };
            var productIds = new List<string> { "FIGURE____213", "FIGURE____238" };

            Console.Out.WriteLine("Verification of side filter headers");
            homePage.GetSideFilterHeaders().ShouldCollectionBeEqual(sideFilterHeaders, "Side filter headers should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[0]).ShouldCollectionBeEqual(typeList, "type list should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[1]).ShouldCollectionBeEqual(colorList, "type list should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[2]).ShouldCollectionBeEqual(brandsList, "type list should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[3]).ShouldCollectionBeEqual(priceList, "type list should match");
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, "IsSidefilterQuantityPresentByHeaderAndOption", browserName, homePage.IsSidefilterQuantityPresentByHeaderAndOption(sideFilterHeaders[0], typeList[0])));

            Console.Out.WriteLine("Verification if filter and reset buttons are enabled after selecting a filter");
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, "IsFilterResetButtonPresentByButtonName", browserName, homePage.IsFilterResetButtonPresentByButtonName(buttons[0])));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, "IsFilterResetButtonPresentByButtonName", browserName, homePage.IsFilterResetButtonPresentByButtonName(buttons[1])));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, "IsFilterResetButtonDisabledByButtonId", browserName, homePage.IsFilterResetButtonDisabledByButtonId(ids[0])));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, "IsFilterResetButtonDisabledByButtonId", browserName, homePage.IsFilterResetButtonDisabledByButtonId(ids[1])));
            homePage.ClickOnFilterOptionByHeaderAndOption(sideFilterHeaders[0], typeList[0]);
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, "IsFilterResetButtonDisabledByButtonId", browserName, homePage.IsFilterResetButtonDisabledByButtonId(ids[0])));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, "IsFilterResetButtonDisabledByButtonId", browserName, homePage.IsFilterResetButtonDisabledByButtonId(ids[1])));

            Console.Out.WriteLine("Verification shopping experience");
            var selectedFilterQuantity =
                homePage.GetQuantityOfFilterOptionByHeaderAndOption(sideFilterHeaders[0], typeList[0]);
            homePage.ClickFilterButton();
            homePage.GetProductsCount().ShouldBeEqual(selectedFilterQuantity, "Products' count displayed after applying filter should match with quantity displayed in the filter option");


            Console.Out.WriteLine("Verification of displayed products");
            foreach (var id in productIds)
            {
                Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, $"IsDiscountBannerPresentById for {id}", browserName, homePage.IsDiscountBannerPresentById(id)));
                Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, $"IsCountDownPresentById for {id}", browserName, homePage.IsCountDownPresentById(id)));
                
                if (id.Equals(productIds[0]))
                {
                    homePage.GetOldPriceList(id).ShouldBeEqual("$48.00","Old price should match");
                    Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, $"IsAddToFavoritePresent for {id}", browserName, homePage.IsAddToFavoriteCompareCartPresentByIds("UL____222", "LI____223")));
                    Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2,
                        $"IsAddComparePresentByIds for {id}", browserName,
                        homePage.IsAddToFavoriteCompareCartPresentByIds("UL____222", "LI____227")));
                    Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2,
                        $"IsAddCartPresentByIds for {id}", browserName,
                        homePage.IsAddToFavoriteCompareCartPresentByIds("UL____222", "LI____231")));
                }
                else
                {
                    homePage.GetOldPriceList(id).ShouldBeEqual("$90.00", "Old price should match");
                    Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, $"IsAddToFavoritePresent for {id}", browserName, homePage.IsAddToFavoriteCompareCartPresentByIds("UL____247", "LI____248")));
                    Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, $"IsAddComparePresentByIds for {id}",  browserName, homePage.IsAddToFavoriteCompareCartPresentByIds("UL____247", "LI____252")));
                    Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 2, $"IsAddCartPresentByIds for {id}", browserName, homePage.IsAddToFavoriteCompareCartPresentByIds("UL____247", "LI____256")));
                }
            }

            homePage.GetProductsNewProductsNewPrice().ShouldCollectionBeEqual(new List<string>{ "$33.00", "$62.00" }, "New prices should match");


        }


        [Test]
        [TestCaseSource(typeof(TraditionalTestBase), nameof(BrowserToRunWith))]
        public void Verify_top_banner_and_tool_Box_elements(string browserName)
        {
            Setup(browserName);
            Start(Urls.Version1);
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsTopBannerPresent", browserName, homePage.IsTopBannerPresent()));
            homePage.GetSelectedSortOption().ShouldBeEqual("Sort by popularity","By default Sort by popularity options should be selected");
            homePage.GetSortOptions().ShouldCollectionBeEqual(new List<string>{ "Sort by popularity", "Sort by average rating", "Sort by newness", "Sort by price: low to high", "Sort by price: high to" }, "Sort options should match");
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsSortOptionPresent", browserName,
                homePage.IsSortOptionPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsGridViewIconPresent", browserName, homePage.IsGridViewIconPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsListViewIconPresent", browserName, homePage.IsListViewIconPresent()));
        }

        [Test]
        [TestCaseSource(typeof(TraditionalTestBase), nameof(BrowserToRunWith))]
        public void Verify_footer_content_for_home_page(string browserName)
        {
            Setup(browserName);
            Start(Urls.Version1);
            var footerheaders = new List<string> { "Quick Links", "Contacts", "Keep in touch" };
            var additionalLinks = new List<string> { "Terms and conditions", "Privacy", "© 2020 Applitools" };
            foreach (var header in footerheaders)
            {
                Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, $"IsFooterHeaderPresentByFooterName {header}", browserName, homePage.IsFooterHeaderPresentByFooterName(header)));
            }
            homePage.GetQuickLinks().ShouldCollectionBeEqual(new List<string>{ "About us", "Faq", "Help","My account","Blog","Contacts"}, "QuickLinks should match");
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsHomeIconPresentInContacts", browserName, homePage.IsHomeIconPresentInContacts()));
            homePage.GetContactLocation().ShouldBeEqual("155 Bovet Rd #600 San Mateo, CA 94402","Location should match");
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsEmailInputPresent", browserName, homePage.IsEmailInputPresent()));
            homePage.GetEmailAddressOfContact().ShouldBeEqual("srd@applitools.com","Email should match");
            homePage.GetSelectedLanguaue().ShouldBeEqual("English","English language should be selected");
            homePage.GetLanguages().ShouldCollectionBeEqual(new List<string>{"English","French","Spanish","Russian"}, "Languages should match");
            homePage.GetSelectedCurrency().ShouldBeEqual("US Dollars","Selected currency should be US Dollars");
            homePage.GetCurrencies().ShouldCollectionBeEqual(new List<string>{"US Dollars","Euro"},"Currencies should match" );
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsEmailInputPresent", browserName, homePage.IsEmailInputPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, "IsSubmitIconPresent", browserName, homePage.IsSubmitIconPresent()));
            foreach (var link in additionalLinks)
            {
                Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 1, $"IsAddtionalLinksPresentByLinkName {link}", browserName, homePage.IsAddtionalLinksPresentByLinkName(link)));
            }
        }

        [Test]
        [TestCaseSource(typeof(TraditionalTestBase), nameof(BrowserToRunWith))]
        public void Verify_Product_detail_page(string browserName)
        {
            Setup(browserName);
            Start(Urls.Version1);

            productPage = homePage.ClickOnProductImageByProductName("Appli Air x Night");
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsPageHeaderPresent", browserName, productPage.IsPageHeaderPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsAppliFashionLogoPresent", browserName, productPage.IsAppliFashionLogoPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsMainHeaderPresent Home", browserName, productPage.IsMainHeaderPresent("HOME")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsMainHeaderPresent MEN", browserName, productPage.IsMainHeaderPresent("MEN")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsMainHeaderPresent WOMEN", browserName, productPage.IsMainHeaderPresent("WOMEN")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsMainHeaderPresent RUNNING", browserName, productPage.IsMainHeaderPresent("RUNNING")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsMainHeaderPresent TRAINING", browserName, productPage.IsMainHeaderPresent("TRAINING")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsSearchInputPresent", browserName, productPage.IsSearchInputPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsSearchButtonPresent", browserName, productPage.IsSearchButtonPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsAccountIconPresentByIconName ", browserName, productPage.IsAccountWishlistIconPresentByIconName("Account")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsWishListIconPresentByIconName ", browserName, productPage.IsAccountWishlistIconPresentByIconName("Wishlist")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsCartIconPresent", browserName, productPage.IsCartIconPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsCartQuantityPresent", browserName, productPage.IsCartQuantityPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsProductImagePresent", browserName, productPage.IsProductImagePresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsProductStarReviewPresent", browserName, productPage.IsProductStarReviewPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "Is Size label present", browserName, productPage.IsProductDetailLabel("DIV__row__88")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "Is Quantity label present", browserName, productPage.IsProductDetailLabel("DIV__row__98")));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsProductReviewPresent", browserName, productPage.IsProductReviewPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsSizeInputPresent", browserName, productPage.IsSizeInputPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsSelectedsizeSmall", browserName, productPage.IsSelectedsizeSmall()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsQuantityIncreaseIconPresent", browserName, productPage.IsQuantityIncreaseIconPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsQuantityDecreaseIconPresent", browserName, productPage.IsQuantityDecreaseIconPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsQuantityPresent", browserName, productPage.IsQuantityPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsDiscountBannerPresent", browserName, productPage.IsDiscountBannerPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsNewPriceCorrect", browserName, productPage.IsNewPriceCorrect()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsOldPriceCorrect", browserName, productPage.IsOldPriceCorrect()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsAddToCartButtonPresent", browserName, productPage.IsAddToCartButtonPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsProductDescriptionPresent", browserName, productPage.IsProductDescriptionPresent()));


            var footerheaders = new List<string> { "Quick Links", "Contacts", "Keep in touch" };
            var additionalLinks = new List<string> { "Terms and conditions", "Privacy"};
            foreach (var header in footerheaders)
            {
                Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, $"IsFooterHeaderPresentByFooterName {header}", browserName, productPage.IsFooterHeaderPresentByFooterName(header)));
            }
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsHomeIconPresentInContacts", browserName, productPage.IsHomeIconPresentInContacts()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "ISContactLocationPresent", browserName, productPage.ISContactLocationPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsMailIconPresentInContact", browserName, productPage.IsMailIconPresentInContact()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsEmailAddressOfContactPresent", browserName, productPage.IsEmailAddressOfContactPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsSelectedLanguaueEnglish", browserName, productPage.IsSelectedLanguaueEnglish()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsCurrencyDollars", browserName, productPage.IsCurrencyDollars()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsEmailInputPresent", browserName, productPage.IsEmailInputPresent()));
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsSubmitIconPresent", browserName, productPage.IsSubmitIconPresent()));
            foreach (var link in additionalLinks)
            {
                Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, $"IsAddtionalLinksPresentByLinkName {link}", browserName, productPage.IsAddtionalLinksPresentByLinkName(link)));
            }
            Assert.IsTrue(HackathonReport("traditional-V1-TestResults.txt", 3, "IsApplitools2020Present", browserName, productPage.IsApplitools2020Present()));
        }


    }


}
