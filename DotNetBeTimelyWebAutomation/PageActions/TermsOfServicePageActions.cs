using Coypu;
using DotNetBeTimelyWebAutomation.Tests.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageActions
{
    [Binding]
    public class TermsOfServicePageActions
    {
        private readonly BrowserSession _browser;

        public TermsOfServicePageActions(BrowserSession browser)
        {
            _browser = browser;
        }

        public void AssertPageLoaded()
        {
            var termsOfServiceWindow = _browser.FindWindow(TermsOfServicePage.Title);
            Assert.IsTrue(termsOfServiceWindow.FindCss(TermsOfServicePage.DivCssMenu)
                                              .Exists());
            Assert.IsTrue(termsOfServiceWindow.FindCss(TermsOfServicePage.DivCssTermsOfServiceText)
                                              .Exists());
            StringAssert.Contains(TermsOfServicePage.Subtitle, termsOfServiceWindow.FindCss(TermsOfServicePage.DivCssTermsOfServiceText).Text);
            Assert.AreEqual(TermsOfServicePage.Title, termsOfServiceWindow.Title);
        }
    }
}