using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public class PersonalInfoPage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;

        public PersonalInfoPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By bocLogo = By.XPath("//header//img");
        public static By heading = By.XPath("//h4");
        public static By subHeading = By.XPath("//div/div[2]/span");
        public static By dobInput = By.Name("dob");
        public static By ssnInput = By.Name("ssn");
        public static By ssnInfoMsg = By.Name("emailAddress");
        public static By dobButton = By.XPath("//form/div[1]/div[1]//div/button");
        public static By backButton = By.XPath("//form/div[1]/div[3]/div[1]/button/span[1]");
        public static By nextButton = By.XPath("//form/div[1]/div[3]/div[2]/button/span[1]");
        public static By ssnShowHideButton = By.XPath("//form/div[1]/div[2]//div/button");
        public static By ssnEncryptionInfoMsg = By.XPath("//form/div[1]/div[2]/ul/li/div[2]/span");
        public static By dobLabel = By.XPath("//div/div[1]/div/label");
        public static By ssnLabel = By.XPath("//form/div/div[2]/div/label");
        public static By sidepaneItem1 = By.XPath("//ul/li[1]/div/p");
        public static By sidepaneItem2 = By.XPath("//ul/li[2]/div/p");
        public static By sidepaneItem3 = By.XPath("//ul/li[3]/div/p");
        public static By sidepaneItem4 = By.XPath("//ul/li[4]/div/p");
        public static By dobError = By.XPath("//form/div/div[1]/div[1]/div/p");
        public static By ssnError = By.XPath("//form/div/div[2]//div/p");
        public static String currentUrl = "https://qa.mybocbank.com/new-customer-onboarding";
        


        public void checkPersonalInfoPage()
        {
            try
            {
                Thread.Sleep(3000);
                validation.validatePageTitle(driver, "BOC Bank Home Loans and Accounts");
                validation.validateCurrentUrl(driver, currentUrl);
                validation.validateElementExists(driver, bocLogo);
                validation.validateText(driver, heading, "It’s time to get personal");
                validation.validateElementExists(driver, dobInput);
                validation.validateElementExists(driver, dobButton);
                validation.validateElementExists(driver, ssnInput);
                validation.validateElementExists(driver, ssnShowHideButton);
                validation.validateText(driver, subHeading, "Tell us a little more about yourself");
                validation.validateText(driver, ssnEncryptionInfoMsg, "BOC Bank secures your SSN information with 256-bit encryption");
                validation.validateText(driver, dobLabel, "Date of Birth *");
                validation.validateText(driver, ssnLabel, "Social Security Number");
                validation.validateElementExists(driver, backButton);
                validation.validateElementExists(driver, nextButton);
                validation.validateText(driver, backButton, "Back");
                validation.validateText(driver, nextButton, "Next");
                validation.validateText(driver, sidepaneItem1, "Address Info");
                validation.validateText(driver, sidepaneItem2, "Personal Details");
                validation.validateText(driver, sidepaneItem3, "Uploads");
                validation.validateText(driver, sidepaneItem4, "Review Info");
            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying New Personal Info Page elements" + e.StackTrace);
                throw;
            }
        }

        public void checkInvalidSSNError()
        {
            try
            {
                validation.validateText(driver, ssnError, "The Social Security Number you have entered is not valid");
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying SSN field error on Personal InfoPage" + e.StackTrace);
                throw;
            }
        }


        public void checkPwdMasked(bool masked=true)
        {
            try
            {
                validation.validateElementMasked(driver, ssnInput, masked);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying SSN masked/unmasked on Personal Info Page" + e.StackTrace);
                throw;
            }
        }

        public bool checkDefaultDOB()
        {
         try
            {
                DateTime dobDateValue = DateTime.Today.AddYears(-18);
                String dobActual = commonMethod.getElementValue(driver, dobInput);
                String dobExpected = dobDateValue.ToString("MM") + "/" + dobDateValue.ToString("dd") + "/" + dobDateValue.ToString("yyyy");
                return (dobExpected == dobActual);

            }

            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while checking default date on Personal Info page " + e.StackTrace);
                throw;
            }

        }

        public void inputPIIDetails(String ssnVal, String dateVal = "")
        {
            try
            {
                commonMethod.enterKeys(driver, ssnInput, ssnVal);
                
                if (dateVal != "")
                    commonMethod.enterKeys(driver, dobInput, dateVal);

            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while entering data on Personal Info page " + e.StackTrace);
                throw;
            }
        }

        public void submitPIIDetails()
        {
            try
            {
                commonMethod.clickElement(driver, nextButton);
            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while submitting new customer PII details on Personal Info page " + e.StackTrace);
                throw;
            }
        }

        public void toggleSSNView()
        {
            try
            {
                commonMethod.clickElement(driver, ssnShowHideButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in toggle SSN visibility on Personal Info page " + e.StackTrace);
                throw;
            }
        }

        public void gotoPrevious()
        {
            try
            {
                commonMethod.clickElement(driver, backButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in going to previous page from Personal Info page " + e.StackTrace);
                throw;
            }
        }
    }
}
