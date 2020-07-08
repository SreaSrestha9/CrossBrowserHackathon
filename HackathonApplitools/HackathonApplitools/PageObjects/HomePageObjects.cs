using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Text;

namespace HackathonApplitools.PageObjects
{
    public class HomePageObjects
    {
        public const string AppliFashionLogoCssSelector= "#logo>a";

        #region HeaderMenu
        public const string MainMenuHeaderCssSelector = "div.main-menu>ul>li>a";
        public const string MainMenuHeaderCssTemplate = "div.main-menu>ul>li>a:contains({0})";
        #endregion

        #region NavBar
        public const string SearchInputCssSelector = "div.custom-search-input>input";
        public const string SearchButtonCssSelector = "div.custom-search-input>button";
        public const string AccountWishlistCssTemplate = "a:has(span:contains({0}))";
        public const string CartCssSelector = "a.cart_bt";
        public const string CartQuantityCssSelector = "a.cart_bt>strong";
        #endregion

        #region SideFilter

        public const string SideFilterHeadersCssSelector = "div#sidebar_filters>div>h4>a";
        public const string SideFilterCssTemplate = "div#sidebar_filters>div>h4>a:contains({0})";

        public const string SideFilterListCssTemplate =
            "div#sidebar_filters>div>h4:has(a:contains({0}))+div.collapse li>label";

        public const string SideFilterOptionCssTemplate =
            "div#sidebar_filters>div>h4:has(a:contains({0}))+div.collapse li>label:contains({1})";

        public const string SideFilterOptionQuantityCssTemplate =
            "div#sidebar_filters>div>h4:has(a:contains({0}))+div.collapse li>label:contains({1})>small";

        public const string SideFilterCheckboxCssTemplate =
            "div#sidebar_filters>div>h4:has(a:contains({0}))+div.collapse li>label:contains({1})>span";

        public const string SideFilterResetButtonCssTemplate = "div.buttons>button:contains({0})";

        public const string SideFilterButtonDisabledCssTemplate = "div.buttons>button#{0}[disabled]";

        #endregion

        public const string TopBannerCssSelector = "div.top_banner";

        #region ToolBox
        public const string SelectedSortOptionCssSelector = "div.toolbox li>div>select>option[selected]";
        public const string SortOptionsCssSelector = "div.toolbox li>div>select>option";
        public const string GridViewIconCssSelector = "div.toolbox li>a>i.ti-view-grid";
        public const string ListViewIconCssSelector = "div.toolbox li>a>i.ti-view-list";
        #endregion

        #region Products

        public const string ProductsCssSelector = "div#product_grid>div";
        public const string ProductNewPricesCssSelector = "div#product_grid>div div.price_box>span.new_price";

        public const string ProductWithRibbonCssTemplate =
            "div#product_grid>div>div:has(figure#{0})>span.ribbon";

        public const string ProductWithCountdownCssTemplate = "div#product_grid>div>div:has(figure#{0}) div.countdown";
        public const string AddToFavoriteCompareCartCssTemplate = "ul#{0}>li#{1}>a";

        public const string OldPriceCssTemplate =
            "div#product_grid>div>div:has(figure#{0})>div.price_box>span.old_price";

        public const string ProductDetailLinkByProductCssTemplate = "div#product_grid>div>div:has(figure#{0})>a";
        public const string ProductDetailLinkByImageCssTemplate = "div#product_grid>div>div>figure>a>img[alt = '{0}']";
        public const string ProductInFilteredProductCssTemplate = "div#product_grid>div>div> figure#{0} a>img";

        #endregion


    }
}
