using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Specflow_SuperTest.StepDefinitions
{
    [Binding]
    public class RiskPageSteps
    {

        private RiskPage RiskPage = new RiskPage();


        //        public RiskPageSteps()
        //        {
        //            RiskPage = new RiskPage(hooksDriver);
        //        }


        //        [BeforeScenario]
        //        public void SetupPageObjects() { 
        //         RiskPageVariable = new RiskPage(_driver);
        //        }

        [Given(@"I am on the price page")]
        public void GivenIAmOnThePricePage()
        {
        RiskPage.SelectCoverType();
        }


        //follow the proper page object model
        //intro page factory
        //into to browser factory
        //paralell

        //homework
        // read about hooks files

    }
}
