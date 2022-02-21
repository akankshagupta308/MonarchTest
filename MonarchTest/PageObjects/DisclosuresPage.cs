using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public class DisclosuresPage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;

        public DisclosuresPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By bocLogo = By.XPath("//header//img");
        public static By heading1 = By.XPath("//form/div[1]/div/h5");
        public static By heading2 = By.XPath("//form/div[2]/div/h5");
        public static By heading3 = By.XPath("//form/div[3]/div/h5");
        public static By heading4 = By.XPath("//form/div[4]/div/h5");
        public static By disclosure1CheckBox = By.XPath("//form/div[1]/div[3]//input");
        public static By disclosure1Text = By.XPath("//form/div[1]/div[3]/p");
        public static By disclosure2CheckBox = By.XPath("//form/div[1]/div[4]//input");
        public static By disclosure2Text = By.XPath("//form/div[1]/div[4]/p");
        public static By disclosure3CheckBox = By.XPath("//form/div[2]/div[3]//input");
        public static By disclosure3Text = By.XPath("//form/div[2]/div[3]/p");
        public static By disclosure3Link = By.XPath("//form/div[2]/div[3]/p/a");
        public static By disclosure4CheckBox = By.XPath("//form/div[3]/div[3]//input");
        public static By disclosure4Text = By.XPath("//form/div[3]/div[3]/p");
        public static By disclosure4Link = By.XPath("//form/div[3]/div[3]/p/a");
        public static By disclosure5CheckBox = By.XPath("//form/div[4]/div[3]//input");
        public static By disclosure5Text = By.XPath("//form/div[4]/div[3]/p");
        public static By disclosure5Link = By.XPath("//form/div[4]/div[3]/p/a");
        public static By disclosure6CheckBox = By.XPath("//form/div[4]/div[4]//input");
        public static By disclosure6Text = By.XPath("//form/div[4]/div[4]/p");
        public static By disclosure6Link = By.XPath("//form/div[4]/div[4]/p/a");
        public static By disclosure7CheckBox = By.XPath("//form/div[4]/div[5]//input");
        public static By disclosure7Text = By.XPath("//form/div[4]/div[5]/p");
        public static By disclosure7Link = By.XPath("//form/div[4]/div[5]/p/a");
        public static By disclosure8CheckBox = By.XPath("//form/div[4]/div[6]//input");
        public static By disclosure8Text = By.XPath("//form/div[4]/div[6]/p");
        public static By disclosure8Link = By.XPath("//form/div[4]/div[6]/p/a");
        public static By disclosureSection2Desc = By.XPath("//form/div[2]/div[2]/p");
        public static By disclosureSection3Desc = By.XPath("//form/div[3]/div[2]/p");
        public static By disclosureSection4Desc = By.XPath("//form/div[4]/div[2]/p");
        public static By backButton = By.XPath("//form/div[5]/div[1]/button/span");
        public static By submitButton = By.XPath("//form/div[5]/div[2]/button/span");
        public static String currentUrl = "mybocbank.com/disclosure-agreement";
        

        public void checkDisclosuresPage()
        {
            try
            {
                Thread.Sleep(5000);
                validation.validatePageTitle(driver, "BOC Bank Home Loans and Accounts");
                validation.validateCurrentUrl(driver, currentUrl);
                validation.validateElementExists(driver, bocLogo);
                //validation.validateElementExists(driver, disclosure1CheckBox);
                validation.validateElementExists(driver, disclosure1Text);
                validation.validateElementExists(driver, disclosure2CheckBox);
                validation.validateElementExists(driver, disclosure2Text);
                validation.validateElementExists(driver, disclosure3CheckBox);
                validation.validateElementExists(driver, disclosure3Text);
                validation.validateElementExists(driver, disclosure4CheckBox);
                validation.validateElementExists(driver, disclosure4Text);
                validation.validateElementExists(driver, disclosure5CheckBox);
                validation.validateElementExists(driver, disclosure5Text);
                validation.validateElementExists(driver, disclosure6CheckBox);
                validation.validateElementExists(driver, disclosure6Text);
                validation.validateElementExists(driver, disclosure7CheckBox);
                validation.validateElementExists(driver, disclosure7Text);
                validation.validateElementExists(driver, disclosure8CheckBox);
                validation.validateElementExists(driver, disclosure8Text);
                validation.validateElementExists(driver, disclosureSection2Desc);
                validation.validateElementExists(driver, disclosureSection3Desc);
                validation.validateElementExists(driver, disclosureSection4Desc);
                validation.validateText(driver, backButton,"Back");
                validation.validateText(driver, submitButton, "Submit");
                validation.validateText(driver, heading1, "Certificates and Backup Withholding");
                validation.validateText(driver, heading2, "Ownership Rights");
                validation.validateText(driver, heading3, "Electronic Signature");
                validation.validateText(driver, heading4, "Account Agreements and Disclosures");
                validation.validateText(driver, disclosure3Link, "Ownership Rights Disclosure");
                validation.validateText(driver, disclosure4Link, "eSign Disclosure and Agreement");
                validation.validateText(driver, disclosure5Link, "Deposit Account Agreement");
                validation.validateText(driver, disclosure6Link, "Debit Card Agreement");
                validation.validateText(driver, disclosure7Link, "Privacy Policy");
                validation.validateText(driver, disclosure8Link, "Pay a Friend Agreement");

                

            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Upload ID Page elements" + e.StackTrace);
                throw;
            }
        }



        public void selectDisclosure(int opt=0)
        {
            try
            {
                switch(opt)
                {
                    case 1:
                        commonMethod.clickElement(driver, disclosure1CheckBox);
                        break;
                    case 2:
                        commonMethod.clickElement(driver, disclosure2CheckBox);
                        break;
                    case 3:
                        commonMethod.clickElement(driver, disclosure3CheckBox);
                        break;
                    case 4:
                        commonMethod.clickElement(driver, disclosure4CheckBox);
                        break;
                    case 5:
                        commonMethod.clickElement(driver, disclosure5CheckBox);
                        break;
                    case 6:
                        commonMethod.clickElement(driver, disclosure6CheckBox);
                        break;
                    case 7:
                        commonMethod.clickElement(driver, disclosure7CheckBox);
                        break;
                    case 8:
                        commonMethod.clickElement(driver, disclosure8CheckBox);
                        break;
                    default:
                        commonMethod.clickElement(driver, disclosure1CheckBox);
                        commonMethod.clickElement(driver, disclosure2CheckBox);
                        commonMethod.clickElement(driver, disclosure3CheckBox);
                        commonMethod.clickElement(driver, disclosure4CheckBox);
                        commonMethod.clickElement(driver, disclosure5CheckBox);
                        commonMethod.clickElement(driver, disclosure6CheckBox);
                        commonMethod.clickElement(driver, disclosure7CheckBox);
                        commonMethod.clickElement(driver, disclosure8CheckBox);
                        break;
                }

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while selecting disclosure on Disclosures Page " + e.StackTrace);
                throw;
            }
        }

        public void checkDisclosuresUncheckedByDefault()
        {
            try
            {
                
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying ID Number masked/unmasked on Upload ID Page" + e.StackTrace);
                throw;
            }
        }
        public void submitDisclosures()
        {
            try
            {
                commonMethod.clickElement(driver, submitButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while submitting new customer creation request on Disclosures page " + e.StackTrace);
                throw;
            }
        }

        
        public void checkBlankInputError()
        {
            try
            {
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying required fields error on Upload ID Page" + e.StackTrace);
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
