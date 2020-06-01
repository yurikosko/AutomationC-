using System;
using OpenQA.Selenium;

namespace AmazonAutomation
{
    internal class BasePage
    {

        protected IWebDriver Driver { get; set;}
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}