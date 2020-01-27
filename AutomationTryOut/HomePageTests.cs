using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTryOut
{
    [TestFixture]
    public class HomePageTests
    {

        private IWebDriver Driver { get; set; }
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [Test]
        [Category("HomePage")]
        public void TestMethod1()
        {
            Driver = GetChromeDriver();
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.That(homePage.isVisible,Is.True);
            var searchResultsPage = homePage.FillOutFormAndSubmit("macbook");
            Assert.That(searchResultsPage.isVisible,Is.True);

            

        }
    }
}
