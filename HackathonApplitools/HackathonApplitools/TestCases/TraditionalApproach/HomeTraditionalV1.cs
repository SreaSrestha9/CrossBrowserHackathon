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
       

        [Test]
        [TestCaseSource(typeof(TraditionalTestBase), nameof(BrowserToRunWith))]
        public void Verify_Header_bar_contents(string browserName)
        {
            Setup(browserName);
            
            List<string> headerList = new List<string>{ "HOME", "MEN", "WOMEN", "RUNNING", "TRAINING" };
            var searchBoxPlaceholder = "Search over 10,000 shoes!";
            Start(Urls.Version1);
            Assert.IsTrue(homePage.IsAppliFashionLogoPresent(),"Is AppliFashion Logo present?");
            homePage.GetMainMenuHeader().ShouldBeEqual(headerList,"Does header list match?");
            homePage.IsSearchInputPresent().ShouldBeTrue("Is search input present?");
            homePage.IsSearchButtonPresent().ShouldBeTrue("Is Search Button Present?");
            homePage.GetDefaultSearchInputValue().ShouldBeEqual(searchBoxPlaceholder,"Placeholder should match");
            homePage.IsAccountWishlistIconPresentByIconName("Account").ShouldBeTrue("Is account icon present?");
            homePage.IsAccountWishlistIconPresentByIconName("Wishlist").ShouldBeTrue("Is account icon present?");
            homePage.IsAccountWishlistIconPresentByIconName("Wishlist").ShouldBeTrue("Is account icon present?");
            homePage.IsCartIconPresent().ShouldBeTrue("Is cart icon present?");
            homePage.GetCartQuanity().ShouldBeEqual("2", "cart quantity should match");
        }

        [Test]

        public void Verify_side_filter_and_shopping_experience()
        {
            var sideFilterHeaders = new List<string> {"type", "colors", "brands", "price"};
            var typeList = new List<string>{"Soccer","Basketball","Running","Training"};
            var colorList = new List<string> { "Black", "White", "Blue", "Green","Yellow" };
            var brandsList = new List<string> { "Adibas", "Mykey", "Bans", "Over Armour", "ImBalance" };
            var priceList = new List<string> { "$0 - $50", "$50 - $100", "$100 - $150", "$150 - $500" };
            var buttons = new List<string>{ "Filter", "Reset" };
            var ids = new List<string>{ "filterBtn", "resetBtn" };
            var productIds = new List<string>{ "FIGURE____213", "FIGURE____238" };

            Console.Out.WriteLine("Verification of side filter headers");
            homePage.GetSideFilterHeaders().ShouldCollectionBeEqual(sideFilterHeaders, "Side filter headers should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[0]).ShouldCollectionBeEqual(typeList, "type list should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[1]).ShouldCollectionBeEqual(colorList, "type list should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[2]).ShouldCollectionBeEqual(brandsList, "type list should match");
            homePage.GetSideFilterOptionsByHeader(sideFilterHeaders[3]).ShouldCollectionBeEqual(priceList, "type list should match");
            homePage.IsSidefilterQuantityPresentByHeaderAndOption(sideFilterHeaders[0], typeList[0]).ShouldBeTrue("Is quantity present?");

            Console.Out.WriteLine("Verification if filter and reset buttons are enabled after selecting a filter");
            homePage.IsFilterResetButtonPresentByButtonName(buttons[0]).ShouldBeTrue("Is Filter Button present?");
            homePage.IsFilterResetButtonPresentByButtonName(buttons[1]).ShouldBeTrue("Is Reset Button present?");
            homePage.IsFilterResetButtonDisabledByButtonId(ids[0]).ShouldBeTrue("Is Filter Button disabled?");
            homePage.IsFilterResetButtonDisabledByButtonId(ids[1]).ShouldBeTrue("Is Reset Button disabled?");
            homePage.ClickOnFilterOptionByHeaderAndOption(sideFilterHeaders[0], typeList[0]);
            homePage.IsFilterResetButtonDisabledByButtonId(ids[0]).ShouldBeFalse("Is Filter Button disabled?");
            homePage.IsFilterResetButtonDisabledByButtonId(ids[1]).ShouldBeFalse("Is Reset Button disabled?");

            Console.Out.WriteLine("Verification shopping experience");
            var selectedFilterQuantity =
                homePage.GetQuantityOfFilterOptionByHeaderAndOption(sideFilterHeaders[0], typeList[0]);
            homePage.ClickFilterButton();
            homePage.GetProductsCount().ShouldBeEqual(selectedFilterQuantity, "Products' count displayed after applying filter should match with quantity displayed in the filter option");


            Console.Out.WriteLine("Verification of displayed products");
            foreach (var id in productIds)
            {
                homePage.IsDiscountBannerPresentById(id).ShouldBeTrue($"Is discount banner present for {id}");
                homePage.IsCountDownPresentById(id).ShouldBeTrue($"Is count down present for {id}");
                
                if (id.Equals(productIds[0]))
                {
                    homePage.GetOldPriceList(id).ShouldBeEqual("$48.00","Old price should match");
                    homePage.IsAddToFavoriteCompareCartPresentByIds("UL____222", "LI____223").ShouldBeTrue("Wishlist icon should be present");
                    homePage.IsAddToFavoriteCompareCartPresentByIds("UL____222", "LI____227").ShouldBeTrue("Add to compare icon should be present");
                    homePage.IsAddToFavoriteCompareCartPresentByIds("UL____222", "LI____231").ShouldBeTrue("Add to cart icon should be present");
                }
                else
                {
                    homePage.GetOldPriceList(id).ShouldBeEqual("$90.00", "Old price should match");
                    homePage.IsAddToFavoriteCompareCartPresentByIds("UL____247", "LI____248").ShouldBeTrue("Wishlist icon should be present");
                    homePage.IsAddToFavoriteCompareCartPresentByIds("UL____247", "LI____252").ShouldBeTrue("Add to compare icon should be present");
                    homePage.IsAddToFavoriteCompareCartPresentByIds("UL____247", "LI____256").ShouldBeTrue("Add to cart icon should be present");
                }
            }

            homePage.GetProductsNewProductsNewPrice().ShouldCollectionBeEqual(new List<string>{ "$33.00", "$62.00" }, "New prices should match");


        }


        [Test]

        public void Verify_top_banner_and_tool_Box_elements()
        {
           homePage.IsTopBannerPresent().ShouldBeTrue("Top banner should be present");
           homePage.GetSelectedSortOption().ShouldBeEqual("Sort by popularity","By default Sort by popularity options should be selected");
           homePage.GetSortOptions().ShouldCollectionBeEqual(new List<string>{ "Sort by popularity", "Sort by average rating", "Sort by newness", "Sort by price: low to high", "Sort by price: high to" }, "Sort options should match");
           homePage.IsGridViewIconPresent().ShouldBeTrue("Is grid view icon present?");
           homePage.IsListViewIconPresent().ShouldBeTrue("Is List View Icon Present?");
        }

        [Test]

        public void Verify_footer_content_for_home_page()
        {
            var footerheaders = new List<string> { "Quick Links", "Contacts", "Keep in touch" };
            var additionalLinks = new List<string> { "Terms and conditions", "Privacy", "© 2020 Applitools" };
            foreach (var header in footerheaders)
            {
                homePage.IsFooterHeaderPresentByFooterName(header).ShouldBeTrue($"Is {header} header present");
            }
            homePage.GetQuickLinks().ShouldCollectionBeEqual(new List<string>{ "About us", "Faq", "Help","My account","Blog","Contacts"}, "QuickLinks should match");
            homePage.IsHomeIconPresentInContacts().ShouldBeTrue("Is home icon present?");
            homePage.GetContactLocation().ShouldBeEqual("155 Bovet Rd #600 San Mateo, CA 94402","Location should match");
            homePage.IsMailIconPresentInContact().ShouldBeTrue("Is mail icon present?");
            homePage.GetEmailAddressOfContact().ShouldBeEqual("srd@applitools.com","Email should match");
            homePage.GetSelectedLanguaue().ShouldBeEqual("English","English language should be selected");
            homePage.GetLanguages().ShouldCollectionBeEqual(new List<string>{"English","French","Spanish","Russian"}, "Languages should match");
            homePage.GetSelectedCurrency().ShouldBeEqual("US Dollars","Selected currency should be US Dollars");
            homePage.GetCurrencies().ShouldCollectionBeEqual(new List<string>{"US Dollars","Euro"},"Currencies should match" );
            homePage.IsEmailInputPresent().ShouldBeTrue("Is email input present?");
            homePage.IsSubmitIconPresent().ShouldBeTrue("Is submit icon present?");
            foreach (var link in additionalLinks)
            {
                homePage.IsAddtionalLinksPresentByLinkName(link).ShouldBeTrue($"Is {link} header present");
            }
        }


        //[TearDown]
        //public void TestCleanUp()
        //{
        //    SiteDriver.Close();
        //}
    }

    
}
