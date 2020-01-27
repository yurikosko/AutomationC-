using OpenQA.Selenium;
using NUnit.Framework;

namespace AutomationTryOut
{
    internal class searchResultsPage
    {
        public bool isVisible
        {
            get
            {
                return Driver.FindElement(By.XPath("//span[@class='a-color-state a-text-bold']")).Text.Contains("macbook");       
            }
            set { }
        }
        private IWebDriver Driver;

        public searchResultsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}