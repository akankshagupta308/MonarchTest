using NUnit.Framework;
using System;
using MonarchTest.PageObjects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using System.Threading;
using System.IO;

namespace MonarchTest.Tests
{
    [TestFixture]
    public class CustomerInitialSetupTest : BaseTest
    {
        public static string env = config.Env;
        public string fName = "Jim";
        public string lName = "Doe";
        public string validEmailAdd = "jim.doe@mailsac.com";
        public string invalidEmailAdd1 = "jack.doe";
        public string invalidEmailAdd2 = "1234";
        public string validMobileNum = "8123999999";
        public string validPwd1 = "BOCpass@12345678";
        public string validPwd2 = "BOCpass@123456789";
        public string invalidPwd1 = "BOC1234";
        public string validAddPrefix = "3301";
        public string validMailingAddPrefix = "5511";
        public string validSSN = "111000123";
        public string invalidSSN = "111000123456";
        public string validDOB = "01/01/1990";
        public string validIDFrontImage = "dl-1.png";
        public string validIDBackImage = "dl-2.png";
        public string validIDSelfieImage = "pic1.png";
        public string validIDType = "Drivers License";
        public string validIDNum = "A-111000123";
        public string validPhysicalAdd = "3301 West Woodlawn Avenue";

        [OneTimeSetUp]
        public void startTest()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in creating test context for report" + e.StackTrace);
                throw (e);
            }
            
        }

        [SetUp]
        public void beginTest()
        {

            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name).Info(" Test Started ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in creating test context for report" + e.StackTrace);
                throw (e);
            }
            try
            {
                _test.Log(Status.Info, "Open Prerequisistes page for new customer (Personal)");
                var mktgPage = new MktgPage(driver, _test);
                mktgPage.createNewUserAC(env, 1);
                Thread.Sleep(5000);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in navigating to Prerequisites page" + e.StackTrace);
                throw (e);
            }

        }


        [Test]

        public void verifyNavtoNewCustomerSetup()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Check Prerequisites Page Elements");
            prereqPage.checkPrerequistesPage();
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check Let's Get Started page elements");
            var custSetupPage = new CustSetupPage(driver, _test);
            custSetupPage.checkCustSetupPage();
            Assert.Pass();

        }
        

        [Test]
        public void verifyCustomerSetupInvalidInputError()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Go to next step without entering mandatory customer details");
            custSetupPage.submitCustDetails();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check error for mandatory fields");
            custSetupPage.checkBlankInputErrors();
            _test.Log(Status.Info, "Submit customer details with invalid email address (less than 14 chars)");
            custSetupPage.inputCustDetails(fName, lName, invalidEmailAdd1, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            _test.Log(Status.Info, "Check error for invalid email");
            custSetupPage.checkInvalidEmailError();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Submit customer details with invalid email address (all digits)");
            custSetupPage.inputCustDetails(fName, lName, invalidEmailAdd2, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            _test.Log(Status.Info, "Check error for invalid email");
            custSetupPage.checkInvalidEmailError();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Submit customer details with invalid password");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, invalidPwd1, invalidPwd1);
            custSetupPage.submitCustDetails();
            _test.Log(Status.Info, "Check error for invalid password");
            custSetupPage.checkInvalidPwdError(1);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Submit customer details with mismatch password");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd2);
            custSetupPage.submitCustDetails();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check error for mismatch password");
            custSetupPage.checkInvalidPwdError(2);
            Assert.Pass();
        }
        

        [Test]
        public void verifyShowHidePwd()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit customer details with password");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.checkPwdMasked(1,true);
            custSetupPage.checkPwdMasked(2, true);
            custSetupPage.togglePasswordView(1);
            custSetupPage.togglePasswordView(2);
            custSetupPage.checkPwdMasked(1, false);
            custSetupPage.checkPwdMasked(2, false);
            Assert.Pass();
        }


        [Test]

        public void verifySubmitValidCustDetails()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            
            _test.Log(Status.Info, "Check user navigated to Address Info page");
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            //_test.Log(Status.Info, "Check Address Info page fields when physical address same as mailing address");
            //custAddressInfoPage.checkCustAddressInfoPage();
            //_test.Log(Status.Info, "Click No radio button for mailing address same as physical address");
            //custAddressInfoPage.selectMailingAddressDifferent();
            //_test.Log(Status.Info, "Check Mailing address fields visible when physical address not same as mailing address");
            //custAddressInfoPage.checkCustAddressInfoPage(true);
            _test.Log(Status.Info, "Enter customer address (auto-complete)");
            Thread.Sleep(8000);
            custAddressInfoPage.selectAddress(validAddPrefix);
            //_test.Log(Status.Info, "Enter customer mailing address (auto-complete)");
            //custAddressInfoPage.selectAddress(validMailingAddPrefix, 2);
            Thread.Sleep(8000);
            _test.Log(Status.Info, "Submit customer address details");
            custAddressInfoPage.submitCustAddressDetails();
            Thread.Sleep(3000);
            _test.Log(Status.Info, "Check user navigated to Personal Info page");
            var personalInfoPage = new PersonalInfoPage(driver, _test);
            //_test.Log(Status.Info, "Check Personal Info page fields");
            //personalInfoPage.checkPersonalInfoPage();
            personalInfoPage.inputPIIDetails(validSSN, validDOB);
            Thread.Sleep(2000);
            personalInfoPage.submitPIIDetails();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check user navigated to Upload ID page");
            var uploadIDPage = new UploadIDPage(driver, _test);
            _test.Log(Status.Info, "Check Upload ID page fields");
            uploadIDPage.checkUploadIDPage();
            var basepath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string parentDirPath = basepath.Parent.Parent.Parent.FullName;
            string img1Path = parentDirPath + "\\"+ "Data" + "\\" + validIDFrontImage;
            string img2Path = parentDirPath + "\\" + "Data" + "\\" + validIDBackImage;
            string img3Path = parentDirPath + "\\" + "Data" + "\\" + validIDSelfieImage;
            _test.Log(Status.Info, "Enter ID Type and ID No.");
            uploadIDPage.inputIDDetails(validIDNum);
            //Thread.Sleep(2000);
            _test.Log(Status.Info, "Upload ID front image");
            uploadIDPage.uploadFile(img1Path, 1);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Upload ID back image");
            uploadIDPage.uploadFile(img2Path, 2);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Upload Selfie image");
            uploadIDPage.uploadFile(img3Path, 3);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check change image links become visible on Upload page");
            uploadIDPage.checkChangeUploadLinks();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Submit customer ID uploads and proceed to review");
            uploadIDPage.submitIDDetails();
            var reviewInfoPage = new ReviewInfoPage(driver, _test);
            _test.Log(Status.Info, "Check Review info page fields");
            Thread.Sleep(4000);
            reviewInfoPage.checkReviewInfoPage();
            //reviewInfoPage.unmaskAllValues();
            //reviewInfoPage.checkData(fName + " " + lName, validEmailAdd, validMobileNum,  )
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Submit verified customer details and proceed to diclosures page");
            reviewInfoPage.submitVerifiedDetails();
            var disclosuresPage = new DisclosuresPage(driver, _test);
            _test.Log(Status.Info, "Check Disclosures page fields");
            Thread.Sleep(6000);
            disclosuresPage.checkDisclosuresPage();
            Assert.Pass();
        }


        [Test]
        public void verifyCustomerAddressInfoPageErrors()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Check user navigated to Address Info page");
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Click No radio button for mailing address same as physical address");
            custAddressInfoPage.selectMailingAddressDifferent();
            Thread.Sleep(2000);
            custAddressInfoPage.submitCustAddressDetails();
            _test.Log(Status.Info, "Check error for mandatory fields");
            custAddressInfoPage.checkBlankInputErrors();

            Thread.Sleep(5000);
            _test.Log(Status.Info, "Submit customer details with invalid zip code (non-numeric)");
            custAddressInfoPage.enterZipCode("abcd", 1);
            custAddressInfoPage.enterZipCode("pqrs", 2);
            _test.Log(Status.Info, "Check error for invalid zip code");
            custAddressInfoPage.checkZipCodeError(1);

            Thread.Sleep(5000);
            _test.Log(Status.Info, "Submit customer details with invalid zip code (more than 9 digits)");
            custAddressInfoPage.enterZipCode("888888888888", 1);
            custAddressInfoPage.enterZipCode("999999999999", 2);
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Check error for invalid zip code");
            custAddressInfoPage.checkZipCodeError(2);

            Assert.Pass();
        }

        [Test]
        public void verifyCustAddressAutoComplete()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check user navigated to Address Info page");
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Enter customer address (auto-complete)");
            custAddressInfoPage.selectAddress("1234");
            Thread.Sleep(8000);
            Assert.IsTrue(custAddressInfoPage.checkAddressFieldsUpdated());

        }



        [Test]
        public void verifyCustomerPersonalInfoPageErrors()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            Thread.Sleep(5000);
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            _test.Log(Status.Info, "Enter customer address (auto-complete)");
            custAddressInfoPage.selectAddress(validAddPrefix);
            Thread.Sleep(8000);
            _test.Log(Status.Info, "Submit customer address details");
            custAddressInfoPage.submitCustAddressDetails();
            Thread.Sleep(5000);
            var personalInfoPage = new PersonalInfoPage(driver, _test);
            _test.Log(Status.Info, "Go to next page without entering mandatory input fields");
            personalInfoPage.submitPIIDetails();
            Thread.Sleep(2000);
            personalInfoPage.checkInvalidSSNError();
            _test.Log(Status.Info, "Submit personal details with invalid SSN");
            personalInfoPage.inputPIIDetails(invalidSSN);
            personalInfoPage.submitPIIDetails();
            Thread.Sleep(2000);
            personalInfoPage.checkInvalidSSNError();
            Assert.Pass();
        }


        [Test]
        public void verifyShowHideSSN()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check user navigated to Address Info page");
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            _test.Log(Status.Info, "Check Address Info page fields when physical address same as mailing address");
            custAddressInfoPage.checkCustAddressInfoPage();
            _test.Log(Status.Info, "Enter customer address (auto-complete)");
            custAddressInfoPage.selectAddress(validAddPrefix);
            Thread.Sleep(8000);
            _test.Log(Status.Info, "Submit customer address details");
            custAddressInfoPage.submitCustAddressDetails();
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check user navigated to Personal Info page");
            var personalInfoPage = new PersonalInfoPage(driver, _test);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Submit personal details with valid SSN");
            personalInfoPage.inputPIIDetails(validSSN);
            _test.Log(Status.Info, "Check SSN field is masked");
            personalInfoPage.checkPwdMasked(true);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Toggle Show/Hide AAN button");
            personalInfoPage.toggleSSNView();
            _test.Log(Status.Info, "Check SSN field is unmasked");
            personalInfoPage.checkPwdMasked(false);
            Assert.Pass();
        }


        [Test]
        public void verifyUploadIDPageBlankInputError()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            Thread.Sleep(5000);
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            _test.Log(Status.Info, "Enter customer address (auto-complete)");
            custAddressInfoPage.selectAddress(validAddPrefix);
            Thread.Sleep(8000);
            _test.Log(Status.Info, "Submit customer address details");
            custAddressInfoPage.submitCustAddressDetails();
            Thread.Sleep(5000);
            var personalInfoPage = new PersonalInfoPage(driver, _test);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Submit personal details");
            personalInfoPage.inputPIIDetails(validSSN, validDOB);
            personalInfoPage.submitPIIDetails();
            Thread.Sleep(8000);
            var uploadIDPage = new UploadIDPage(driver, _test);
            _test.Log(Status.Info, "Go to next step without entering mandatory input");
            uploadIDPage.submitIDDetails();
            uploadIDPage.checkBlankInputError();
            Assert.Pass();
        }



        [Test]
        public void verifyDefaultDOBValue()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            Thread.Sleep(5000);
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            _test.Log(Status.Info, "Enter customer address (auto-complete) on Address Info page");
            custAddressInfoPage.selectAddress(validAddPrefix);
            Thread.Sleep(8000);
            _test.Log(Status.Info, "Submit customer address details");
            custAddressInfoPage.submitCustAddressDetails();
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Check user navigated to Personal Info page");
            var personalInfoPage = new PersonalInfoPage(driver, _test);
            //Thread.Sleep(2000);
            Assert.IsTrue(personalInfoPage.checkDefaultDOB());
        }


        [Test]

        public void verifyShowHideIdNumber()
        {
            var prereqPage = new PrerequisitesPage(driver, _test);
            _test.Log(Status.Info, "Proceed to New Customer Setup Flow");
            prereqPage.gotoNewCustomerSetup();
            Thread.Sleep(2000);
            var custSetupPage = new CustSetupPage(driver, _test);
            _test.Log(Status.Info, "Submit valid customer details");
            custSetupPage.inputCustDetails(fName, lName, validEmailAdd, validMobileNum, validPwd1, validPwd1);
            custSetupPage.submitCustDetails();
            Thread.Sleep(8000);
            _test.Log(Status.Info, "Check user navigated to Address Info page");
            var custAddressInfoPage = new CustAddressInfoPage(driver, _test);
            _test.Log(Status.Info, "Enter customer address (auto-complete)");
            custAddressInfoPage.selectAddress(validAddPrefix);
            Thread.Sleep(8000);
            _test.Log(Status.Info, "Submit customer address details");
            custAddressInfoPage.submitCustAddressDetails();
            Thread.Sleep(3000);
            _test.Log(Status.Info, "Check user navigated to Personal Info page");
            var personalInfoPage = new PersonalInfoPage(driver, _test);
            personalInfoPage.inputPIIDetails(validSSN, validDOB);
            Thread.Sleep(2000);
            personalInfoPage.submitPIIDetails();
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Check user navigated to Upload ID page");
            var uploadIDPage = new UploadIDPage(driver, _test);
            uploadIDPage.inputIDDetails(validIDNum);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Check ID number masked by default on Upload ID page");
            uploadIDPage.checkIDNumMasked(true);
            uploadIDPage.toggleIDNumView();
            Thread.Sleep(5000);
            _test.Log(Status.Info, "Check ID number unmasked on Upload ID page");
            uploadIDPage.checkIDNumMasked(false);
            Assert.Pass();
        }

        [TearDown]
        public void endTest()
        {
            
            try
            {
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in returning to first browser tab" + e.StackTrace);
                throw (e);
            }
            
            try
            {

                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = " " + TestContext.CurrentContext.Result.StackTrace + " ";
                var errorMsg = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        _test.Log(logstatus, "Test ended with status " + logstatus);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with status " + logstatus);
                        break;
                    case TestStatus.Passed:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with status " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in reporting test status" + e.StackTrace);
                throw (e);
            }
        }







    }
}