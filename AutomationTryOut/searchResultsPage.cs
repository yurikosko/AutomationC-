using OpenQA.Selenium;
using NUnit.Framework;

namespace AutomationTryOut
{
    internal class searchResultsPage : BasePage
    {
        public searchResultsPage(IWebDriver driver) : base(driver) { }

        public IWebElement searchResultText => Driver.FindElement(By.XPath("//span[@class='a-color-state a-text-bold']"));
        public bool isVisible => searchResultText.Text.Contains("macbook");       



        
      
    }
}