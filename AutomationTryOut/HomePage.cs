using System;

namespace AutomationTryOut
{
    internal class HomePage
    {
        internal object isVisible;
        private IWebDrov driver;

        public HomePage(object driver)
        {
            this.driver = driver;
        }

        internal void GoTo()
        {
            throw new NotImplementedException();
        }

        internal searchResultsPage FillOutFormAndSubmit(string v)
        {
            throw new NotImplementedException();
        }
    }
}