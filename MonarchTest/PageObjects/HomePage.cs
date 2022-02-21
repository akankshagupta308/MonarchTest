using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public enum HomePageElements
    {
        welcome_msg,
        date_today,
        logout_btn,
        boc_logo,
        tab_home,
        tab_accounts,
        tab_manageMoney,
        tab_loans,
        search_box,
        action_center,
        quick_access,
        marketing_msg,
        message_center_link,
        dep_accounts,
        profile_btn
    }
    public class HomePage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;
        

        public HomePage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }


        public static By welcomeMsg = By.CssSelector("div > div> div > h6");
        public static By dateToday = By.XPath("//*[@id='root']/div/div/div[3]/div[1]/div/span");
        public static By actionCenter = By.XPath("//div/span[contains(text(),'Action Center')]");
        public static By actionCenterShowMore = By.XPath("//div/p[contains(text(),'Show More')]");
        public static By quickAccess = By.XPath("//div/span[contains(text(),'Quick Access')]");
        public static By qaDepositCheck = By.XPath("//div/span[contains(text(),'Deposit Check')]");
        public static By qaOpenAccount = By.XPath("//div/span[contains(text(),'Open Account')]");
        public static By qaMakePayments = By.XPath("//div/span[contains(text(),'Make Payments')]");
        public static By qaTransferFunds = By.XPath("//div/span[contains(text(),'Transfer Funds')]");
        public static By qaApplyLoan = By.XPath("//div/span[contains(text(),'Apply For a Loan')]");
        public static By qaDocCenter = By.XPath("//div/span[contains(text(),'Document Center')]");
        public static By profileButton = By.XPath("//header/div/div/div[5]/div/button");
        public static By myProfileButton = By.XPath("//header/div/div/div[5]/div/div/div/ul/li[1]/p");
        public static By messageCenterLink = By.XPath("//div/a/span[contains(text(),'Messages')]");
        public static By logoutButton = By.XPath("//header/div/div/div[5]/div/div/div/ul/li[2]/p");
        public static By homeLink = By.XPath("//header//a[1]//h6/div");
        public static By myAccountLink = By.XPath("//header//a[2]//h6/div");
        public static By manageMoneyLink = By.XPath("//header//a[3]//h6/div");
        public static By loansLink = By.XPath("//header//a[4]//h6/div");
        public static By searchBox = By.Name("searchText");
        public static By searchButton = By.XPath("//form/div/div/div/button");
        public static By marketingImage = By.XPath("//div/div[2]/div[2]//img");
        public static By bocLogoImage = By.XPath("//header//img");
        public static By depAccountsShowMore = By.XPath("//div/button/span[contains(text(),'Show More')]");
        public static By depAccountsShowLess = By.XPath("//div/button/span[contains(text(), 'Show Less')]");
        public static By depAccountsGridTitle = By.XPath("//div/span[contains(text(),'Deposit Accounts')]");
        public static By loanAccountsGridTitle = By.XPath("//div/span[contains(text(),'Loans')]");
        public static By depAccountsListBalance = By.XPath("//div/ul/li/div[2]/p");
        public static By depAccountsAssetLabel = By.XPath("//div/p[contains(text(),'Assets')]");
        public static By depAccountsAssetValue = By.XPath("//div/h5");
        public static By depAccountFirst = By.XPath("//div/ul/li[1]//span");
        public static By depAccountSecond = By.XPath("//div/ul/li[2]//span");
        public static By depAccountThird = By.XPath("//div/ul/li[3]//span");
        public static By loansTitle = By.XPath("//div/span[contains(text(),'Loans')]");


        public void gotoProfile()
        {

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                commonMethod.clickElement(driver, profileButton);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to open uer profile - " + e.StackTrace);
                throw;
            }
        }

        public void logoutUser()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                commonMethod.clickElement(driver, logoutButton);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to logout user - " + e.StackTrace);
                throw;
            }
        }

        public void checkHomePageElement(HomePageElements opt, String msg="")
        {
            switch(opt)
            {
                case HomePageElements.welcome_msg:
                    validation.validateText(driver, welcomeMsg, msg);
                    break;
                case HomePageElements.logout_btn:
                    validation.validateElementExists(driver, logoutButton);
                    break;
                case HomePageElements.search_box:
                    validation.validateElementExists(driver, searchBox);
                    break;
                case HomePageElements.boc_logo:
                    validation.validateElementExists(driver, bocLogoImage);
                    break;
                case HomePageElements.message_center_link:
                    validation.validateElementExists(driver, messageCenterLink);
                    break;
                case HomePageElements.tab_accounts:
                    validation.validateText(driver, myAccountLink,"My Accounts");
                    break;
                case HomePageElements.tab_home:
                    validation.validateText(driver, homeLink, "Home");
                    break;
                case HomePageElements.tab_manageMoney:
                    validation.validateText(driver, manageMoneyLink, "Manage Money");
                    break;
                case HomePageElements.tab_loans:
                    validation.validateText(driver, loansLink, "Loans");
                    break;
                case HomePageElements.profile_btn:
                    validation.validateTitle(driver, profileButton, msg);
                    break;
                case HomePageElements.date_today:
                    validation.validateText(driver, dateToday, msg);
                    break;
                case HomePageElements.action_center:
                    validation.validateElementExists(driver, actionCenter);
                    break;
                case HomePageElements.quick_access:
                    validation.validateElementExists(driver, quickAccess);
                    validation.validateElementExists(driver, qaDepositCheck);
                    validation.validateElementExists(driver, qaMakePayments);
                    validation.validateElementExists(driver, qaTransferFunds);
                    validation.validateElementExists(driver, qaOpenAccount);
                    validation.validateElementExists(driver, qaApplyLoan);
                    validation.validateElementExists(driver, qaDocCenter);
                    break;
                case HomePageElements.marketing_msg:
                    validation.validateElementExists(driver, marketingImage);
                    break;
                case HomePageElements.dep_accounts:
                    validation.validateElementExists(driver, depAccountsGridTitle);
                    validation.validateElementExists(driver, depAccountsAssetLabel);
                    validation.validateElementExists(driver, depAccountFirst);
                    validation.validateElementExists(driver, depAccountSecond);
                    validation.validateElementExists(driver, depAccountThird);
                    validation.validateElementExists(driver, depAccountsShowMore);
                    break;
                default :
                    Console.WriteLine(" Wrong option in method checkHomePageElement");
                    break;

            }
            
        }


    }
}
