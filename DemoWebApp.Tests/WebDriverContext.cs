using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp.Tests
{
    public class WebDriverContext
    {
        public IWebDriver Driver { get; set; }

        public LoanApplicationPage LoanApplicationPage { get; set; }

        public ApplicationConfirmationPage ApplicationConfirmationPage { get; set; }
    }
}
