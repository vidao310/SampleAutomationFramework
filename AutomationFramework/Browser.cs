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
        public static void OpenNewBroswer(string browserName = "chrome")
        {
            if (browserName == "firefox") { driver = new FirefoxDriver(); }
            else if (browserName == "edge") { driver = new EdgeDriver(); }
            else if (browserName == "ie") { driver = new InternetExplorerDriver(); }
            else if (browserName == "safari") { driver = new SafariDriver(); }
            else { driver = new ChromeDriver(); }

            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);
            Console.Write("Lauching " + browserName +  " ,and set default find element timeout at 15 seconds");
        }

    }
}
