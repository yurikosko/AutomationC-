using System;
using OpenQA.Selenium;

namespace AutomationTryOut
{
    internal class HomePage : BasePage
    {

        public HomePage(IWebDriver driver) : base(driver) { }

        public bool isVisible =>  Driver.Title.Contains("Amazon.com: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more");

        public IWebElement searchTextBox => Driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));

        public IWebElement searchButton => Driver.FindElement(By.XPath("//input[@type='submit']"));



     
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        internal searchResultsPage FillOutFormAndSubmit(string v)
        {
            searchTextBox.SendKeys(v);
            searchButton.Click();
            return new searchResultsPage(Driver);
        }

        
    }
}