using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoWebApp.Tests
{
    public class LoanApplicationPage
    {
        private readonly IWebDriver _driver;

        private static readonly string PageUrl = @"http://localhost:40077/Home/StartLoanApplication";

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement _firstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement _secondName;

        [FindsBy(How = How.Id, Using = "Loan")]
        private IWebElement _existingLoan;

        [FindsBy(How = How.Name, Using = "TermsAcceptance")]
        private IWebElement _termsAcceptance;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        private IWebElement _submit;

        [FindsBy(How = How.CssSelector, Using = ".validation-summary-errors ul li")]
        private IWebElement _errorText;

        public LoanApplicationPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static LoanApplicationPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUrl);
            return new LoanApplicationPage(driver);
        }

        public string FirstName 
        {
            set
            {
                _firstName.SendKeys(value);
            }
        }

        public string LastName
        {
            set
            {
                _secondName.SendKeys(value);
            }
        }

        public string ErrorText => _errorText.Text;

        public void SelectExistingLoan()
        {
            _existingLoan.Click();
        }

        public void AcceptTermsAndConditions()
        {
            _termsAcceptance.Click();
        }

        public ApplicationConfirmationPage SubmitApplication()
        {
            _submit.Click();

            return new ApplicationConfirmationPage(_driver);
        }
    }
}
