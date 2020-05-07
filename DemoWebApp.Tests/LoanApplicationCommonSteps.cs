using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DemoWebApp.Tests
{
    [Binding]
    public class LoanApplicationCommonSteps
    {
        private readonly WebDriverContext _context;
        private IWebDriver _driver;
        private LoanApplicationPage _loanApplicationPage;

        public LoanApplicationCommonSteps(WebDriverContext context)
        {
            _context = context;
        }

        [Given(@"I am on the loan application screen")]
        public void GivenIAmOnTheLoanApplicationScreen()
        {
            _driver = new FirefoxDriver();
            _context.Driver = _driver;
            _context.Driver.Manage().Window.Maximize();
            //_driver.Navigate().GoToUrl("http://localhost:40077/Home/StartLoanApplication");
            _loanApplicationPage = LoanApplicationPage.NavigateTo(_context.Driver);          
            _context.LoanApplicationPage = _loanApplicationPage;
        }

        [Given(@"I enter a first name of (.*)")]
        [Scope(Tag = "one")]
        public void GivenIEnterAFirstNameOf(string firstName)
        {
            // _driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            _context.LoanApplicationPage.FirstName = firstName;
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            //_driver.Dispose();
            _context.Driver.Dispose();
        }
    }
}
