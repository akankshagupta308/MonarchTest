using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace MonarchTest.PageObjects
{
    public class UploadIDPage
    {
        IWebDriver driver;
        CommonMethods commonMethod = new CommonMethods();
        Validations validation = new Validations();
        ExtentTest _test;

        public UploadIDPage(IWebDriver driver, ExtentTest _test)
        {
            this.driver = driver;
            this._test = _test;
        }

        public static By bocLogo = By.XPath("//header//img");
        public static By heading = By.XPath("//h4");
        public static By subHeading = By.XPath("//div/div[1]/span");
        public static By idTypeInput = By.XPath("//form/div[1]/div[2]/div");
        public static By idTypeLabel = By.XPath("//div/div[2]/label");
        public static By idNumInput = By.XPath("//form/div[1]/div[3]/div/input");
        public static By idTypeInput1 = By.XPath("//li[contains(text(),'State Issued ID')]");
        public static By idTypeInput2 = By.XPath("//li[contains(text(),'Passport')]");
        public static By idTypeInput3 = By.XPath("//li[contains(text(),'Drivers License')]");
        public static By idNumLabel = By.XPath("//form/div[1]/div[3]/label");
        public static By idNumShowHideButton = By.XPath("//form/div[1]/div[3]//button");
        public static By fileFormatInfoMsg = By.XPath("//form/div[2]/div[2]/div/span");
        public static By backButton = By.XPath("//form/div[6]/div/div[1]/button/span");
        public static By nextButton = By.XPath("//form/div[6]/div/div[2]/button/span");
        public static By uploadFrontBox = By.XPath("//form/div[2]/div/div[1]/div[2]");
        public static By uploadFrontBoxInput = By.XPath("//form/div[2]/div/div[1]/div[2]/input");
        public static By uploadBackBox = By.XPath("//form/div[2]/div/div[2]/div[2]");
        public static By uploadBackBoxInput = By.XPath("//form/div[2]/div/div[2]/div[2]/input");
        public static By uploadFrontBoxLabel = By.XPath("//form/div[2]/div/div[1]/div[1]/span");
        public static By uploadBackBoxLabel = By.XPath("//form/div[2]/div/div[2]/div[1]/span");
        public static By uploadPicBox = By.XPath("//form/div[4]/div/div/div[1]");
        public static By uploadPicBoxInput = By.XPath("//form/div[4]/div/div/div[1]/input");
        public static By uploadPicInfoMsg1 = By.XPath("//form/div[3]//p");
        public static By uploadPicInfoMsg2 = By.XPath("//ul/li[1]//span");
        public static By uploadPicInfoMsg3 = By.XPath("//ul/li[2]//span");
        public static By uploadPicInfoMsg4 = By.XPath("//ul/li[3]//span");
        public static By sidepaneItem1 = By.XPath("//ul/li[1]/div/p");
        public static By sidepaneItem2 = By.XPath("//ul/li[2]/div/p");
        public static By sidepaneItem3 = By.XPath("//ul/li[3]/div/p");
        public static By sidepaneItem4 = By.XPath("//ul/li[4]/div/p");
        public static String currentUrl = "https://qa.mybocbank.com/new-customer-onboarding";
        public static By idTypeError = By.XPath("//form/div[1]/div[2]/p");
        public static By idNumError = By.XPath("//form/div[1]/div[3]/p");
        public static By uploadFrontError = By.XPath("//form/div[2]/div/div[1]/div[4]/span");
        public static By uploadBackError = By.XPath("//form/div[2]/div/div[2]/div[4]/span");
        public static By uploadPicError = By.XPath("//form/div[4]/div/div/div[3]/span");
        public static By uploadFrontChangeLink = By.XPath("//form/div[2]/div/div[1]//p");
        public static By uploadBackChangeLink = By.XPath("//form/div[2]/div/div[2]//p");
        public static By uploadPicChangeLink = By.XPath("//form/div[4]/div/div/div[2]/p");




        public void checkUploadIDPage()
        {
            try
            {
                Thread.Sleep(5000);
                validation.validatePageTitle(driver, "BOC Bank Home Loans and Accounts");
                validation.validateCurrentUrl(driver, currentUrl);
                validation.validateElementExists(driver, bocLogo);
                validation.validateText(driver, heading, "Upload ID and selfie");
                validation.validateText(driver, subHeading, "Select a type of ID from the dropdown below and upload corresponding files");
                validation.validateElementExists(driver, idTypeInput);
                validation.validateElementExists(driver, idNumInput);
                validation.validateElementExists(driver, idNumShowHideButton);
                validation.validateElementExists(driver, uploadFrontBox);
                validation.validateElementExists(driver, uploadBackBox);
                validation.validateElementExists(driver, uploadPicBox);
                validation.validateText(driver, fileFormatInfoMsg, "We support .png and .jpg file formats. Files may not exceed 10 MB.");
                validation.validateText(driver, uploadPicInfoMsg1,"You are legally required to have a picture of yourself attached to your bank account");
                validation.validateText(driver, uploadPicInfoMsg2, "The photo must be taken in well lit surrounding");
                validation.validateText(driver, uploadPicInfoMsg3, "Your eyes must be open in the photo and all facial features must be clearly visible");
                validation.validateText(driver, uploadPicInfoMsg4, "Formats accepted are .jpg and .png only and size is restricted to 10 MB");
                validation.validateText(driver, backButton, "Back");
                validation.validateText(driver, nextButton, "Next");
                validation.validateText(driver, sidepaneItem1, "Address Info");
                validation.validateText(driver, sidepaneItem2, "Personal Details");
                validation.validateText(driver, sidepaneItem3, "Uploads");
                validation.validateText(driver, sidepaneItem4, "Review Info");
                
            }
            catch(Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Upload ID Page elements" + e.StackTrace);
                throw;
            }
        }



        public void checkChangeUploadLinks()
        {
            try
            {
                Thread.Sleep(5000);
                validation.validateText(driver, uploadFrontChangeLink, "Change");
                validation.validateText(driver, uploadBackChangeLink, "Change");
                validation.validateText(driver, uploadPicChangeLink, "Change");

            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while verifying Chnage upload links on Upload ID Page " + e.StackTrace);
                throw;
            }
        }

        public void checkIDNumMasked(bool masked = true)
        {
            try
            {
                validation.validateElementMasked(driver, idNumInput, masked);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying ID Number masked/unmasked on Upload ID Page" + e.StackTrace);
                throw;
            }
        }

        public void toggleIDNumView()
        {
            try
            {
                commonMethod.clickElement(driver, idNumShowHideButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in toggle ID Number visibility on Upload ID page " + e.StackTrace);
                throw;
            }
        }

        public void inputIDDetails(String idNumVal, int opt=3)
        {
            try
            {
                commonMethod.clickElement(driver, idTypeInput);
                Thread.Sleep(3000);
                if (opt == 1)
                    commonMethod.clickElement(driver, idTypeInput1);
                else if (opt == 2)
                    commonMethod.clickElement(driver, idTypeInput2);
                else
                    commonMethod.clickElement(driver, idTypeInput3);
                commonMethod.enterKeys(driver, idNumInput, idNumVal);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while entering data on Upload ID page " + e.StackTrace);
                throw;
            }
        }


        public void submitIDDetails()
        {
            try
            {
                commonMethod.clickElement(driver, nextButton);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception while submitting new customer ID details on Upload ID page " + e.StackTrace);
                throw;
            }
        }

        
        public void checkBlankInputError()
        {
            try
            {
                validation.validateText(driver, idTypeError, "ID type is required");
                validation.validateText(driver, idNumError, "ID Number is required");
                validation.validateText(driver, uploadFrontError, "Required");
                validation.validateText(driver, uploadBackError, "Required");
                validation.validateText(driver, uploadPicError, "Required");
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in verifying required fields error on Upload ID Page" + e.StackTrace);
                throw;
            }
        }

        public void uploadFile(String filePath, int opt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            try
            {
                switch (opt)
                {
                    case 1:
                        js.ExecuteScript("document.getElementById('idFrontUrls').style.display = 'block';");
                        commonMethod.enterKeys(driver, uploadFrontBoxInput, filePath);
                        js.ExecuteScript("document.getElementById('idFrontUrls').style.display = 'none';");
                        Thread.Sleep(6000);
                        break;
                    case 2:
                        js.ExecuteScript("document.getElementById('idBackUrls').style.display = 'block';");
                        commonMethod.enterKeys(driver, uploadBackBoxInput, filePath);
                        js.ExecuteScript("document.getElementById('idBackUrls').style.display = 'none';");
                        Thread.Sleep(6000);
                        break;
                    case 3:
                        js.ExecuteScript("document.getElementById('selfieUrls').style.display = 'block';");
                        commonMethod.enterKeys(driver, uploadPicBoxInput, filePath);
                        js.ExecuteScript("document.getElementById('selfieUrls').style.display = 'none';");
                        Thread.Sleep(6000);
                        break;
                    default:
                        _test.Log(Status.Error, "Wrong option in UploadIDPage.uploadFile method ");
                        break;

                }
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in uploading file on Upload ID Page" + e.StackTrace);
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
