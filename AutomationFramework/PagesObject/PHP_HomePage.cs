using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace AutomationFramework.PagesObject
{
    public static class PHP_HomePage
    {
        public static By search_textbox = By.XPath(".//input[@type='search']");
        public static void SearchFor(string text)
        {
            Action.SetText(search_textbox, text+Keys.Enter);
        }
    }
}
