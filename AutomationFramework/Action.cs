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
        public static void Click(By element)
        {
            try
            {
                Logger.logInfo("Click element " + element.ToString());
                Browser.driver.FindElement(element).Click();
            }
            catch (Exception e)
            {
                Logger.logError("Error when trying to click element " + element.ToString() + ". Exception detail: " + e);
            }
        }

        public static void DoubleClick(By element)
        {
            try
            {
                Logger.logInfo("Double-Click element " + element.ToString());
                new Actions(Browser.driver).DoubleClick(Browser.driver.FindElement(element)).Perform();
            }
            catch (Exception e)
            {
                Logger.logError("Error when trying to double-click element " + element.ToString() + ". Exception detail: " + e);
            }
        }

        public static void SetText(By element, string text)
        {
            try
            {
                Logger.logInfo("Set text at "  + element.ToString() + "value: "+ text);
                Browser.driver.FindElement(element).SendKeys(text);
            }
            catch (Exception e)
            {
                Logger.logError("Error when trying to set text at " + element.ToString() + ". Exception detail: " + e);
            }
        }

        public static void ClearText(By element)
        {
            try
            {
                Logger.logInfo("Clear text for element " + element.ToString());
                Browser.driver.FindElement(element).Clear();
            }
            catch (Exception e)
            {
                Logger.logError("Error when trying to clear text at " + element.ToString() + ". Exception detail: " + e);
            }
        }
    }
}
