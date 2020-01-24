using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTryOut
{
    [TestFixture]
    public class HomePageTests
    {

        public IWebDriver Driver { get; set; }

        [Test]
        [Category("HomePage")]
        public void TestMethod1()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.That(homePage.isVisible);

            var searchResultsPage = homePage.FillOutFormAndSubmit("macbook");
            Assert.IsTrue(searchResultsPage.isVisible);

        }
    }
}
