using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public class CustSetupPage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;

        public CustSetupPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By bocLogo = By.XPath("//header//img");
        public static By heading = By.XPath("//div/div/h3");
        public static By firstNameInput = By.Name("firstName");
        public static By lastNAmeInput = By.Name("lastName");
        public static By emailInput = By.Name("emailAddress");
        public static By mobileNumInput = By.Name("mobileNumber");
        public static By pwdInput = By.Id("password");
        public static By showPwdButton = By.XPath("//form/div/div[4]/div/div/button");
        public static By pwdConfirmInput = By.Name("passwordConfirm");
        public static By showConfirmPwdButton = By.XPath("//form/div/div[5]/div/div/button");
        public static By pwdRuleItem1 = By.XPath("//ul/li[1]//span");
        public static By pwdRuleItem2 = By.XPath("//ul/li[2]//span");
        public static By pwdRuleItem3 = By.XPath("//ul/li[3]//span");
        public static By continueButton = By.CssSelector("form>div>div>button");
        public static By existingUserMsg = By.XPath("//div/div[1]/p");
        public static By signInlink = By.XPath("//div/div/div[2]/p");
        public static By firstNameLabel = By.XPath("//form/div/div[1]/div[1]/div/label");
        public static By lastNameLabel = By.XPath("//form/div/div[1]/div[2]/div/label");
        public static By emailLabel = By.XPath("//form/div/div[2]/label");
        public static By mobileNumLabel = By.XPath("//form/div/div[3]/label");
        public static By pwdLabel = By.XPath("//form/div/div[4]/label");
        public static By pwdConfirmLabel = By.XPath("//form/div/div[5]/label");

        public static By firstNameError = By.XPath("//form/div/div[1]/div[1]/div/p");
        public static By lastNameError = By.XPath("//form/div/div[1]/div[2]/div/p");
        public static By emailError = By.XPath("//form/div/div[2]/p");
        public static By pwdError = By.XPath("//form/div/div[4]/p");
        public static By pwdConfirmError = By.XPath("//form/div/div[5]/p");



        public void checkCustSetupPage()
        {
            try
            {
                Thread.Sleep(3000);
                validation.validateElementExists(driver, bocLogo);
                validation.validatePageTitle(driver, "BOC Bank Home Loans and Accounts");
                
                validation.validateElementExists(driver, bocLogo);
                validation.validateText(driver, heading, "Let's get started");
                validation.validateElementExists(driver, firstNameInput);
                validation.validateElementExists(driver, lastNAmeInput);
                validation.validateElementExists(driver, emailInput);
                validation.validateElementExists(driver, mobileNumInput);
                validation.validateElementExists(driver, pwdInput);
                validation.validateElementExists(driver, pwdConfirmInput);
                validation.validateElementExists(driver, showPwdButton);
                validation.validateElementExists(driver, showConfirmPwdButton);
                validation.validateText(driver, pwdRuleItem1, "Password must be 14-64 characters in length");
                //validation.validateText(driver, pwdRuleItem2, "Password must include atleast one uppercase (A-Z)");
                //validation.validateText(driver, pwdRuleItem3, "Password must include atleast one number (0-9)");
                validation.validateElementExists(driver, existingUserMsg);
                validation.validateElementExists(driver, signInlink);
                validation.validateText(driver, firstNameLabel, "First Name");
                validation.validateText(driver, lastNameLabel, "Last Name");
                validation.validateText(driver, emailLabel, "Email");
                validation.validateText(driver, mobileNumLabel, "Mobile Number (Optional)");
                validation.validateText(driver, pwdLabel, "Password");
                validation.validateText(driver, pwdConfirmLabel, "Confirm Password");

            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying New Customer Setup Page elements" + e.StackTrace);
                throw;
            }
        }

        public void checkBlankInputErrors()
        {
            try
            {
                validation.validateText(driver, firstNameError, "First Name is required");
                validation.validateText(driver, lastNameError, "Last Name is required");
                validation.validateText(driver, emailError, "Email Address is required");
                validation.validateText(driver, pwdError, "Password is Required");

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying mandatory fields error on Let's get started page Page elements" + e.StackTrace);
                throw;
            }
        }

        public void checkInvalidEmailError()
        {
            try
            {
                validation.validateText(driver, emailError, "Please enter valid email");

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying invalid email error on Let's get started page Page elements" + e.StackTrace);
                throw;
            }
        }

        public void checkInvalidPwdError(int opt=1)
        {
            try
            {
                if (opt==1)
                {
                    validation.validateText(driver, pwdError, "Password must contain at least 14 character");
                }
                else
                {
                    validation.validateText(driver, pwdConfirmError, "Passwords must match");
                }
                

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying invalid email error on Let's get started page Page elements" + e.StackTrace);
                throw;
            }
        }


        public void checkPwdMasked(int opt = 1, bool masked=true)
        {
            try
            {
                if (opt==1)
                    validation.validateElementMasked(driver, pwdInput, masked);
                else
                    validation.validateElementMasked(driver, pwdConfirmInput, masked);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying password masked/unmasked on Let's get started page Page" + e.StackTrace);
                throw;
            }
        }

        public void inputCustDetails(String fName, String lName, String emailID, String mobileNum, String pwd1, String pwd2)
        {
            try
            {
                commonMethod.enterKeys(driver, firstNameInput, fName);
                commonMethod.enterKeys(driver, lastNAmeInput, lName);
                commonMethod.enterKeys(driver, emailInput, emailID);
                commonMethod.enterKeys(driver, mobileNumInput, mobileNum);
                commonMethod.enterKeys(driver, pwdInput, pwd1);
                commonMethod.enterKeys(driver, pwdConfirmInput, pwd2);
            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while entering data on Let's get started page " + e.StackTrace);
                throw;
            }
        }

        public void submitCustDetails()
        {
            try
            {
                commonMethod.clickElement(driver, continueButton);
            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while submitting new customer details on Let's get started page " + e.StackTrace);
                throw;
            }
        }

        public void togglePasswordView(int opt=1)
        {
            try
            {
                if (opt==1)
                {
                    commonMethod.clickElement(driver, showPwdButton);
                }
                else 
                {
                    commonMethod.clickElement(driver, showConfirmPwdButton);
                }
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in toggle password visibility on Let's get started page " + e.StackTrace);
                throw;
            }
        }

        public void clickSignInLink()
        {
            try
            {
                commonMethod.clickElement(driver, signInlink);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in going to sign in page from Let's get started page " + e.StackTrace);
                throw;
            }
        }
    }
}
