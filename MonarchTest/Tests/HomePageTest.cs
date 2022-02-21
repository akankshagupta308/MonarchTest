using AventStack.ExtentReports;
using MonarchTest.PageObjects;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Threading;


namespace MonarchTest.Tests
{
    [TestFixture]
    public class HomePageTest : BaseTest
    {
        public static string useremail = config.validEmail;
        public static string userpwd = config.validPwd;

        [OneTimeSetUp]
        public void openTest()
        {
            //Login with test account to BOC banking to open customer dashboard.
            
            try
            {
                //var prereqPage = new PrerequisitesPage(driver, _test);
                //prereqPage.gotoLoginPage();
                
                var loginPage = new LoginPage(driver, _test);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                loginPage.loginuser(useremail, userpwd);
                Thread.Sleep(2000);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception in initiating Home Page tests" + e.StackTrace);
                throw (e);
            } 
        }

        [SetUp]
        public void startTest()
        {
            //Print log at time of starting a testcase
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
                _test.Log(Status.Info, "Stating test Case : " + TestContext.CurrentContext.Test.Name);

            }
            catch(Exception e)
            {
                Console.WriteLine("Exception while creating test context for report" + e.StackTrace);
                throw (e);
            }

            
        }

        [Test]
        public void verifyBocLogo()
        {
            var homepage = new HomePage(driver, _test);
            Thread.Sleep(2000);
            _test.Log(Status.Info, "Verify BOC logo on Home page");
            homepage.checkHomePageElement(HomePageElements.boc_logo);
            Assert.Pass();
        }
        
        [Test]
        public void verifyHeaderTabs()
        {
            var homepage = new HomePage(driver, _test);
            Thread.Sleep(7000);
            _test.Log(Status.Info, "Verify Home tab on Home page");
            homepage.checkHomePageElement(HomePageElements.tab_home,"Home");
            _test.Log(Status.Info, "Verify Accounts tab on Home page");
            homepage.checkHomePageElement(HomePageElements.tab_accounts);
            _test.Log(Status.Info, "Verify Manage Money tab on Home page");
            homepage.checkHomePageElement(HomePageElements.tab_manageMoney);
            _test.Log(Status.Info, "Verify Loans tab on Home page");
            homepage.checkHomePageElement(HomePageElements.tab_loans);
            Assert.Pass();
        }

        
        [Test]
        public void verifySearchBox()
        {
            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify Search box present in Home page");
            homepage.checkHomePageElement(HomePageElements.search_box);
            Assert.Pass();
        }
        
        [Test]
        public void verifyMessageCenter()
        {
            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify Message Center link present in Home page");
            homepage.checkHomePageElement(HomePageElements.message_center_link);
            Assert.Pass();
        }

        
        [Test]
        public void verifyProfileOption()
        {
            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify Profile menu button present in Home page");
            homepage.checkHomePageElement(HomePageElements.profile_btn, "Access your BOC profile");
            Assert.Pass();
        }

        
        [Test]
        public void verifyWelcomeMsg()
        {
            DateTime thisDay = DateTime.Today;
            string currentDate = thisDay.DayOfWeek.ToString() + " " + thisDay.ToString("MMMM") + " " + thisDay.Day.ToString() + ", " + thisDay.Year.ToString();

            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify Welcome message on Home page");
            homepage.checkHomePageElement(HomePageElements.welcome_msg, "Welcome Back, Mark Harris");
            homepage.checkHomePageElement(HomePageElements.date_today,  currentDate.ToUpper());
            Assert.Pass();
        }

        
        [Test]
        public void verifyActionCenter()
        {
            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify Action Center present in Home page");
            homepage.checkHomePageElement(HomePageElements.action_center);
            Assert.Pass();
        }

        [Test]
        public void verifyQuickAccess()
        {
            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify required Action buttons present in Quick Access bar on Home page");
            homepage.checkHomePageElement(HomePageElements.quick_access);
            Assert.Pass();
        }

        [Test]
        public void verifyMarketingMsg()
        {
            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify Marketing image on Home page");
            homepage.checkHomePageElement(HomePageElements.marketing_msg);
            Assert.Pass();
        }

        [Test]
        public void verifyDepositAccountsGrid()
        {
            var homepage = new HomePage(driver, _test);
            _test.Log(Status.Info, "Verify Deposit Accounts Grid on Home page");
            homepage.checkHomePageElement(HomePageElements.dep_accounts);
            Assert.Pass();
        }

        /*
        [Test]
        public void verifyAccountsInfo()
        {

        }

        /*
        [Test]
        public void verifyLoansInfo()
        {

        }
        */

        [TearDown]
        public void endTest()
        {
            //Print log at time of ending a testcase
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
                        _test.Log(Status.Info, "Exception stacktrace  " + stacktrace);
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

        [OneTimeTearDown]
        public void closeTest()
        {
            //Go to base URL
            try
            {
                gotoBaseURL(basePage.home);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            catch (Exception e)
            {
                _test.Log(Status.Error, "Exception in teardown Home Page tests");
                throw (e);
            }
        }
    }
}
