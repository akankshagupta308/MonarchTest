using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MonarchTest.PageObjects
{
    public class ForgotPwdPage
    {
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        IWebDriver driver;
        ExtentTest _test;

        public ForgotPwdPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By cancelButton = By.CssSelector("button#cancel");
        public static By userEmailInput = By.CssSelector("input#email");
        public static By sendCodeButton = By.CssSelector("button.sendCode");
        public static By continueButton = By.Id("continue");
        public static By verificationCodeInput = By.CssSelector("input#emailVerificationCode");
        public static By bocLogo = By.CssSelector("img.companyLogo");
        public static By verifyCodeButton = By.CssSelector("button.verifyCode");
        public static By sendNewCodeButton = By.CssSelector("button.sendNewCode");
        public static By verificationSuccessMessage = By.Id("emailVerificationControl_success_message");
        public static By verificationErrorMessage = By.Id("emailVerificationControl_error_message");
        public static By emailInputAlert = By.CssSelector("li.EmailBox>div>div.error");
        public static By changeEmailButton = By.Id("emailVerificationControl_but_change_claims");
        public static By newPwdInput = By.Id("newPassword");
        public static By reenterPwdInput = By.Id("reenterPassword");
        public static By resetPwdErrorMissingInput = By.CssSelector("form>div#requiredFieldMissing");
        public static By resetPwdErrorMismatchPwd = By.CssSelector("form>div#passwordEntryMismatch");
        public static By resetPwdErrorIncorrectInput = By.CssSelector("form>div#fieldIncorrect");
        public static By newPwdError = By.CssSelector("div>ul>li.Password:first-of-type>div>div.error");
        public static By reenterPwdError = By.CssSelector("div>ul>li.Password:last-of-type>div>div.error");
        public static String verificationMsg1 = "Verification code has been sent to your inbox. Please copy it to the input box below.";
        public static String verificationMsg2 = "E-mail address verified. You can now continue.";
        public static String errorMsg1 = "The verification has failed, please try again.";



        public void requestVerificationCode(string email)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.enterKeys(driver, userEmailInput, email);
                Thread.Sleep(50);
                commonMethod.clickElement(driver, sendCodeButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in requesting verification code " + e.StackTrace);
                throw;
            }
        }

        public void checkForgotPwdPageElements(int opt=1)
        {
            try
            {
                if (opt==1)
                {
                    validation.validateElementExists(driver, bocLogo);
                    validation.validateElementExists(driver, userEmailInput);
                    validation.validateElementExists(driver, cancelButton);
                    validation.validateElementExists(driver, sendCodeButton);
                    validation.validateElementExists(driver, continueButton);
                    //validation.validateElementEnabled(driver, continueButton, false);
                    validation.validateElementExists(driver, bocLogo);
                }
                else if (opt==2)
                {
                    validation.validateElementExists(driver, bocLogo);
                    validation.validateElementExists(driver, userEmailInput);
                    validation.validateElementExists(driver, cancelButton);
                    //validation.validateElementExists(driver, sendCodeButton);
                    validation.validateElementExists(driver, continueButton);
                    //validation.validateElementEnabled(driver, continueButton, false);
                    validation.validateElementExists(driver, verificationSuccessMessage);
                    validation.validateText(driver, verificationSuccessMessage, verificationMsg1);
                    validation.validateElementExists(driver, verifyCodeButton);
                    validation.validateElementExists(driver, sendNewCodeButton);
                    validation.validateElementExists(driver, bocLogo);
                }
                else if (opt==3)
                {
                    validation.validateElementExists(driver, bocLogo);
                    validation.validateElementExists(driver, userEmailInput);
                    validation.validateElementExists(driver, cancelButton);
                    validation.validateElementExists(driver, continueButton);
                    validation.validateElementExists(driver, changeEmailButton);
                    validation.validateElementExists(driver, verificationSuccessMessage);
                    validation.validateText(driver, verificationSuccessMessage, verificationMsg2);
                }
                else if (opt == 4)
                {
                    validation.validateText(driver, verificationErrorMessage, errorMsg1);
                }
                else if (opt == 5)
                {
                    validation.validateElementExists(driver, bocLogo);
                    validation.validateElementExists(driver, newPwdInput);
                    validation.validateElementExists(driver, reenterPwdInput);
                    validation.validateElementExists(driver, continueButton);
                    validation.validateElementExists(driver, cancelButton);
                    validation.validateElementExists(driver, bocLogo);

                }
                else if (opt == 6)
                {
                    validation.validateElementExists(driver, bocLogo);
                    validation.validateElementExists(driver, userEmailInput);
                    validation.validateElementExists(driver, cancelButton);
                    validation.validateElementExists(driver, sendCodeButton);
                    validation.validateElementExists(driver, continueButton);
                    validation.validateElementExists(driver, emailInputAlert);
                    validation.validateElementExists(driver, bocLogo);
                }
                else
                {
                    Console.WriteLine("Wrong option in checkForgotPwdPageElements");
                    _test.Log(Status.Error, " Wrong option in checkForgotPwdPageElements");
                }
                
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception during verifying Forgot Password page elements" + e.StackTrace);
                throw;
            }
            
        }

        
        public void checkForgotPasswordPageError(String errorMsg, int opt=1)
        {
            try
            {

                switch (opt)
                {
                    case (1):
                        validation.validateText(driver, emailInputAlert, errorMsg);
                        break;
                    case (2):
                        validation.validateText(driver, verificationErrorMessage, errorMsg);
                        break;
                    case (3):
                        validation.validateText(driver, newPwdError, errorMsg);
                        break;
                    case (4):
                        validation.validateText(driver, reenterPwdError, errorMsg);
                        break;
                    case (5):
                        validation.validateText(driver, resetPwdErrorMismatchPwd, errorMsg);
                        break;
                    case (6):
                        validation.validateText(driver, resetPwdErrorIncorrectInput, errorMsg);
                        break;
                    default:
                        Console.WriteLine(" Wrong option in method checkForgotPasswordPageError");
                        break;

                }
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying error message" + e.StackTrace);
                throw;
            }
            
        }


        public void cancelForgotPwd ()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.clickElement(driver, cancelButton);
            }

            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception in cancel Forgot Password "+ e.StackTrace);
                throw;
            }

        }

        public void sendVerificationCode(String code)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.enterKeys(driver, verificationCodeInput, code);
                commonMethod.clickElement(driver, verifyCodeButton);
            }
            
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in sending verification code for Password reset" + e.StackTrace);
                throw;
            }
        }

        public void requestNewCode()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.clickElement(driver, sendNewCodeButton);
            }

            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in requesting new verification code for Password reset" + e.StackTrace);
                throw;
            }
        }

        public void enterNewEmail()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.clickElement(driver, changeEmailButton);
            }

            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in changing email" + e.StackTrace);
                throw;
            }
        }

        public void continueResetPwd()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                commonMethod.clickElement(driver, continueButton);
            }

            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in navigating to reset password" + e.StackTrace);
                throw;
            }
        }

        public void resetPassword(String newPwd, int opt=1)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                if (opt==1)
                {
                    commonMethod.enterKeys(driver, newPwdInput, newPwd);
                }
                else
                {
                    commonMethod.enterKeys(driver, reenterPwdInput, newPwd);
                }
            }

            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in reset password" + e.StackTrace);
                throw;
            }
        }

        
    }
}
