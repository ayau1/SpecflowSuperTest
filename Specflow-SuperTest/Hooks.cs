using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Specflow_SuperTest.StepDefinitions;
using TechTalk.SpecFlow;

namespace Specflow_SuperTest
{
    [Binding]
    public static class Hooks
    {
        public static IWebDriver _driver = new ChromeDriver();

        [BeforeScenario]
        public static void BeforeScenario()
        {
            
            _driver.Url = "http://life.qa.internal.comparethemarket.com/lifeinsurance";
        }

        [AfterScenario]
        public static void AfterScenario()
        {
           _driver.Close();
        }
    }
}
