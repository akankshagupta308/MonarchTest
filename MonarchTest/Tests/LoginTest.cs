using NUnit.Framework;
using System;
using System.Threading;
using MonarchTest.PageObjects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace MonarchTest.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        public static string validEmail = config.validEmail;
        public static string validPwd = config.validPwd;
        public static string wrongPwd = config.wrongPwd;
        public static string wrongEmail = config.wrongEmail;
        public static string emptyVal = "";
        public static string logoutUrl = config.MktgUrl;
        public static string env = config.Env;
        public static string validUsername = config.validUsername;

        [OneTimeSetUp]
        public void startTest()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in creating test context for report" + e.StackTrace);
                throw (e);
            }
            try
            {
                _test.Log(Status.Info, "Stating test Case : " + TestContext.CurrentContext.Test.Name );
                var MktgPage = new MktgPage(driver, _test);
                Thread.Sleep(3000);
                _test.Log(Status.Info, "Navigate to Login page");
                MktgPage.gotoLogin(env);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Unable to start Login test" + e.StackTrace);
                throw (e);
            }
        }


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
        public void verifyLoginPageElements()
        {
            
            var loginPage = new LoginPage(driver, _test);
            _test.Log(Status.Info, "Checking Login Page elements");
            Thread.Sleep(3000);
            loginPage.checkLoginPageElements();
            loginPage.checkLoginPageTitle();
            Assert.Pass();
        }

        [Test]
        public void verifyLoginInvalidPwd()
        {
            var loginPage = new LoginPage(driver, _test);
            _test.Log(Status.Info, "Try login with invalid password");
            loginPage.loginuser(validEmail, wrongPwd);
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Checking error message");
            loginPage.checkInvalidLoginError("Your password is incorrect",1);
            Assert.Pass();
        }

        [Test]
        public void verifyLoginInvalidEmail()
        {
            var loginPage = new LoginPage(driver, _test);
            _test.Log(Status.Info, "Try login with invalid user email");
            loginPage.loginuser(wrongEmail, validPwd);
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Checking error message");
            loginPage.checkInvalidLoginError("We can't seem to find your account",1);
            Assert.Pass();
        }


        [Test]
        public void verifyLoginBlankEmail()
        {
            var loginPage = new LoginPage(driver, _test);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            _test.Log(Status.Info, "Try login with blank email");
            loginPage.loginuser(emptyVal, validPwd);
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Checking error message");
            loginPage.checkInvalidLoginError( "Please enter your Email Address", 2);
            Assert.Pass();
        }

        [Test]
        public void verifyLoginBlankPwd()
        {
            var loginPage = new LoginPage(driver, _test);
            _test.Log(Status.Info, "Try login with blank password");
            loginPage.loginuser(validEmail, emptyVal);
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Checking error message");
            loginPage.checkInvalidLoginError("Please enter your password", 3);
            Assert.Pass();
        }

        [Test]
        public void verifyValidLoginLogout()
        {
            var loginPage = new LoginPage(driver, _test);
            _test.Log(Status.Info, "Try login with valid email and password");
            loginPage.loginuser(validEmail, validPwd);
            Thread.Sleep(5000);
            var homePage = new HomePage(driver,_test);
            _test.Log(Status.Info, "Checking welcome message on landing page");
            homePage.checkHomePageElement(HomePageElements.welcome_msg, "Welcome Back, " + validUsername);
            _test.Log(Status.Info, "Click User Profile icon");
            homePage.gotoProfile();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Checking logout button");
            homePage.checkHomePageElement(HomePageElements.logout_btn, "Logout");
            _test.Log(Status.Info, "Try user logout");
            homePage.logoutUser();
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Check redirection to base URL after logout");
            validation.validatePageUrl(driver, logoutUrl);
            Assert.Pass();
        }

        [TearDown]
        public void endTest()
        {
            try
            {
                gotoBaseURL(basePage.home);
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in navigating to Base URL page");
                throw (e);
            }
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
                        _test.Log(logstatus, "Test ended with status " + logstatus );
                        _test.Log(Status.Info, "Exception stacktrace  " + stacktrace);
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
