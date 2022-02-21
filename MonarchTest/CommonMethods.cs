using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MonarchTest
{
    public class CommonMethods
    {
        public void clickElement(IWebDriver driver, By element)
        {
            driver.FindElement(element).Click();
        }

        public void openURLNewTab(IWebDriver driver, string url)
        {
            Console.WriteLine("Trying to open new tab");
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + 'T');
            driver.Navigate().GoToUrl(url);
        }

        public bool checkElementDisplayed(IWebDriver driver, By element)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                return(driver.FindElement(element).Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in locating the element !!! - " + e.StackTrace);
                throw;
            }

        }

        public String getElementValue(IWebDriver driver, By element)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                return (driver.FindElement(element).GetAttribute("value"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in getting value of the input field !!! - " + e.StackTrace);
                throw;
            }

        }

        public void enterKeys(IWebDriver driver, By element, string keys)
        {
            try
            {
                driver.FindElement(element).Clear();
                driver.FindElement(element).SendKeys(keys);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in entering data in input field !!! - " + e.StackTrace);
                throw;
            }
        }

        public void selectListItem(IWebDriver driver, By element,  string value)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(element));
            selectElement.SelectByText(value);            
        }

        public void setElementDisplay(IWebDriver driver, By element, int opt)
        {
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (opt==1)
                js.ExecuteScript("driver.FindElement(element).style.display = 'block';");
            else
                js.ExecuteScript("driver.FindElement(element).style.display = 'none';");
        }

        public string getElementText(IWebDriver driver, By element)
        {
            return driver.FindElement(element).Text;
        }
    }
}
