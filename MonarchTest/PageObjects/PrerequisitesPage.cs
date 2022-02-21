using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public class PrerequisitesPage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;

        public PrerequisitesPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By bocLogo = By.XPath("//header//img");
        public static By prereqHeading1 = By.XPath("//div/h6[contains(text(),'Prerequisites Before Opening a BOC Account')]");
        public static By prereqHeading2 = By.XPath("//div/h6[contains(text(),'USA Patriot Act')]");
        public static By prereqContinueButton = By.XPath("//button/span[text()='Continue']");
        public static By prereqBackButton = By.CssSelector("div > button > span > a");
        public static By prereqTerm1 = By.XPath("//ul/div/li[1]//span");
        public static By prereqTerm2 = By.XPath("//ul/div/li[2]//span");
        public static By prereqTerm3 = By.XPath("//ul/div/li[3]//span");
        public static By prereqTerm4 = By.XPath("//ul/div/li[4]//span");
        public static By prereqTerm5 = By.XPath("//ul/div/li[5]//span");

        public void gotoNewCustomerSetup()
        {
            try
            {
                Thread.Sleep(2000);
                commonMethod.clickElement(driver, prereqContinueButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while trying to go to Login page" + e.StackTrace);
                throw;
            }

        }
        public void checkPrerequistesPage()
        {
            try
            {
                Thread.Sleep(3000);
                validation.validateElementExists(driver, bocLogo);
                validation.validatePageTitle(driver, "BOC Bank Home Loans and Accounts");
                validation.validateElementExists(driver, prereqHeading1);
                validation.validateElementExists(driver, prereqHeading2);
                validation.validateElementExists(driver, prereqBackButton);
                validation.validateElementExists(driver, prereqContinueButton);
                validation.validateText(driver, prereqTerm1, "You must be a US citizen");
                validation.validateText(driver, prereqTerm2, "You must have a valid physical address where you can be reached");
                validation.validateText(driver, prereqTerm3, "You must be at least 18 years old at the time of opening the account");
                validation.validateText(driver, prereqTerm4, "You must have a valid Social Security Number");
                validation.validateText(driver, prereqTerm5, "Keep handy an original copy of government issued photo ID");
            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Prerequisites Page elements" + e.StackTrace);
                throw;
            }
        }

        public void checkPrerequistesPageUrl(String url)
        {
            try
            {
                Thread.Sleep(3000);
                validation.validatePageUrl(driver, url);


            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Prerequisites Page URL" + e.StackTrace);
                throw;
            }
        }

    }
}
