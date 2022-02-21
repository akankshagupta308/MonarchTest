using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using MonarchTest.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;


namespace MonarchTest.Tests
{
    public enum basePage
    {
        marketing_page,
        home,
        prereq_personal_page,
        prereq_business_page
    }
    
    public class BaseTest
    {
        public static IWebDriver driver;
        
        public static Validations validation = new Validations();
        public static ExtentReports _extent = new ExtentReports();
        public static ExtentHtmlReporter _extentHtmlReporter;
        public static ExtentTest _test;
        public static String baseUrl;

        //static Random r = new Random();
        //static int genRand = r.Next(1000, 9999);

        static string sourceFile = @"C:\Users\akanksha\source\repos\MonarchTest\MonarchTest\Reports\index.html";
        static string destinationFile = @"C:\Users\akanksha\source\repos\MonarchTest\MonarchTest\Reports\TestReport_" + DateTime.Now.ToString("yyyyMMddHH") + ".html";

        public static ConfigSettings config;
        static string configPath = System.IO.Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Configuration/configuration.json";






        [OneTimeSetUp]
        public void SetupTest()
        {
            config = new ConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            //Console.WriteLine("BaseUrl = " + config.MktgUrl);
            baseUrl = config.MktgUrl;
            try
            {
                _extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\akanksha\source\repos\MonarchTest\MonarchTest\Reports\testReport.html");
                _extent.AttachReporter(_extentHtmlReporter);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to initialize test report" + e.StackTrace);
                throw (e);
            }

            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(baseUrl);

            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to initialize web driver" + e.StackTrace);
                throw (e);
            }
        }
        
        [OneTimeTearDown]
        public void TearDownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in quit driver instance" + e.StackTrace);
                throw (e);
            }
            try
            {
                Console.WriteLine("Copy test report");
                _extent.Flush();
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while flush extent report" + e.StackTrace);
                throw (e);
            }
        
        }

        public void gotoBaseURL(basePage pg)
        {
            switch(pg)
            {
                case basePage.marketing_page:
                    baseUrl = config.MktgUrl;
                    break;
                case basePage.home:
                    baseUrl = config.BaseUrl;
                    break;
                case basePage.prereq_personal_page:
                    baseUrl = config.PrereqPersonalUrl;
                    break;
                case basePage.prereq_business_page:
                    baseUrl = config.PrereqBusinessUrl;
                    break;
                default:
                    Console.WriteLine(" Wrong option in method gotoBaseUrl");
                    break;
            }
            try
            {
                driver.Navigate().GoToUrl(baseUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to go to baseurl" + e.StackTrace);
                throw (e);
            }


        }

    }
}
