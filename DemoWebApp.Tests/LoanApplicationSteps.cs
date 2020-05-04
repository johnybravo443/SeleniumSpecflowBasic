using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using Xunit;

namespace DemoWebApp.Tests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private IWebDriver _driver;
        private LoanApplicationPage _loanApplicationPage;
        private ApplicationConfirmationPage _confirmationPage;

        [Given(@"I am on the loan application screen")]
        public void GivenIAmOnTheLoanApplicationScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            //_driver.Navigate().GoToUrl("http://localhost:40077/Home/StartLoanApplication");
            _loanApplicationPage = LoanApplicationPage.NavigateTo(_driver);
        }

        [Given(@"I enter a first name of (.*)")]
        public void GivenIEnterAFirstNameOf(string firstName)
        {
            // _driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            _loanApplicationPage.FirstName = firstName;
        }
        
        [Given(@"I enter a second name of (.*)")]
        public void GivenIEnterASecondNameOf(string lastName)
        {
            //_driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            _loanApplicationPage.LastName = lastName;
        }
        
        [Given(@"I select that I have an existing loan account")]
        public void GivenISelectThatIHaveAnExistingLoanAccount()
        {
            //_driver.FindElement(By.Id("Loan")).Click();
            _loanApplicationPage.SelectExistingLoan();
        }
        
        [Given(@"I confirm my acceptance of the terms and conditions")]
        public void GivenIConfirmMyAcceptanceOfTheTermsAndConditions()
        {
            //_driver.FindElement(By.Name("TermsAcceptance")).Click();
            _loanApplicationPage.AcceptTermsAndConditions();
        }
        
        [When(@"I sbumit the application")]
        public void WhenISbumitTheApplication()
        {
            //_driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            _confirmationPage = _loanApplicationPage.SubmitApplication();
        }
        
        [Then(@"I should see the application complete confirmation for Sarah")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationForSarah()
        {
            //IWebElement confirmationSpan = _driver.FindElement(By.Id("firstName"));
            Assert.Equal("Sarah", _confirmationPage.FirstName);
        }

        [Then(@"I should see an error message telling me I must accept the terms and conditions")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustAcceptTheTermsAndConditions()
        {
            //IWebElement errorElement = _driver.FindElement(By.CssSelector(".validation-summary-errors ul li"));

            Assert.Equal("You must accept the terms and conditions",_loanApplicationPage.ErrorText);
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
