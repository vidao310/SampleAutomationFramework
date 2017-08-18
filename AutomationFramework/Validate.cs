using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace AutomationFramework
{
    public static class Validate
    {
        public static void TextEqual(string actual, string expected, string description="")
        {
            Assert.AreEqual(expected, actual);
            if (expected == actual)
                Logger.logPass(description + "Actual value shown as expected, value: " + expected);
            else
                Logger.logFail(description + "Acutal value: " + actual + ".Expected value: " + expected);
        }

        public static void TextContain(string actual, string expected, string description = "")
        {
            Assert.IsTrue(actual.Contains(expected));
            if (actual.Contains(expected))
                Logger.logPass(description + "Actual value contains expected value. Actual value: " + actual + ".Expected value: " +expected);
            else
                Logger.logFail(description + "Acutal value does not contain expected value. Acutal value: " + actual + ".Expected value: " + expected);
        }
    }

    public static class ValidateUrl
    {
        public static void UrlEqual(string expected)
        {
            var currentURL = Browser.getCurrentURL();
            Validate.TextEqual(currentURL, expected, "Validate Url.");
        }
        public static void UrlContain(string expected)
        {
            var currentURL = Browser.getCurrentURL();
            Validate.TextContain(currentURL, expected, "Validate Url.");
        }
    }


    public static class ValidateElement
    {
        public static void Exist(By element)
        {
            var elementCount = Browser.driver.FindElements(element).Count();
            Assert.IsTrue(elementCount > 0, "Validate Element Display");
            if (elementCount > 0)
                Logger.logPass("Element display as expected. " + element.ToString());
            else
                Logger.logFail("Element does not display as expected. " + element.ToString());
        }
    }
}
