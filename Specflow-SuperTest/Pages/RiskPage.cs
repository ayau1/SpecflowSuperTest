using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Specflow_SuperTest.Support;

namespace Specflow_SuperTest.Pages
{//page object class
    public class RiskPage:GeneralMethods
        
    {
        private IWebDriver Driver;
        private Actions Actions;

        #region Locators
        [FindsBy(How = How.Id, Using = "proposerTitle")]
        public IWebElement ProposerTitle;

        [FindsBy(How = How.Id, Using = "proposerFirstname")]
        public IWebElement ProposerFirstName;
        #endregion

        public RiskPage()
        {
            Driver = BrowserSetup.Driver;
            PageFactory.InitElements(Driver, this);
            Actions = new Actions(Driver);
        }
        /// <summary>
        /// this completes a valid single risk 
        /// </summary>
        public void CompleteSingleRisk(string smoker="no",string coverTerm="25",string coverAmount="250000",string emailAddress="test@test.com",
            string houseNumber="1",string postcode="PE26XJ",string contactPreferences= "deselect all")
        {
            SelectProposerTitle();
            EnterProposerFirstName();
            EnterProposerLastName();
            EnterDateOfBirth();
            SelectSmoker(smoker);
            EnterCoverTerm(coverTerm);
            EnterCoverAmount(coverAmount);
            EnterEmailAddress(emailAddress);
            EnterHouseNumber(houseNumber);
            EnterPostcode(postcode);
            SelectContactPreferences(contactPreferences);
            AgreeTermsAndConditions();
            SubmitRisk();

        }

        private void SubmitRisk()
        {
            var submit = Driver.FindElements(By.CssSelector("button[test-id='submitRisk'")).Last();
            //ScrollElementInToView(submit);
            submit.Click();
        }

        private void ScrollElementInToView(IWebElement submit)
        {
            Actions.MoveToElement(submit);
            Actions.Perform();
        }

        private void AgreeTermsAndConditions()
        {
            Driver.FindElement(By.Id("agreeTermsLabel")).Click();
        }

        private void SelectContactPreferences(string contactPreferences)
        {   //I need to refactor this to check if a preference is selected first 
            if (contactPreferences == "deselect all")
            {
                //Driver.FindElement(By.Id("contactByEmail")).Click();
                Driver.FindElement(By.ClassName("email")).Click();
                Driver.FindElement(By.ClassName("post")).Click();
            }
            else
            {
                Driver.FindElement(By.ClassName("telephone")).Click();
                Driver.FindElement(By.ClassName("sms")).Click();
            }
        }

        private void EnterPostcode(string postcode)
        {
            Driver.FindElement(By.Id("postcode")).SendKeys(postcode);
        }

        private void EnterHouseNumber(string houseNumber)
        {
            Driver.FindElement(By.Id("houseNumber")).SendKeys(houseNumber);
        }

        private void EnterEmailAddress(string emailAddress)
        {
            Driver.FindElement(By.Id("email")).SendKeys(emailAddress);
        }

        private void EnterCoverAmount(string coverAmount)
        {
            Driver.FindElement(By.Id("amount")).SendKeys(coverAmount);
        }

        private void EnterCoverTerm(string coverTerm)
        {
            Driver.FindElement(By.Id("yearsTextBox")).SendKeys(coverTerm);
        }

        private void SelectSmoker(string smoker)
        {
            if (smoker == "no")
            {
                    Driver.FindElement(By.Id("proposerNonSmokerLabel")).Click();
            }
            else
            {
                    Driver.FindElement(By.Id("proposerSmokerLabel")).Click();
            }

           
        }

        public void SelectCoverType()
        {
            Driver.FindElement(By.Id("jointPolicyLabel")).Click();
        }

        public void SelectProposerTitle()
        {   
            ProposerTitle.Click();
            SelectElement selectElement = new SelectElement(ProposerTitle);
            selectElement.SelectByValue("MISS");
        }

        public void EnterProposerFirstName()
        {
            ProposerFirstName.SendKeys("PropFirstName");
        }

        public void EnterProposerLastName()
        {
            Driver.FindElement(By.Id("proposerSurname")).SendKeys("PropLastName");
        }

        public void EnterDateOfBirth()
        {
            IWebElement dateOfBirthDay = Driver.FindElement(By.Id("proposerDateOfBirthDay"));
            IWebElement dateOfBirthMonth = Driver.FindElement(By.Id("proposerDateOfBirthMonth"));
            IWebElement dateOfBirthYear = Driver.FindElement(By.Id("proposerDateOfBirthYear"));

            SelectElement day = new SelectElement(dateOfBirthDay);
            dateOfBirthDay.Click();
            day.SelectByValue("string:01");
            dateOfBirthMonth.Click();
            SelectElement month = new SelectElement(dateOfBirthMonth);
            month.SelectByValue("string:02");
            dateOfBirthYear.Click();
            SelectElement year = new SelectElement(dateOfBirthYear);
            year.SelectByValue("number:1979");
        }


    }
}
