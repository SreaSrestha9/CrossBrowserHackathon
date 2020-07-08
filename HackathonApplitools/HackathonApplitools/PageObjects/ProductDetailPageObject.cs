using System;
using System.Collections.Generic;
using System.Text;

namespace HackathonApplitools.PageObjects
{
    public class ProductDetailPageObject
    {
        #region ProductDetail

        public const string PageHeaderCssSelector = "div.page_header>h1";
        public const string ProductImageCssSelector = "div.product_details_img";
        public const string ProductStarCssSelector = "span.rating>i.icon-star";
        public const string ProductReviewCssSelector = "span.rating>em";
        public const string ProductDetailLabelCssTemplate = "div.prod_options>div#{0}>label>strong";

        public const string ProductSizeListCssSelector =
            "div.prod_options>div>div>div.custom-select-form>select>option";

        public const string ProductSelectorCssSelector = "div.prod_options>div div.nice-select";
        public const string SelectedProduct = "div.prod_options>div>div>div.custom-select-form>div.nice-select>span";
        public const string IncreaseButtonCssSelector = "div#DIV__incbuttoni__104";
        public const string DecreaseButtonCssSelector = "div#DIV__decbuttoni__105";
        public const string QuantityCssSelector = "div.numbers-row>input";
        public const string DiscountCssSelector = "span#discount";
        public const string NewPriceCssSelector = "span.new_price";
        public const string OldPriceCssSelector = "span.old_price";
        public const string AddToCartCssSelector = "div.btn_add_to_cart>a";
        public const string ProductDescriptionCssSelector = "p#P____83";

        public const string FooterHeaderCssTemplate = "footer>div h3:contains({0})";
        public const string QuickLinksCssTemplate = "footer div:has(h3:contains({0}))>div>ul>li>a:contains({1})";
        public const string QuickLinksListCssSelector = "footer div:has(h3:contains(Quick Links))>div>ul>li>a";
        public const string ContactsHomeIconCssSelector = "footer div:has(h3:contains(Contacts))>div>ul>li>i.ti-home";
        public const string ContactLocationCssSelector = "li:has(i[class = ti-home])";
        public const string ContactEmailIconCssSelector = "footer div:has(h3:contains(Contacts))>div>ul>li>i.ti-email";
        public const string EmailCssSelector = "li:has(i[class = ti-email])>a";

        public const string LanguageListCssSelector = "div.lang-selector>select>option";
        public const string SelectedLanguageCssSelector = "div.lang-selector>select>option[selected]";
        public const string CurrencySelector = "div.currency-selector>select>option";
        public const string SelectedCurrencyCssSelector = "div.currency-selector>select>option[selected]";
        public const string AdditionalLinkCssTemplate = "ul.additional_links>li>a:contains({0})";
        public const string KeepInTouchCssSelector = "h3:contains(Keep in touch)";
        public const string EmailInputCssSelector = "div#newsletter>div>input";
        public const string SubmitButtonCssSelector = "div#newsletter>div>button";
        public const string Applitools2020CssSelector = "ul.additional_links>li>span";
        #endregion
    }
}
