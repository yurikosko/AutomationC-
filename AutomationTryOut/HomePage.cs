using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomationTryOut
{
    internal class HomePage : BasePage
    {

        public HomePage(IWebDriver driver) : base(driver) { }

        public bool isVisible =>  Driver.Title.Contains("Amazon.com: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more");

        public IWebElement searchTextBox => Driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));

        public IWebElement searchButton => Driver.FindElement(By.XPath("//input[@type='submit']"));

        public IWebElement signInButton => Driver.FindElement(By.XPath("//div[@id='nav-signin-tooltip']/a"));

        public IWebElement continueButton => Driver.FindElement(By.XPath("//span[@id='continue']"));

        public IWebElement emailField => Driver.FindElement(By.Id("ap_email"));

        public IWebElement passwordField => Driver.FindElement(By.Id("ap_password"));

        public IWebElement signInSearchPageButton => Driver.FindElement(By.Id("signInSubmit"));

        public IWebElement loggedInAccount => Driver.FindElement(By.XPath("//a[@id='nav-link-accountList']/span[1]"));
        


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

       //some bullshit below
        /*internal void waitForElementbyXpath (IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.)
        }*/

        
        public HomePage Login(TestUser user)
        {
            signInButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            emailField.SendKeys(user.userEmailAdress);
            continueButton.Click();
            passwordField.SendKeys(user.userPassword);
            signInSearchPageButton.Click();
            return new HomePage(Driver);

        }

        public bool isLoggedIn (TestUser user)
        {
            string expected = "Hello, {user.userName}";
            string actual = loggedInAccount.Text;
            return expected.Equals(actual);
        }
    }
}