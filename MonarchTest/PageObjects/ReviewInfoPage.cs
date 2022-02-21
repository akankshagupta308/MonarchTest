using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public class ReviewInfoPage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;

        public ReviewInfoPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By bocLogo = By.XPath("//header//img");
        public static By heading = By.XPath("//h4");
        public static By sidepaneItem1 = By.XPath("//ul/li[1]/div/p");
        public static By sidepaneItem2 = By.XPath("//ul/li[2]/div/p");
        public static By sidepaneItem3 = By.XPath("//ul/li[3]/div/p");
        public static By sidepaneItem4 = By.XPath("//ul/li[4]/div/p");
        public static String currentUrl = "mybocbank.com/new-customer-onboarding";
        public static By nameLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[1]/div[1]/h6");
        public static By nameValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[1]/div[2]/h6");
        public static By nameChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[1]/div[2]/span/a");
        public static By emailLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[1]/h6");
        public static By emailValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/h6");
        public static By emailChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/span/a");
        public static By emailShowHideButton = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[2]/div[2]/button");
        public static By pwdLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[3]/div[1]/h6");
        public static By pwdValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[3]/div[2]/h6");
        public static By pwdChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[3]/div[2]//a");
        public static By pwdShowHideButton = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[3]/div[2]/button");
        public static By mobileNumLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[4]/div[1]/h6");
        public static By mobileNumValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[4]/div[2]/h6");
        public static By mobileNumChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[4]/div[2]//a");
        public static By mobileNumShowHideButton = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[4]/div[2]/button");
        public static By physicalAddLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[5]/div[1]/h6");
        public static By physicalAddValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[5]/div[2]/h6");
        public static By physicalAddChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[5]/div[2]//a");
        public static By mailingAddLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[6]/div[1]/h6");
        public static By mailingAddValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[6]/div[2]/h6");
        public static By mailingAddChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[6]/div[2]//a");
        public static By dobLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[7]/div[1]/h6");
        public static By dobValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[7]/div[2]/h6");
        public static By dobChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[7]/div[2]//a");
        public static By dobShowHideButton = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[7]/div[2]/button");
        public static By ssnLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[8]/div[1]/h6");
        public static By ssnValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[8]/div[2]/h6");
        public static By ssnChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[8]/div[2]//a");
        public static By ssnShowHideButton = By.XPath("//div/div[4]/div[2]/div/div[2]/div[1]/div[8]/div[2]/button");
        public static By idTypeLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[5]/div[1]/h6");
        public static By idTypeValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[5]/div[2]/h6");
        public static By idTypeChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[5]/div[2]//a");
        public static By idNumLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[6]/div[1]/h6");
        public static By idNumValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[6]/div[2]/h6");
        public static By idNumChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[6]/div[2]//a");
        public static By idNumShowHideButton = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[6]/div[2]/button");

        public static By photoSelfLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[1]/h6");
        public static By photoSelfValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[2]/h6[1]");
        public static By photoSelfChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[2]/h6[2]");
        public static By photoIDLabel = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[3]/h6");
        public static By photoIDFrontValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[4]/div[1]/h6[1]");
        public static By photoIDFrontChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[4]/div[1]/h6[2]");
        public static By photoIDBackValue = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[4]/div[2]/h6[1]");
        public static By photoIDBackChangeLink = By.XPath("//div/div[4]/div[2]/div/div[2]/div[2]/div[4]/div[2]/h6[2]");
        public static By backButton = By.XPath("//div/div[4]/div[2]/div/div[3]/div/div[1]/button/span[1]");
        public static By verifyButton = By.XPath("//div/div[4]/div[2]/div/div[3]/div/div[2]/button/span[1]");
        


        public void checkReviewInfoPage()
        {
            try
            {
                Thread.Sleep(5000);
                validation.validatePageTitle(driver, "BOC Bank Home Loans and Accounts");
                validation.validateCurrentUrl(driver, currentUrl);
                validation.validateElementExists(driver, bocLogo);
                validation.validateText(driver, heading, "Review Information");
                validation.validateText(driver, nameLabel, "Name");
                validation.validateElementExists(driver, nameValue);
                validation.validateText(driver, nameChangeLink, "Change");
                validation.validateText(driver, emailLabel, "Email");
                validation.validateElementExists(driver, emailValue);
                validation.validateText(driver, emailChangeLink, "Change");
                validation.validateElementExists(driver, emailShowHideButton);
                validation.validateText(driver, pwdLabel, "Password");
                validation.validateElementExists(driver, pwdValue);
                validation.validateText(driver, pwdChangeLink, "Change");
                validation.validateElementExists(driver, pwdShowHideButton);
                validation.validateText(driver, mobileNumLabel, "Mobile No.");
                validation.validateElementExists(driver, mobileNumValue);
                validation.validateText(driver, mobileNumChangeLink, "Change");
                validation.validateElementExists(driver, mobileNumShowHideButton);
                validation.validateText(driver, physicalAddLabel, "Physical Address");
                validation.validateElementExists(driver, physicalAddValue);
                validation.validateText(driver, physicalAddChangeLink, "Change");
                validation.validateText(driver, mailingAddLabel, "Mailing Address");
                validation.validateElementExists(driver, mailingAddValue);
                validation.validateText(driver, mailingAddChangeLink, "Change");
                validation.validateText(driver, dobLabel, "Date of Birth");
                validation.validateElementExists(driver, dobValue);
                validation.validateText(driver, dobChangeLink, "Change");
                validation.validateElementExists(driver, dobShowHideButton);
                validation.validateText(driver, ssnLabel, "SSN");
                validation.validateElementExists(driver, ssnValue);
                validation.validateText(driver, ssnChangeLink, "Change");
                validation.validateElementExists(driver, ssnShowHideButton);
                validation.validateText(driver, photoSelfLabel, "Selfie");
                validation.validateElementExists(driver, photoSelfValue);
                validation.validateText(driver, photoSelfChangeLink, "Change");
                validation.validateText(driver, photoIDLabel, "Photo ID");
                validation.validateElementExists(driver, photoIDFrontValue);
                validation.validateText(driver, photoIDFrontChangeLink, "Change");
                validation.validateElementExists(driver, photoIDBackValue);
                validation.validateText(driver, photoIDBackChangeLink, "Change");
                validation.validateText(driver, idTypeLabel, "Photo Type ID");
                validation.validateElementExists(driver, idTypeValue);
                validation.validateText(driver, idTypeChangeLink, "Change");
                validation.validateText(driver, idNumLabel, "Photo ID No.");
                validation.validateElementExists(driver, idNumValue);
                validation.validateText(driver, idNumChangeLink, "Change");
                validation.validateElementExists(driver, idNumShowHideButton);
                validation.validateText(driver, backButton, "Back");
                validation.validateText(driver, verifyButton, "Verify");
                validation.validateText(driver, sidepaneItem1, "Address Info");
                validation.validateText(driver, sidepaneItem2, "Personal Details");
                validation.validateText(driver, sidepaneItem3, "Uploads");
                validation.validateText(driver, sidepaneItem4, "Review Info");
                
            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Review Customer Info Page elements" + e.StackTrace);
                throw;
            }
        }

        public bool checkData(string name, string email, string mobileNum,  
            string dob, string ssn, string photoIDType, string photoIdNum)
        {
            
            try
            {
                bool valuesMatch=true;
                
                if (commonMethod.getElementValue(driver, nameValue) != name)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect name on Review Info page");
                }
                if (commonMethod.getElementValue(driver, emailValue) != email)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect Email on Review Info page");
                }
                if (commonMethod.getElementValue(driver, mobileNumValue) != mobileNum)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect Mobile Number on Review Info page");
                }/*
                if(commonMethod.getElementValue(driver, physicalAddValue) != physicalAdd)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect physical address on Review Info page");
                }
                if (commonMethod.getElementValue(driver, mailingAddValue) != mailingAdd)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect mailing address on Review Info page");
                }*/
                if (commonMethod.getElementValue(driver, dobValue) != dob)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect DOB on Review Info page");
                }
                if (commonMethod.getElementValue(driver, ssnValue) != ssn)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect SSN on Review Info page");
                }
                if (commonMethod.getElementValue(driver, idTypeValue) != photoIDType)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect Photo ID Type on Review Info page");
                }
                if (commonMethod.getElementValue(driver, idNumValue) != photoIdNum)
                {
                    valuesMatch = false;
                    _test.Log(Status.Error, "Incorrect Photo ID Number on Review Info page");
                }
                return valuesMatch;

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Chnage upload links on Upload ID Page " + e.StackTrace);
                throw;
            }
            
        }

        public void changeCustDetails(int opt)
        {
            
          
            try
            {
               
             
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Chnage upload links on Upload ID Page " + e.StackTrace);
                throw;
            }
        }

        public void checkFieldMasked(bool masked = true)
        {
            try
            {
                validation.validateElementMasked(driver, emailValue,masked);
                validation.validateElementMasked(driver, pwdValue, masked);
                validation.validateElementMasked(driver, mobileNumValue, masked);
                validation.validateElementMasked(driver, dobValue, masked);
                validation.validateElementMasked(driver, ssnValue, masked);
                validation.validateElementMasked(driver, idNumValue, masked);

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying ID Number masked/unmasked on Upload ID Page" + e.StackTrace);
                throw;
            }
        }

        public void unmaskAllValues()
        {
            try
            {
                commonMethod.clickElement(driver, idNumShowHideButton);
                commonMethod.clickElement(driver, dobShowHideButton);
                commonMethod.clickElement(driver, ssnShowHideButton);
                commonMethod.clickElement(driver, emailShowHideButton);
                commonMethod.clickElement(driver, mobileNumValue);
                commonMethod.clickElement(driver, pwdShowHideButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in toggle ID Number visibility on Upload ID page " + e.StackTrace);
                throw;
            }
        }



        public void submitVerifiedDetails()
        {
            try
            {
                commonMethod.clickElement(driver, verifyButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while submitting customer details on Review Info page " + e.StackTrace);
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
                _test.Log(Status.Error, "Exception in going to previous page from Review Info page " + e.StackTrace);
                throw;
            }
        }
    }
}
