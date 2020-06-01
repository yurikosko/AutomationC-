using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AmazonAutomation
{
    [TestFixture]
    public class HomePageTests
    {
        private IWebDriver Driver { get; set; }
        private IWebDriver GetChromeDriver()

        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        [SetUp] public void Init()
        {

            Driver = GetChromeDriver();
            Driver.Manage().Window.FullScreen();
        }

        [TearDown] public void CleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Test]
        [Category("HomePageTests")]
        public void SearchonHomePage()
        {
            TestUser user1 = new TestUser();
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.That(homePage.isVisible,Is.True);
            var searchResultsPage = homePage.FillOutFormAndSubmit(user1.searchKeyword);
            Assert.That(searchResultsPage.isVisible,Is.True);
           
        }

        /// Amazon kinda understands that automated test software is logging in and requires OTP code upon sign up. Won't work
        [Test]
        [Category("HomePageTests")]
        public void SignInWithValidCredentialsTest()
        {
            TestUser user1 = new TestUser();
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            homePage.Login(user1);
            Assert.That(homePage.isLoggedIn(user1), Is.True);
        }
    }
}
