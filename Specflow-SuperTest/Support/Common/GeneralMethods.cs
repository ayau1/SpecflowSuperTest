using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Specflow_SuperTest.Support.Common;

namespace Specflow_SuperTest.Support
{
    public class GeneralMethods
    {
        private IWebDriver Driver;

        public GeneralMethods()
        {
            Driver = BrowserSetup.Driver;
        }

        public void WaitForElementToBeVisible(By element)
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeoutTime.Timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(element));

        }

        public void WaitForElementToBeClickable(By element)
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeoutTime.Timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
