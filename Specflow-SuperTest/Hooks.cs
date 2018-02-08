using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Specflow_SuperTest.StepDefinitions;
using Specflow_SuperTest.Support;
using TechTalk.SpecFlow;

namespace Specflow_SuperTest
{
    [Binding]
    public class Hooks
    {
        public BrowserSetup BrowserSetup;
        public IWebDriver Driver;
        public Urls Urls;
        public GeneralMethods GeneralMethods;

        public Hooks()
        {
            BrowserSetup = new BrowserSetup();
            Driver = BrowserSetup.Driver;
            Urls = new Urls();
            GeneralMethods = new GeneralMethods();
        }
        //can add these anywhere in your test solution
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("signin")||FeatureContext.Current.FeatureInfo.Tags.Contains("signin"))
            {
                Driver.Url = Urls.baseUrl + "?affclie=TSTT";
            }
            else
            {
                Driver.Url = Urls.baseUrl + "home/yourdetails?affclie=TSTT";
            }
           GeneralMethods.WaitForElementToBeVisible(By.Id("proposerTitle"));
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
