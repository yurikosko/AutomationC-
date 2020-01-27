using System;
using OpenQA.Selenium;

namespace AutomationTryOut
{
    internal class HomePage
    {
        public bool isVisible
        {
            get
            {
                return Driver.Title.Contains("Amazon.com: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more");
            }
            set { }
        }
        private IWebDriver Driver { get; set; }


        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        internal searchResultsPage FillOutFormAndSubmit(string v)
        {
            Driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']")).SendKeys(v);
            Driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            return new searchResultsPage(Driver);
        }

        
    }
}