using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Specflow_SuperTest.StepDefinitions;
using TechTalk.SpecFlow;

namespace Specflow_SuperTest
{
    [Binding]
    public class Hooks
    {
        public BrowserSetup BrowserSetup;
        public IWebDriver Driver;

        public Hooks()
        {
            BrowserSetup = new BrowserSetup();
            Driver = BrowserSetup.Driver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            
            
            Driver.Url = "http://life.qa.internal.comparethemarket.com/LifeInsurance/Home/YourDetails?Affclie=TSTT";
        }

        [AfterScenario]
        public void AfterScenario()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success);
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                Driver.Quit();
            }
        }
    }
}

//Initialise the class into the Hooks file,
//    declare a Webdriver(globally in Hooks)
//    and then reference the new class WebDriver to it;
//do this part in the 'BeforeScenario' attribute.
