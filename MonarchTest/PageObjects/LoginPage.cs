using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MonarchTest.PageObjects
{
    public class LoginPage
    {
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        IWebDriver driver;
        ExtentTest _test;

        public LoginPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        //public static String qaUrl = "monarchqa";
        public static By loginFormHeading = By.CssSelector("#localAccountForm > div.intro > h2");
        public static By loginEmail = By.CssSelector("input#email");
        public static By loginPasswd = By.CssSelector("input#password");
        public static By loginSubmit = By.Id("next");
        public static By forgotPwdLink = By.Id("forgotPassword");
        public static By signupMessage = By.CssSelector("div.create > p");
        public static By signupLink = By.Id("createAccount");
        public static By bocLogo = By.CssSelector("img.companyLogo");
        public static By loginErrorMessage = By.XPath("//*[@id='localAccountForm']/div[2]/p");
        public static By blankPwdError = By.XPath("//*[@id='localAccountForm']/div[3]/div[2]/div[2]/p");
        public static By blankEmailError = By.XPath("//*[@id='localAccountForm']/div[3]/div[1]/div/p");

        public void loginuser(string email, string pwd)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.enterKeys(driver, loginEmail, email);
                commonMethod.enterKeys(driver, loginPasswd, pwd);
                Thread.Sleep(3000);
                commonMethod.clickElement(driver, loginSubmit);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception during login operation - " + e.StackTrace);
                throw;
            }
        }

        public void checkLoginPageElements()
        {
            try
            {
                validation.validateElementExists(driver, bocLogo);
                validation.validateElementExists(driver, forgotPwdLink);
                validation.validateElementExists(driver, loginEmail);
                validation.validateElementExists(driver, loginPasswd);
                validation.validateElementExists(driver, loginSubmit);
                validation.validatePageTitle(driver, "Choose your account");
                validation.validateText(driver, loginFormHeading, "Sign in with your email address");
                //validation.validateElementExists(driver, signupMessage);
                //validation.validateElementExists(driver, signupLink);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception during verifying Login page elements" + e.StackTrace);
                throw;
            }
            
        }

        public void checkLoginPageTitle()
        {
            try
            {
                validation.validatePageTitle(driver, "Choose your account");
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception during verifying login page title" + e.StackTrace);
                throw;
            }
        }

        public void checkInvalidLoginError(String errorMsg, int opt=1)
        {
            try
            {
                if (opt == 1)
                {
                    validation.validateText(driver, loginErrorMessage, errorMsg);
                }
                else if (opt == 2)
                {
                    validation.validateText(driver, blankEmailError, errorMsg);
                }
                else if (opt == 3)
                {
                    validation.validateText(driver, blankPwdError, errorMsg);
                }
                else
                {
                    _test.Log(Status.Error, "Wrong option used in method checkInvalidInputError");
                }
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying login error message" + e.StackTrace);
                throw;
            }
            
        }

        public void gotoForgotPwd()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.clickElement(driver, forgotPwdLink);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in navigating to Forgot Password page " + e.StackTrace);
                throw;
            }
        }
    }
}
