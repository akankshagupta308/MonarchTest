using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
using MonarchTest.PageObjects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;


namespace MonarchTest.Tests
{
    [TestFixture]
    public class ForgotPwdTest : BaseTest
    {
        CommonMethods commonMethod = new CommonMethods();
        public static string validEmail = config.forgotPwdEmail;
        public static string invalidEmail = config.invalidEmail;
        public static string invalidCode = config.forgotPwdInvalidCode;
        public static string validPwd = config.forgotPwdValidPwd1;
        public static string validPwd2 = config.forgotPwdValidPwd2;
        public static string invalidPwd = config.wrongPwd;
        public static string env = config.Env;



        [OneTimeSetUp]
        public void startTest()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name).Info(" Test Started ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in creating test context for report" + e.StackTrace);
                throw (e);
            }
            try
            {
                _test.Log(Status.Info, "Stating test Case : " + TestContext.CurrentContext.Test.Name);
                var MktgPage = new MktgPage(driver, _test);
                Thread.Sleep(3000);
                _test.Log(Status.Info, "Navigate to Login page");
                MktgPage.gotoLogin(env);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Unable to start Forgot Password test" + e.StackTrace);
                throw (e);
            }
        }

        [SetUp]
        public void beginTest()
        {
            try
            {
                var loginPage = new LoginPage(driver, _test);
                Thread.Sleep(5000);
                _test.Log(Status.Info, "Navigate to Forgot Password page");
                loginPage.gotoForgotPwd();
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Unable to start Forgot Password test" + e.StackTrace);
                throw (e);
            }
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

        public void verifyForgotPwdPage()
        {
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Check Forgot Password Page Elements");
            forgotPwdPage.checkForgotPwdPageElements(1);
            Assert.Pass();
        }

        [Test]
        public void verifyEnterEmailValid()
        {
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Request verification code for valid email and check success maessage and other elements on page (Forgot Password)");
            forgotPwdPage.requestVerificationCode(validEmail);
            Thread.Sleep(3000);
            forgotPwdPage.checkForgotPwdPageElements(2);
            Assert.Pass();
        }

        [Test]
        public void verifyEnterEmailBlank()
        {
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Request verification code for blank email and check success maessage on Forgot Password page");
            forgotPwdPage.requestVerificationCode("");
            Thread.Sleep(30);
            forgotPwdPage.checkForgotPasswordPageError("This information is required.", 1);
            Assert.Pass();
        }

        [Test]
        public void verifyEnterEmailInvalid()
        {
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Request verification code for invalid email and check success maessage on Forgot Password page");
            forgotPwdPage.requestVerificationCode(invalidEmail);
            Thread.Sleep(30);
            forgotPwdPage.checkForgotPwdPageElements(6);
            forgotPwdPage.checkForgotPasswordPageError("Please enter a valid email address.", 1);
            Assert.Pass();
        }

        [Test]
        public void verifyCancelForgotPassword()
        {
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Click Cancel button on Forgot Password page and check navigation back to Login page");
            forgotPwdPage.cancelForgotPwd();
            Thread.Sleep(3000);
            var loginPage = new LoginPage(driver, _test);
            loginPage.checkLoginPageElements();
            Assert.Pass();
        }

        [Test]
        public void verifyEmailCodeValidResetPwd()
        {
            By verificationEmailMsg = By.XPath("//div/table/tbody/tr[2]/td[3]");
            By verificationCodeText = By.XPath("//tbody//div[2]/span");
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Enter valid email and verification code on Forgot Password page and check successful password reset");
            _test.Log(Status.Info, "Enter valid email and request for verification code");
            forgotPwdPage.requestVerificationCode(validEmail);
            _test.Log(Status.Info, "Read verification code sent to mailbox");
            Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (env == "qa")
                js.ExecuteScript("window.open('https://mailsac.com/inbox/gina.harris@mailsac.com', '_blank');");
            else
                js.ExecuteScript("window.open('https://mailsac.com/inbox/mark.harris@mailsac.com', '_blank');");

            driver.SwitchTo().Window(driver.WindowHandles[2]);
            Thread.Sleep(8000);
            driver.Navigate().Refresh();
            Thread.Sleep(8000);
            commonMethod.clickElement(driver, verificationEmailMsg);
            String codeText =  commonMethod.getElementText(driver, verificationCodeText);
            String codeValue = codeText.Substring(14,6);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            _test.Log(Status.Info, "Enter verification code in User Dtails page");
            forgotPwdPage.sendVerificationCode(codeValue);
            Thread.Sleep(5000);
            validation.validatePageTitle(driver, "User details");
            _test.Log(Status.Info, "Check success message and other elements on User details page");
            forgotPwdPage.checkForgotPwdPageElements(3);
            _test.Log(Status.Info, "Click Continue button to go to ResetPassword page");
            forgotPwdPage.continueResetPwd();
            _test.Log(Status.Info, "Enter new password on ResetPassword page");
            forgotPwdPage.resetPassword(validPwd, 1);
            forgotPwdPage.resetPassword(validPwd, 2);
            forgotPwdPage.continueResetPwd();
            _test.Log(Status.Info, "Check password reset successful and user lands on login page");
            Thread.Sleep(8000);
            var loginPage = new LoginPage(driver, _test);
            loginPage.checkLoginPageElements();
            _test.Log(Status.Info, "Check user login with new password");
            loginPage.loginuser(validEmail, validPwd);
            var homePage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Checking welcome message on landing page");
            if (env=="qa")
                homePage.checkHomePageElement(HomePageElements.welcome_msg, "Welcome Back, Gina Harris");
            else
                homePage.checkHomePageElement(HomePageElements.welcome_msg, "Welcome Back, Mark Harris");

            Assert.Pass();

        }


        [Test]
        public void verifyInvalidCodeError()
        {
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Enter invalid verification code on Forgot Password page and check Error message");
            _test.Log(Status.Info, "Enter valid email and request for verification code");
            forgotPwdPage.requestVerificationCode(validEmail);
            Thread.Sleep(3000);
            _test.Log(Status.Info, "Enter invalid verification code in User Details page");
            forgotPwdPage.sendVerificationCode(invalidCode);
            Thread.Sleep(3000);
            validation.validatePageTitle(driver, "User details");
            _test.Log(Status.Info, "Check error message and other elements page");
            forgotPwdPage.checkForgotPwdPageElements(4);
            Assert.Pass();

        }

        [Test]
        public void verifyBlankNewPwdError()
        {
            By verificationEmailMsg = By.XPath("//div/table/tbody/tr[2]/td[3]");
            By verificationCodeText = By.XPath("//tbody//div[2]/span");
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Enter valid email and verification code on Forgot Password page and check successful password reset");
            _test.Log(Status.Info, "Enter valid email and request for verification code");
            forgotPwdPage.requestVerificationCode(validEmail);
            _test.Log(Status.Info, "Read verification code sent to mailbox");
            Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (env == "qa")
                js.ExecuteScript("window.open('https://mailsac.com/inbox/gina.harris@mailsac.com', '_blank');");
            else
                js.ExecuteScript("window.open('https://mailsac.com/inbox/mark.harris@mailsac.com', '_blank');");

            driver.SwitchTo().Window(driver.WindowHandles[2]);
            Thread.Sleep(8000);
            driver.Navigate().Refresh();
            Thread.Sleep(8000);
            commonMethod.clickElement(driver, verificationEmailMsg);
            String codeText = commonMethod.getElementText(driver, verificationCodeText);
            String codeValue = codeText.Substring(14, 6);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            _test.Log(Status.Info, "Enter verification code in User Dtails page");
            forgotPwdPage.sendVerificationCode(codeValue);
            validation.validatePageTitle(driver, "User details");
            _test.Log(Status.Info, "Check success message and other elements on User details page");
            forgotPwdPage.checkForgotPwdPageElements(3);
            _test.Log(Status.Info, "Click Continue button to go to ResetPassword page");
            forgotPwdPage.continueResetPwd();
            _test.Log(Status.Info, "Enter blank new password on ResetPassword page");
            forgotPwdPage.resetPassword("", 1);
            forgotPwdPage.resetPassword("", 2);
            forgotPwdPage.continueResetPwd();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _test.Log(Status.Info, "Check new passworrd error");
            forgotPwdPage.checkForgotPwdPageElements(5);
            forgotPwdPage.checkForgotPasswordPageError("This information is required.", 3);
            forgotPwdPage.checkForgotPasswordPageError("This information is required.", 4);
            Assert.Pass();

        }

        [Test]
        public void verifyInvalidNewPwdError()
        {
            By verificationEmailMsg = By.XPath("//div/table/tbody/tr[2]/td[3]");
            By verificationCodeText = By.XPath("//tbody//div[2]/span");
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Enter valid email and verification code on Forgot Password page and check successful password reset");
            _test.Log(Status.Info, "Enter valid email and request for verification code");
            forgotPwdPage.requestVerificationCode(validEmail);
            _test.Log(Status.Info, "Read verification code sent to mailbox");
            Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (env == "qa")
                js.ExecuteScript("window.open('https://mailsac.com/inbox/gina.harris@mailsac.com', '_blank');");
            else
                js.ExecuteScript("window.open('https://mailsac.com/inbox/mark.harris@mailsac.com', '_blank');");

            driver.SwitchTo().Window(driver.WindowHandles[2]);
            Thread.Sleep(8000);
            driver.Navigate().Refresh();
            Thread.Sleep(8000);
            commonMethod.clickElement(driver, verificationEmailMsg);
            String codeText = commonMethod.getElementText(driver, verificationCodeText);
            String codeValue = codeText.Substring(14, 6);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            _test.Log(Status.Info, "Enter verification code in User Dtails page");
            forgotPwdPage.sendVerificationCode(codeValue);
            validation.validatePageTitle(driver, "User details");
            _test.Log(Status.Info, "Check success message and other elements on User details page");
            forgotPwdPage.checkForgotPwdPageElements(3);
            _test.Log(Status.Info, "Click Continue button to go to ResetPassword page");
            forgotPwdPage.continueResetPwd();
            _test.Log(Status.Info, "Enter invalid new password on ResetPassword page");
            forgotPwdPage.resetPassword(invalidPwd, 1);
            forgotPwdPage.resetPassword(invalidPwd, 2);
            forgotPwdPage.continueResetPwd();
            forgotPwdPage.checkForgotPwdPageElements(5);
            _test.Log(Status.Info, "Check new passworrd error");
            forgotPwdPage.checkForgotPasswordPageError("One or more fields are filled out incorrectly. Please check your entries and try again.", 6);
            forgotPwdPage.checkForgotPasswordPageError("The password must be between 8 and 64 characters." + "\r\n" +
                "The password must have at least 3 of the following:" + "\r\n" + "  - a lowercase letter" + "\r\n"
                + "  - an uppercase letter" + "\r\n" + "  - a digit" + "\r\n" + "  - a symbol", 3);
            forgotPwdPage.checkForgotPasswordPageError("The password must be between 8 and 64 characters." + "\r\n" +
                "The password must have at least 3 of the following:" + "\r\n" + "  - a lowercase letter" + "\r\n"
                + "  - an uppercase letter" + "\r\n" + "  - a digit" + "\r\n" + "  - a symbol", 4);

            Assert.Pass();

        }


        [Test]
        public void verifyMismatchNewPwdError()
        {
            By verificationEmailMsg = By.XPath("//div/table/tbody/tr[2]/td[3]");
            By verificationCodeText = By.XPath("//tbody//div[2]/span");
            var forgotPwdPage = new ForgotPwdPage(driver, _test);
            _test.Log(Status.Info, "Enter valid email and verification code on Forgot Password page and check successful password reset");
            _test.Log(Status.Info, "Enter valid email and request for verification code");
            forgotPwdPage.requestVerificationCode(validEmail);
            _test.Log(Status.Info, "Read verification code sent to mailbox");
            Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (env == "qa")
                js.ExecuteScript("window.open('https://mailsac.com/inbox/gina.harris@mailsac.com', '_blank');");
            else
                js.ExecuteScript("window.open('https://mailsac.com/inbox/mark.harris@mailsac.com', '_blank');");

            driver.SwitchTo().Window(driver.WindowHandles[2]);
            Thread.Sleep(8000);
            driver.Navigate().Refresh();
            Thread.Sleep(8000);
            commonMethod.clickElement(driver, verificationEmailMsg);
            String codeText = commonMethod.getElementText(driver, verificationCodeText);
            String codeValue = codeText.Substring(14, 6);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            _test.Log(Status.Info, "Enter verification code in User Details page");
            forgotPwdPage.sendVerificationCode(codeValue);
            validation.validatePageTitle(driver, "User details");
            _test.Log(Status.Info, "Check success message and other elements on User details page");
            forgotPwdPage.checkForgotPwdPageElements(3);
            _test.Log(Status.Info, "Click Continue button to go to ResetPassword page");
            forgotPwdPage.continueResetPwd();
            _test.Log(Status.Info, "Enter mismatch passwords on ResetPassword page");
            forgotPwdPage.resetPassword(validPwd, 1);
            forgotPwdPage.resetPassword(validPwd2, 2);
            forgotPwdPage.continueResetPwd();
            Thread.Sleep(3000);
            _test.Log(Status.Info, "Check new passworrd error");
            forgotPwdPage.checkForgotPasswordPageError("The password entry fields do not match. Please enter the same password in both fields and try again.", 5);

            Assert.Pass();

        }


        [TearDown]
        public void endTest()
        {
            try
            {
                gotoBaseURL(basePage.home);
                Thread.Sleep(5000);
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