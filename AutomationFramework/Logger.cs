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
            mainReport.EndTest(testUnit);
        }

        public static void logInfo (string logDetail)
        {
            testUnit.Log(LogStatus.Info, logDetail);
#if DEBUG
            Console.WriteLine("INFO: " + logDetail);
#endif
        }

        public static void logError (string logDetail, bool attachScreenshot = true)
        {
            testUnit.Log(LogStatus.Error, logDetail);
            if(attachScreenshot) { takeScreenshot();  }
#if DEBUG
            Console.WriteLine("ERROR: " + logDetail);
#endif
        }

        public static void logFail(string logDetail, bool attachScreenshot = true)
        {
            testUnit.Log(LogStatus.Fail, logDetail);
            if (attachScreenshot) { takeScreenshot(); }
#if DEBUG
            Console.WriteLine("FAIL: " + logDetail);
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
