using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;
using System;
using System.Collections.Generic;

namespace DemoWebApp.Tests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private readonly WebDriverContext _context;
        //private IWebDriver _driver;
        //private LoanApplicationPage _context.LoanApplicationPage;
        private ApplicationConfirmationPage _confirmationPage;
        private List<MagicalItem> magicalItems;

        public SpecFlowFeature1Steps(WebDriverContext context)
        {
            _context = context;
        }

        //[Given(@"I am on the loan application screen")]
        //public void GivenIAmOnTheLoanApplicationScreen()
        //{
        //    _driver = new FirefoxDriver();
        //    _driver.Manage().Window.Maximize();
        //    //_driver.Navigate().GoToUrl("http://localhost:40077/Home/StartLoanApplication");
        //    _context.LoanApplicationPage = LoanApplicationPage.NavigateTo(_driver);
        //}

        [Given(@"I enter a first name of (.*)")]
        public void GivenIEnterAFirstNameOf(string firstName)
        {
            // _driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            _context.LoanApplicationPage.FirstName = firstName;
        }
        
        [Given(@"I enter a second name of (.*)")]
        public void GivenIEnterASecondNameOf(string lastName)
        {
            //_driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            _context.LoanApplicationPage.LastName = lastName;
        }

        [Given(@"I enter a customer name")]
        public void GivenIEnterACustomerName(Table table)
        {
            //to read data, there are multiple ways

                            // Way 1, weakly typed
            //var customerName = new Dictionary<string, string>();

            //foreach (var row in table.Rows)
            //{
            //    var firstName = row["attribute"];
            //    var value = row["value"];
            //    customerName.Add(firstName, value);
            //}

            //_context.LoanApplicationPage.FirstName = customerName["FirstName"];
            //_context.LoanApplicationPage.LastName = customerName["LastName"];

                            //Way 2, weakly typed
            //Issue: has magic strings
            //string firstName = table.Rows.First(row => row["attribute"] == "FirstName")["value"];
            //string lastName = table.Rows.First(row => row["attribute"] == "LastName")["value"];

                            //Way 3, strongly typed
            //strongly typed implementation
            //var customerName = table.CreateInstance<CustomerName>();

                            //Way 4, strongly typed
            //strongly typed implementation using C# Dynamics
            dynamic customerName = table.CreateDynamicInstance();

            _context.LoanApplicationPage.FirstName = customerName.FirstName;
            _context.LoanApplicationPage.LastName = customerName.LastName;
        }


        [Given(@"I select that I have a (.*) account")]
        public void GivenISelectThatIHaveAAccount(ExistingAccount existingAccount)
        {
            //_driver.FindElement(By.Id("Loan")).Click();
            
            _context.LoanApplicationPage.SelectExistingLoan(existingAccount);
        }
        
        [Given(@"I confirm my acceptance of the terms and conditions")]
        public void GivenIConfirmMyAcceptanceOfTheTermsAndConditions()
        {
            //_driver.FindElement(By.Name("TermsAcceptance")).Click();
            _context.LoanApplicationPage.AcceptTermsAndConditions();
        }
        
        [When(@"I sbumit the application")]
        public void WhenISbumitTheApplication()
        {
            //_driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            _confirmationPage = _context.LoanApplicationPage.SubmitApplication();
            _context.ApplicationConfirmationPage = _confirmationPage;
        }
        
        [Then(@"I should see the application complete confirmation for (.*)")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationFor(string firstName)
        {
            //IWebElement confirmationSpan = _driver.FindElement(By.Id("firstName"));
            Assert.Equal(firstName, _confirmationPage.FirstName);
        }

        [Then(@"I should see an error message telling me I must accept the terms and conditions")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustAcceptTheTermsAndConditions()
        {
            //IWebElement errorElement = _driver.FindElement(By.CssSelector(".validation-summary-errors ul li"));

            Assert.Equal("You must accept the terms and conditions",_context.LoanApplicationPage.ErrorText);
        }

        //[AfterScenario]
        //public void DisposeWebDriver()
        //{
        //    //_driver.Dispose();
        //    _context.Driver.Dispose();
        //}

        [Given(@"I have magical powers")]
        public void GivenIHaveMaficalPowers(Table table)
        {
            //weekly typed implementation
            //foreach(var row in table.Rows)
            //{
            //    var item = row["item"];
            //    var value = int.Parse(row["value"]);
            //    var power = int.Parse(row["power"]);
            //    //Console.WriteLine($"{item} - {value} - {power}");
            //}

            //strongly typed using CreateSet<>()
            //IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>();
            //magicalItems.AddRange(items);

            //strongly typed using  C# dynamics
            IEnumerable<dynamic> items = table.CreateDynamicSet();
            magicalItems = new List<MagicalItem>();
            foreach (var magicalItem in items)
            {
                magicalItems.Add(new MagicalItem
                {
                    Name = magicalItem.name,
                    Value = magicalItem.value,
                    Power = magicalItem.power
                });
            }

        }

        [Given(@"I visisted bank (.* days ago)")]
        public void GivenIVisistedBankDaysAgo(DateTime dateTime)
        {
            Console.WriteLine(dateTime);
        }

        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<Weapon> weapons)
        {
            Console.WriteLine(weapons);
        }
    }
}
