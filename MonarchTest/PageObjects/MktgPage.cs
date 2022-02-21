using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MonarchTest.PageObjects
{
    public class MktgPage
    {
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        IWebDriver driver;
        ExtentTest _test;

        public MktgPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By pageHeader = By.XPath("//h1/span");
        public static By qaLoginButton = By.XPath("//div[@id='masterPage']//div[@id='SITE_HEADER']//div[4]/a");
        public static By devLoginButton = By.XPath("(//div[@id='masterPage']//div[@id='SITE_PAGES']//div[4]/a)[1]");
        public static By qaCreatePersonalButton = By.XPath("//div[@id='masterPage']//div[@id='SITE_HEADER']//div[2]/a/div/span[1]");
        public static By qaCreateBusinessButton = By.XPath("//div[@id='masterPage']//div[@id='SITE_HEADER']//div[3]/a/div/span[1]");
        public static By devCreatePeronalButton = By.XPath("(//div[@id='masterPage']//div[@id='SITE_PAGES']//div[2]/a)[1]");
        public static By devCreateBusinessButton = By.XPath("(//div[@id='masterPage']//div[@id='SITE_PAGES']//div[3]/a)[1]");

        public void gotoLogin(String env)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                if(env == "qa")
                {
                    commonMethod.clickElement(driver, qaLoginButton);
                }
                else
                {
                    commonMethod.clickElement(driver, devLoginButton);
                }
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in navigating to login page - " + e.StackTrace);
                throw;
            }
        }

        public void checkMktgPageElements()
        {
            try
            {
                validation.validateElementExists(driver, qaLoginButton);
                validation.validateElementExists(driver, devLoginButton);
                validation.validateText(driver, pageHeader, "Future Home of BOC Bank");
                validation.validateText(driver, qaCreatePersonalButton, "Create Personal Account");
                validation.validateText(driver, qaCreateBusinessButton, "Create Business Account");
                validation.validateText(driver, devCreatePeronalButton, "Create Personal Account");
                validation.validateText(driver, devCreateBusinessButton, "Create Business Account");
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception during verifying Marketing page elements" + e.StackTrace);
                throw;
            }
            
        }
        

        public void createNewUserAC(String env,int opt=1)
        {
            try
            {
                if(env=="qa")
                {
                    if (opt==1)
                        commonMethod.clickElement(driver, qaCreatePersonalButton);
                    else
                        commonMethod.clickElement(driver, qaCreateBusinessButton);
                }
                else
                {
                    if(opt==1)
                        commonMethod.clickElement(driver, devCreatePeronalButton);
                    else
                        commonMethod.clickElement(driver, devCreateBusinessButton);
                }
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception trying to create personal account on marketing page" + e.StackTrace);
                throw;
            }
            
        }
        
    }
}
