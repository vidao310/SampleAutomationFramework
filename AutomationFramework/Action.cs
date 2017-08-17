using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace AutomationFramework
{
    public static class Action
    {
        public static void Click(IWebElement element)
        {
            try
            {
                Console.Write("Clicking element " + element.ToString());
                element.Click();
            }
            catch (Exception e)
            {
                Console.Write("Error when trying to click element " + element.ToString() + ". Exception detail: " + e);
            }
        }

        public static void DoubleClick(IWebElement element)
        {
            try
            {
                Console.Write("Double-Clicking element " + element.ToString());
                new Actions(Browser.driver).DoubleClick(element).Perform();
            }
            catch (Exception e)
            {
                Console.Write("Error when trying to double-click element " + element.ToString() + ". Exception detail: " + e);
            }
        }

        public static void SetText(IWebElement element, string text)
        {
            try
            {
                Console.Write("Setting text at "  + element.ToString() + "value: "+ text);
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                Console.Write("Error when trying to set text at " + element.ToString() + ". Exception detail: " + e);
            }
        }

        public static void ClearText(IWebElement element)
        {
            try
            {
                Console.Write("Clearing text for element " + element.ToString());
                element.Clear();
            }
            catch (Exception e)
            {
                Console.Write("Error when trying to clear text at " + element.ToString() + ". Exception detail: " + e);
            }
        }

  

    }
}
