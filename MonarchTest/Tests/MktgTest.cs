using NUnit.Framework;
using System;
using System.Threading;
using MonarchTest.PageObjects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;


namespace MonarchTest.Tests
{
    [TestFixture]
    public class MktgTest : BaseTest
    {



        [SetUp]
        public void beginTest()
        {
            //Print log at time of starting a testcase
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
                _test.Log(Status.Info, "Stating test Case : " + TestContext.CurrentContext.Test.Name);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while creating test context for report" + e.StackTrace);
                throw (e);
            }


        }

        [Test]

        public void verifyMktgPage()
        {
            var mktgPage = new MktgPage(driver, _test);
            _test.Log(Status.Info, "Check Marketing Page Elements");
            mktgPage.checkMktgPageElements();
            Assert.Pass();
        }

        [Test]

        public void verifyNavtoLoginPage()
        {
            var mktgPage = new MktgPage(driver, _test);
            _test.Log(Status.Info, "Navigate to Login page");
            mktgPage.gotoLogin(config.Env);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(3000);
            var loginPage = new LoginPage(driver, _test);
            loginPage.checkLoginPageTitle();
            Assert.Pass();
        }


        [Test]

        public void verifyNavtoPrereqPersonalPage()
        {
            var mktgPage = new MktgPage(driver, _test);
            _test.Log(Status.Info, "Navigate to New Customer Prerequisites (Personal) page");
            mktgPage.createNewUserAC(config.Env,1);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(3000);
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Check Prerequisites Page Url");
            prereqPage.checkPrerequistesPageUrl(config.PrereqPersonalUrl);
            Assert.Pass();
        }



        [TearDown]
        public void endTest()
        {
            try
            {

                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = " " + TestContext.CurrentContext.Result.StackTrace + " ";
                var errorMsg = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        _test.Log(logstatus, "Test ended with status " + logstatus);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with status " + logstatus);
                        break;
                    case TestStatus.Passed:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with status " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in reporting test status" + e.StackTrace);
                throw (e);
            }
        }


    }
}