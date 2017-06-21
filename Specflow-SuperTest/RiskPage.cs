using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Specflow_SuperTest.StepDefinitions;
using TechTalk.SpecFlow;

namespace Specflow_SuperTest
{//page object class
    public class RiskPage
    {
 

//        public void NavigateToRiskPage()
//        {
//            _driver.Url = "http://life.qa.internal.comparethemarket.com/lifeinsurance";
//        }

        public void SelectCoverType()
        {
            IWebElement coverType = Hooks._driver.FindElement(By.Id("jointPolicyLabel"));
            coverType.Click();
        }

        public void SelectProposerTitle()
        {   
            IWebElement proposerTitle = Hooks._driver.FindElement(By.Id("proposerTitle"));
            proposerTitle.Click();
            SelectElement selectElement = new SelectElement(proposerTitle);
            selectElement.SelectByValue("MISS");
        }

        public void EnterProposerFirstName()
        {
            IWebElement proposerFirstName = Hooks._driver.FindElement(By.Id("proposerFirstname"));
            proposerFirstName.SendKeys("PropFirstName");
        }

        public void EnterProposerLastName()
        {
            IWebElement proposerLastName = Hooks._driver.FindElement(By.Id("proposerSurname"));
            proposerLastName.SendKeys("PropLastName");
        }

        public void EnterDateOfBirth()
        {
            IWebElement dateOfBirthDay = Hooks._driver.FindElement(By.Id("proposerDateOfBirthDay"));
            IWebElement dateOfBirthMonth = Hooks._driver.FindElement(By.Id("proposerDateOfBirthMonth"));
            IWebElement dateOfBirthYear = Hooks._driver.FindElement(By.Id("proposerDateOfBirthYear"));

            dateOfBirthDay.Click();
            SelectElement day = new SelectElement(dateOfBirthDay);
            day.SelectByValue("1");
            dateOfBirthMonth.Click();
            SelectElement month = new SelectElement(dateOfBirthMonth);
            month.SelectByValue("2");
            dateOfBirthYear.Click();
            SelectElement year = new SelectElement(dateOfBirthYear);
            year.SelectByValue("1979");
        }

        public void CloseBrowser()
        {
            Hooks._driver.Quit();
        }

    }
}
