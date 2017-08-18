using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace AutomationFramework
{
    public static class Browser
    {
        public static IWebDriver driver;

        /// <param name="browserName">chrome, firefox, ie, edge, safari</param>
        public static void OpenNewBrowser(string browserName = "chrome")
        {
            if (browserName == "firefox") { driver = new FirefoxDriver(); }
            else if (browserName == "edge") { driver = new EdgeDriver(); }
            else if (browserName == "ie") { driver = new InternetExplorerDriver(); }
            else if (browserName == "safari") { driver = new SafariDriver(); }
            else {
                ChromeOptions options = new ChromeOptions();
                Proxy proxy = new Proxy();
                proxy.Kind = ProxyKind.Manual;
                options.Proxy = proxy;

                driver = new ChromeDriver(); }

            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            Logger.logInfo("Lauch " + browserName +  " ,and set default find element timeout at 15 seconds");
        }

        public static void GoToURL(string url)
        {
            Logger.logInfo("Navigate to Url: " + url);
            driver.Navigate().GoToUrl(url);
        }

        public static string getCurrentURL()
        {
            return driver.Url;
        }

        public static void CloseBroswer()
        {
            driver.Close();
        }
    }
}
