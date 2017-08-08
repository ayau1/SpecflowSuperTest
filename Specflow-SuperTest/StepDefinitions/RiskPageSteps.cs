using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Specflow_SuperTest.Pages;
using TechTalk.SpecFlow;

namespace Specflow_SuperTest.StepDefinitions
{
    [Binding]
    public class RiskPageSteps
    {
        public RiskPage RiskPage;

        public RiskPageSteps()
        {
            RiskPage = new RiskPage();
        }

        [Given(@"I am on the price page")]
        public void GivenIAmOnThePricePage()
        {
            RiskPage.CompleteSingleRisk();
        }


        //follow the proper page object model
        //intro page factory
        //into to browser factory
        //paralell

        //homework
        // read about hooks files

    }
}
