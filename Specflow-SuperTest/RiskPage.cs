using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Specflow_SuperTest.StepDefinitions;
using TechTalk.SpecFlow;

namespace Specflow_SuperTest
{//page object class
    public class RiskPage:BrowserSetup
    {    

        public void SelectCoverType()
        {
            IWebElement coverType = Driver.FindElement(By.Id("jointPolicyLabel"));
            coverType.Click();
            Thread.Sleep(5000);
        }

        public void SelectProposerTitle()
        {   
            IWebElement proposerTitle = Driver.FindElement(By.Id("proposerTitle"));
            proposerTitle.Click();
            SelectElement selectElement = new SelectElement(proposerTitle);
            selectElement.SelectByValue("MISS");
        }

        public void EnterProposerFirstName()
        {
            IWebElement proposerFirstName = Driver.FindElement(By.Id("proposerFirstname"));
            proposerFirstName.SendKeys("PropFirstName");
        }

        public void EnterProposerLastName()
        {
            IWebElement proposerLastName = Driver.FindElement(By.Id("proposerSurname"));
            proposerLastName.SendKeys("PropLastName");
        }

        public void EnterDateOfBirth()
        {
            IWebElement dateOfBirthDay = Driver.FindElement(By.Id("proposerDateOfBirthDay"));
            IWebElement dateOfBirthMonth = Driver.FindElement(By.Id("proposerDateOfBirthMonth"));
            IWebElement dateOfBirthYear = Driver.FindElement(By.Id("proposerDateOfBirthYear"));

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

//        public void CloseBrowser()
//        {
//            Driver.Quit();
//        }

    }
}
