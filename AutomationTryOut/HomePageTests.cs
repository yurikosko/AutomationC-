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

        [SetUp] public void Init()
        {
            Driver = GetChromeDriver();
            TestUser user = new TestUser
            {
                userEmailAdress = "testamazon@ukr.net",
                userPassword = "Qwerty123$",
                userName = "Test",
                searchKeyword = "macbook"
            };

        }

        [TearDown] public void CleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Test]
        [Category("HomePageTests")]
        public void TestSearchonHomePage(TestUser user)
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.That(homePage.isVisible,Is.True);
            var searchResultsPage = homePage.FillOutFormAndSubmit(user.searchKeyword);
            Assert.That(searchResultsPage.isVisible,Is.True);
           
        }

        [Test]
        [Category("HomePageTests")]
        public void SignInWithValidCredentialsTest()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            homePage.Login(user);
            Assert.That(homePage.isLoggedIn(user), Is.True);
        }
    }
}
