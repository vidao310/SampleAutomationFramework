using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using saucelabs.saucerest;
using NUnit.Framework;

namespace AutomationFramework
{
    public static class Logger
    {
        public static ExtentReports mainReport;
        public static ExtentTest testUnit;
        public static SauceREST sauce;
        public static bool HasFailTest = false;
        public static void CreateNewReport()
        {
            mainReport = new ExtentReports(@"C:\temp\SampleTestReport.html");
            Console.WriteLine("mainReport path is at" + mainReport.ToString());
            sauce = new SauceREST("USERNAME***", "KEY*****"); //TODO refactor 
        }

        public static void AddSystemInfo(string param, string value)
        {
            mainReport.AddSystemInfo(param, value);
        }

        public static void FinishAllTests()
        {
            var session = ((RemoteWebDriver)Browser.driver).SessionId.ToString();
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
                sauce.updateJobInfo(session, new Dictionary<string, object> { { "passed", true } });
            else
                sauce.updateJobInfo(session, new Dictionary<string, object> { { "passed", false } });

            Browser.CloseBroswer();
            Browser.driver.Quit();
            mainReport.Close();
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
            mainReport.Flush();
        }

        public static void logInfo (string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Info, logDetail);
            if (attachScreenshot) { logSreenshot(); }
#if DEBUG
            Console.WriteLine("INFO: " + logDetail);
#endif
        }

        public static void logPass(string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Pass, logDetail);
            if (attachScreenshot) { logSreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASS: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logWarning(string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Warning, logDetail);
            if (attachScreenshot) { logSreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("WARNING: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logError (string logDetail, bool attachScreenshot = true)
        {
            testUnit.Log(LogStatus.Error, logDetail);
            if(attachScreenshot) { logSreenshot();  }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logFail(string logDetail, bool attachScreenshot = true)
        {
            testUnit.Log(LogStatus.Fail, logDetail);
            if (attachScreenshot) { logSreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FAIL: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logSkip(string logDetail, bool attachScreenshot = false)
        {
            testUnit.Log(LogStatus.Skip, logDetail);
            if (attachScreenshot) { logSreenshot(); }
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SKIP: " + logDetail);
            Console.ResetColor();
#endif
        }

        public static void logSreenshot(string screenshotName = "screen")
        {
            var screenshotPath = takeScreenshot(screenshotName);
            testUnit.Log(LogStatus.Info, testUnit.AddScreenCapture(@screenshotPath));
        }

        private static string takeScreenshot(string screenshotName = "screen")
        {
            var filename = screenshotName+System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string path = @"C:\temp\Screenshots\"+filename+".png";
            Screenshot screenshot = ((ITakesScreenshot)Browser.driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        } 
    }
}
