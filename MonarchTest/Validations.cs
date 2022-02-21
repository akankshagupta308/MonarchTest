using NUnit.Framework;
using System;
using OpenQA.Selenium;
using System.Threading;



namespace MonarchTest
{
    [TestFixture]
    public class Validations
    {
        public void validatePageTitle(IWebDriver driver, String titleText)
        {
            try
            {
                Assert.AreEqual(driver.Title, titleText);
            }
            catch(Exception e)
            {
                Console.WriteLine("Validation Failed !!! - " + e.StackTrace);
                throw;
            }
            
        }

        public void validateText(IWebDriver driver, By element, String elemText)
        {
            try
            {
                //Console.WriteLine("Element text is: " + driver.FindElement(element).Text);
                Assert.AreEqual(driver.FindElement(element).Text, elemText);
            }
            catch (Exception e)
            {
                Console.WriteLine("Validation Failed !!! - " + e.StackTrace);
                throw;
            }
            
        }

        public void validateTitle(IWebDriver driver, By element, String elemTitle)
        { 
            try
            {
                Assert.AreEqual(driver.FindElement(element).GetAttribute("title"), elemTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine("Validation Failed !!! Element title doesn't match expected value " + e.StackTrace);
                throw;
            }

        }


        public void validateCurrentUrl(IWebDriver driver, String pageUrl)
        {
            try
            {
                String url = driver.Url;
                Assert.IsTrue(url.Contains(pageUrl));
            }
            catch (Exception e)
            {
                Console.WriteLine("Validation Failed !!! Page URL doesn't match expected value " + e.StackTrace);
                throw;
            }

        }

        public void validateElementExists(IWebDriver driver, By element)
        {
            try
            {
                Thread.Sleep(5000);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                
                Assert.IsTrue(driver.FindElement(element)!= null);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Validation Failed !!! - " + e.StackTrace);
                throw; 
            }
            
        }



        public void validateElementMasked(IWebDriver driver, By element, bool masked=true)
        {
            try
            {
                if (masked)
                    Assert.IsTrue(driver.FindElement(element).GetAttribute("type") == "password");
                else
                    Assert.IsTrue(driver.FindElement(element).GetAttribute("type") == "text");

            }
            catch (Exception e)
            {
                Console.WriteLine("Validation Failed !!! - " + e.StackTrace);
                throw;
            }

        }
        public void validateElementEnabled(IWebDriver driver, By element, bool status=true)
        {
            try
            {
                Assert.Equals(driver.FindElement(element).Enabled, status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Validation Failed !!! - " + e.StackTrace);
                throw;
            }

        }
        public void validateElementSelected(IWebDriver driver, By element, bool status = true)
        {
            try
            {
                Assert.Equals(driver.FindElement(element).Selected, status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Validation Failed !!! - " + e.StackTrace);
                throw;
            }

        }


        public void validatePageUrl(IWebDriver driver, String url)
        {
            
            try
            {
                Assert.AreEqual(driver.Url, url);
            }
            catch (Exception e) 
            {
                Console.WriteLine("Validation Failed !!! - " + e.StackTrace);
                throw;
            }
        }

    }
}
