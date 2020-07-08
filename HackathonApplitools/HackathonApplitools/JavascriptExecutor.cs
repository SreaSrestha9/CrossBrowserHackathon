using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HackathonApplitools
{
    public class JavascriptExecutor
    {

        private const string JQueryScript = "return $('{0}').get(0)";

        private const string JQueryScriptMultipleResultValuesForXPath = @"
                                                                        function _x(STR_XPATH) {{
                                                                            var xresult = document.evaluate(STR_XPATH, document, null, XPathResult.ANY_TYPE, null);
                                                                            var xnodes = [];
                                                                            var xres;
                                                                            while (xres = xresult.iterateNext()) {{
                                                                                xnodes.push(xres);
                                                                            }}

                                                                            return xnodes;
                                                                        }}
                                                                        var inp = _x(""{0}""); 
                                                                function returnFilesList( nameArray )
                                                                    {{
                                                                    for (var i = 0; i < inp.length; ++i){{
                                                                        if('{1}'=='Attribute')
                                                                        {{
                                                                            nameArray.push(inp[i].getAttribute('{2}').trim());
                                                                        }}
                                                                        else
                                                                        {{
                                                                         nameArray.push(inp[i].innerText.trim());
                                                                        }}
                                                                    }}
                                                                    return nameArray;
                                                                    }}
                                                                var nameArray = []; 
                                                                return returnFilesList(nameArray);";

        private const string JQueryScriptMultipleResult = "return $('{0}')";

        private const string JQueryScriptMultipleResultValues = @"var inp = $('{0}'); 
                                                                function returnFilesList( nameArray )
                                                                    {{
                                                                    for (var i = 0; i < inp.length; ++i){{
                                                                        if('{1}'=='Attribute')
                                                                        {{
                                                                            nameArray.push(inp[i].getAttribute('{2}').trim());
                                                                        }}
                                                                        else
                                                                        {{
                                                                         nameArray.push(inp[i].innerText.trim());
                                                                        }}
                                                                    }}
                                                                    return nameArray;
                                                                    }}
                                                                var nameArray = []; 
                                                                return returnFilesList(nameArray);";

        

        /// <summary>
        /// Executes a javascript.
        /// </summary>
        /// <param name="script">A JavaScript to execute.</param>
        /// <param name="args">Array of object arguments.</param>
        public static void ExecuteScript(string script, params object[] args)
        {
            ExecuteScript(script, args);
        }

        public static object Execute(string script)
        {
            return SiteDriver.JsExecutor.ExecuteScript(script);
        }

        public static object ExecuteModern(string script)
        {
            return SiteDriver.JsExecutorModern.ExecuteScript(script);
        }

        /// <summary>
        /// Click on an element.
        /// </summary>
        /// <param name="select">An element.</param>
        /// <param name="selector">The locating mechanism to use.</param>
        /// <returns></returns>



        public static IWebElement FindElement(string select)
        {
            return (IWebElement)Execute(string.Format(JQueryScript, select));
        }


        public static IWebElement FindElementModern(string select)
        {
            return (IWebElement)ExecuteModern(string.Format(JQueryScript, select));
        }

        public static List<string> FindElements(string select, string selectSelector = "Text", bool isNull = false, How selector = How.CssSelector)
        {

            if (isNull)
            {
                var obj = (IList<IWebElement>)Execute(string.Format(JQueryScriptMultipleResult, select));
                return obj.Select(element => element.GetAttribute(selectSelector)).ToList();
            }
            var attb = selectSelector.Split(':').Select(x => x.Trim()).ToList();
            if (selector == How.CssSelector)
            {
                var obj = Execute(string.Format(JQueryScriptMultipleResultValues.Replace("'", "\""), select,
                    selectSelector.StartsWith("Attribute") ? attb[0] : "", selectSelector.StartsWith("Attribute") ? attb[1] : ""));
                return ((IEnumerable)obj).Cast<string>().ToList();
            }
            var obj1 = Execute(string.Format(JQueryScriptMultipleResultValuesForXPath.Replace("'", "\""), select,
                selectSelector.StartsWith("Attribute") ? attb[0] : "", selectSelector.StartsWith("Attribute") ? attb[1] : ""));
            return ((IEnumerable)obj1).Cast<string>().ToList();


        }

        public static int FindElementsCount(string select)
        {
            return FindElements(select, "").Count();
        }

        public static bool IsElementPresent(string select)
        {
            try
            {
                return (FindElement(select) != null);
            }
            catch (Exception ex)
            {
                // Don't handle NotSupportedException
                if (ex is NotSupportedException)
                    throw;
                return false;
            }
        }

       
    }
}
