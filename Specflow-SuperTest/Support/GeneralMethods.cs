using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        { //this is a global override
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(element));

        }

        public void WaitForElementToBeVisible(By element, TimeSpan timeSpan)
        {
            WebDriverWait wait = new WebDriverWait(Driver, timeSpan);
            wait.Until(ExpectedConditions.ElementIsVisible(element));

        }
    }
}
