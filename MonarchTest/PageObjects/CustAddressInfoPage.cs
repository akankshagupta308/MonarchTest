using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public class CustAddressInfoPage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;

        public CustAddressInfoPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By bocLogo = By.XPath("//header//img");
        public static By mainHeading = By.XPath("//div/div/h4");
        public static By stepHeading = By.CssSelector("div>h6");
        public static By addressLine1Input = By.Name("AddressLine1");
        public static By addressLine2Input = By.Name("AddressLine2");
        public static By cityInput = By.Name("City");
        public static By countyInput = By.Name("County");
        public static By stateInput = By.Name("State");
        public static By zipInput = By.Name("ZipCode");
        public static By countryInput = By.Name("Country");
        public static By addressLine1Item1 = By.XPath("//ul/div[1]/div/span");
        public static By addressLine1Label = By.XPath("//form/div/div/div[1]/label");
        public static By addressLine2Label = By.XPath("//form/div/div/div[2]/label");
        public static By cityLabel = By.XPath("//form/div/div/div[3]/label");
        public static By countyLabel = By.XPath("//form/div/div/div[4]/div/div/label");
        public static By stateLabel = By.XPath("//form/div/div/div[4]/div/label");
        public static By zipLabel = By.XPath("//form/div/div/div[5]/div/div/label");
        public static By countryLabel = By.XPath("//form/div/div/div[5]/div/label");
        public static By addressLine1Error = By.XPath("//form/div/div/div[1]/p");
        public static By cityError = By.XPath("//form/div/div/div[3]/p");
        public static By stateError = By.XPath("//form/div/div/div[4]/div/p");
        public static By zipError = By.XPath("//form/div/div/div[5]/div/div/p");
        public static By countryError = By.XPath("//form/div/div/div[5]/div/p");
        public static By mailingAddCheckMsg = By.CssSelector("fieldset>label");
        public static By mailingAddCheckYes = By.XPath("//fieldset//div/label[1]/span[1]");
        public static By mailingAddCheckYesLabel = By.XPath("//fieldset//div/label[1]/span[2]");
        public static By mailingAddCheckNo = By.XPath("//fieldset//div/label[2]/span[1]");
        public static By mailingAddCheckNoLabel = By.XPath("//fieldset//div/label[2]/span[2]");
        public static By impInfo = By.CssSelector("fieldset>p");
        public static By nextButton = By.XPath("//div/div[2]/button");
        public static By backButton = By.XPath("//div/div[1]/button");
        public static By mailingAddressLine1Input = By.Name("mailingAddressLine1");
        public static By mailingAddressLine2Input = By.Name("mailingAddressLine2");
        public static By mailingCityInput = By.Name("mailingCity");
        public static By mailingCountyInput = By.Name("mailingCounty");
        public static By mailingStateInput = By.Name("mailingState");
        public static By mailingZipInput = By.Name("mailingZipCode");
        public static By mailingCountryInput = By.Name("mailingCountry");
        public static By mailingAddressLine1Item1 = By.XPath("//ul/div[1]/div[2]/span");
        public static By mailingAddressLine1Label = By.XPath("//fieldset/div[2]/div/div[1]/label");
        public static By mailingAddressLine2Label = By.XPath("//fieldset/div[2]/div/div[2]/label");
        public static By mailingCityLabel = By.XPath("//fieldset/div[2]/div/div[3]/label");
        public static By mailingCountyLabel = By.XPath("//fieldset/div[2]/div/div[4]/div[1]//label");
        public static By mailingStateLabel = By.XPath("//fieldset/div[2]/div/div[4]/div[2]//label");
        public static By mailingZipLabel = By.XPath("//fieldset/div[2]/div/div[5]/div[1]//label");
        public static By mailingCountryLabel = By.XPath("//fieldset/div[2]/div/div[5]/div[2]//label");
        public static By mailingAddressLine1Error = By.XPath("//fieldset/div[2]/div/div[1]/p");
        public static By mailingCityError = By.XPath("//fieldset/div[2]/div/div[3]/p");
        public static By mailingStateError = By.XPath("//fieldset/div[2]/div/div[4]/div[2]//p");
        public static By mailingZipError = By.XPath("//fieldset/div[2]/div/div[5]/div[1]//p");
        public static By mailingCountryError = By.XPath("//fieldset/div[2]/div/div[5]/div[2]//p");
        public static By sidepaneItem1 = By.XPath("//ul/li[1]/div/p");
        public static By sidepaneItem2 = By.XPath("//ul/li[2]/div/p");
        public static By sidepaneItem3 = By.XPath("//ul/li[3]/div/p");
        public static By sidepaneItem4 = By.XPath("//ul/li[4]/div/p");

        public void checkCustAddressInfoPage(bool mailingAddressDifferent = false)
        {
            try
            {
                //Thread.Sleep(2000);
                validation.validateElementExists(driver, bocLogo);
                validation.validatePageTitle(driver, "BOC Bank Home Loans and Accounts");
                validation.validateCurrentUrl(driver, "https://qa.mybocbank.com/new-customer-onboarding");
                validation.validateText(driver, mainHeading, "Let’s Get Your Address");
                validation.validateElementExists(driver, addressLine1Input);
                validation.validateText(driver, addressLine1Label, "Physical Address (No P.O. boxes)");
                validation.validateElementExists(driver, addressLine2Input);
                validation.validateText(driver, addressLine2Label, "Apartment unit, etc (optional)");
                validation.validateElementExists(driver, cityInput);
                validation.validateText(driver, cityLabel, "City");
                validation.validateElementExists(driver, countyInput);
                validation.validateText(driver, countyLabel, "County");
                validation.validateElementExists(driver, stateInput);
                validation.validateText(driver, stateLabel, "State");
                validation.validateElementExists(driver, zipInput);
                validation.validateText(driver, zipLabel, "Zip");
                validation.validateElementExists(driver, countryInput);
                validation.validateText(driver, countryLabel, "Country");
                validation.validateText(driver, mailingAddCheckMsg, "Is your Physical Address same as your mailing address?");
                validation.validateElementExists(driver, mailingAddCheckYes);
                validation.validateText(driver, mailingAddCheckYesLabel, "Yes");
                validation.validateElementExists(driver, mailingAddCheckNo);
                validation.validateText(driver, mailingAddCheckNoLabel, "No");
                validation.validateElementExists(driver, impInfo);
                validation.validateElementExists(driver, nextButton);
                validation.validateElementExists(driver, backButton);
                validation.validateText(driver, sidepaneItem1, "Address Info");
                validation.validateText(driver, sidepaneItem2, "Personal Details");
                validation.validateText(driver, sidepaneItem3, "Uploads");
                validation.validateText(driver, sidepaneItem4, "Review Info");

                if (mailingAddressDifferent)
                {
                    validation.validateElementExists(driver, mailingAddressLine1Input);
                    validation.validateText(driver, mailingAddressLine1Label, "Mailing Address (No P.O. boxes)");
                    validation.validateElementExists(driver, mailingAddressLine2Input);
                    validation.validateText(driver, mailingAddressLine2Label, "Apartment unit, etc (optional)");
                    validation.validateElementExists(driver, mailingCityInput);
                    validation.validateText(driver, mailingCityLabel, "City");
                    validation.validateElementExists(driver, mailingCountyInput);
                    validation.validateText(driver, mailingCountyLabel, "County");
                    validation.validateElementExists(driver, mailingStateInput);
                    validation.validateText(driver, mailingStateLabel, "State");
                    validation.validateElementExists(driver, mailingZipInput);
                    validation.validateText(driver, mailingZipLabel, "Zip");
                    validation.validateElementExists(driver, mailingCountryInput);
                    validation.validateText(driver, mailingCountryLabel, "Country");
                }


            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Let's Get Your Address Page elements" + e.StackTrace);
                throw;
            }
        }

        public void checkBlankInputErrors()
        {
            try
            {
                validation.validateText(driver, addressLine1Error, "Required");
                validation.validateText(driver, cityError, "Required");
                validation.validateText(driver, stateError, "Required");
                validation.validateText(driver, zipError, "Required");
                validation.validateText(driver, countryError, "Required");
                validation.validateText(driver, mailingAddressLine1Error, "Required");
                validation.validateText(driver, mailingCityError, "Required");
                validation.validateText(driver, mailingStateError, "Required");
                validation.validateText(driver, mailingZipError, "Required");
                validation.validateText(driver, mailingCountryError, "Required");

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying mandatory fields error on AddressInfo page" + e.StackTrace);
                throw;
            }
        }


        public void gotoPreviousPage()
        {
            try
            {
                commonMethod.clickElement(driver, backButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while going to previous page " + e.StackTrace);
                throw;
            }
        }


        public void submitCustAddressDetails()
        {
            try
            {
                commonMethod.clickElement(driver, nextButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while submitting new customer address details on Address Info page " + e.StackTrace);
                throw;
            }
        }

        public void selectAddress(String addVal, int opt=1)
        {
            try
            {
                if (opt==1)
                {
                    commonMethod.enterKeys(driver, addressLine1Input, addVal);
                    Thread.Sleep(5000);
                    if (commonMethod.checkElementDisplayed(driver, addressLine1Item1))
                        commonMethod.clickElement(driver, addressLine1Item1);
                }
                else
                {
                    commonMethod.enterKeys(driver, mailingAddressLine1Input, addVal);
                    Thread.Sleep(5000);
                    if (commonMethod.checkElementDisplayed(driver, mailingAddressLine1Item1))
                        commonMethod.clickElement(driver, mailingAddressLine1Item1);
                }
                
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while entering address" + e.StackTrace);
                throw;
            }
        }

        public void enterZipCode(String zipVal, int opt = 1)
        {
            try
            {
                if (opt == 1)
                    commonMethod.enterKeys(driver, zipInput, zipVal);
                else
                    commonMethod.enterKeys(driver, mailingZipInput, zipVal);

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while entering zip code" + e.StackTrace);
                throw;
            }
        }

        public void checkZipCodeError(int opt=1)
        {
            try
            {
                if (opt==1)
                {
                    validation.validateText(driver, zipError, "Must contain only numbers");
                    validation.validateText(driver, mailingZipError, "Must contain only numbers");
                }
                else
                {
                    validation.validateText(driver, zipError, "Must be less than 9 characters");
                    validation.validateText(driver, mailingZipError, "Must be less than 9 characters");
                }

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying mandatory fields error on AddressInfo page" + e.StackTrace);
                throw;
            }
        }

        public void selectMailingAddressDifferent(bool mailingAddressDifferent=true)
        {
            try
            {
                commonMethod.clickElement(driver, mailingAddCheckNo);

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while selecting mailing address different radio button" + e.StackTrace);
                throw;
            }
        }

        public bool checkAddressFieldsUpdated()
        {
            try
            {
                String addLine1Val = commonMethod.getElementValue(driver, addressLine1Input);
                String addLine2Val = commonMethod.getElementValue(driver, addressLine2Input);
                String cityVal = commonMethod.getElementValue(driver, cityInput);
                String countyVal = commonMethod.getElementValue(driver, countyInput);
                String stateVal = commonMethod.getElementValue(driver, stateInput);
                String zipVal = commonMethod.getElementValue(driver, zipInput);
                String countryVal = commonMethod.getElementValue(driver, countryInput);
                if (addLine1Val=="" || cityVal=="" || countyVal=="" || stateVal == "" || zipVal == "" || countryVal == "")
                {
                    _test.Log(Status.Info, "Address fields not auto-populated");
                    return false;
                }
                else
                {
                    _test.Log(Status.Info, "Address fields auto-populated");
                    return true;
                }
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while checking auto-fill of address info fields..." + e.StackTrace);
                throw;
            }
        }



    }
}
