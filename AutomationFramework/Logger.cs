using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;

namespace AutomationFramework
{
    public static class Logger
    {
        public static ExtentReports mainReport;
        public static ExtentTest testUnit;
        public static void CreateNewReport()
        {
            mainReport = new ExtentReports(@".\SampleTestReport.html");
        }

        public static void StartNewTestCase(string TestName)
        {
            testUnit = mainReport.StartTest("New Test: " + TestName);
        }

        public static void FinishTestCase()
        {
            LogStatus currentStatus = testUnit.GetCurrentStatus();
            testUnit.Log(currentStatus, "Finish Test Case with status: " + currentStatus.ToString());
            mainReport.EndTest(testUnit);
        }

        public static void logInfo (string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Info, logDetail);
            if (attachScreenshot) { takeScreenshot(); }
#if DEBUG
            Console.WriteLine("INFO: " + logDetail);
#endif
        }

        public static void logPass(string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Pass, logDetail);
            if (attachScreenshot) { takeScreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASS: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logWarning(string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Warning, logDetail);
            if (attachScreenshot) { takeScreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("WARNING: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logError (string logDetail, bool attachScreenshot = true)
        {
            testUnit.Log(LogStatus.Error, logDetail);
            if(attachScreenshot) { takeScreenshot();  }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logFail(string logDetail, bool attachScreenshot = true)
        {
            testUnit.Log(LogStatus.Fail, logDetail);
            if (attachScreenshot) { takeScreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FAIL: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logSkip(string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Skip, logDetail);
            if (attachScreenshot) { takeScreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SKIP: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static string takeScreenshot()
        {
            var filename = System.DateTime.Today.ToLongTimeString();
            string path = @".\Screenshots\screen"+filename+".png";
            Screenshot screenshot = ((ITakesScreenshot)Browser.driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        } 
    }
}
