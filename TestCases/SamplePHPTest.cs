using AutomationFramework;
using AutomationFramework.PagesObject;
using NUnit.Framework;

namespace TestCases
{
    [TestFixture]
    public class SamplePHPTest
    {
        [OneTimeSetUp]
        public void InitialSetup()
        {
            Logger.CreateNewReport();
        }

        [Test]
        public void Test_GoTo_PHPNet()
        {
            Logger.StartNewTestCase("Test PHP site");
            Browser.OpenNewBrowser("remote");
            Browser.GoToURL("http://php.net");
            Logger.FinishTestCase();
        }

        [Test]
        public void Test_Search_For_Eval()
        {
            Logger.StartNewTestCase("Test Search for Eval");
            PHP_HomePage.SearchFor("eval");
            Logger.logSreenshot("SampleScreenshot");
            ValidateUrl.UrlEqual("http://php.net/manual/en/function.eval.php");
            ValidateElement.Exist(PHP_DocumentPage.Caution_label);
            Logger.FinishTestCase();
        }

        [OneTimeTearDown]
        public void FinalCleanUp()
        {
            Logger.FinishAllTests();
        }
    }
}
