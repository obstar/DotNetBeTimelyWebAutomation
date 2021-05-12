using Coypu;
using DotNetBeTimelyWebAutomation.Tests.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageActions
{
    [Binding]
    public class WelcomePageActions
    {
        private readonly BrowserSession _browser;

        public WelcomePageActions(BrowserSession browser)
        {
            _browser = browser;
        }

        public void AssertPageLoaded()
        {
            Assert.IsTrue(_browser.FindCss(WelcomePage.InputCssSearch)
                                  .Exists());
            Assert.IsTrue(_browser.FindButton(WelcomePage.ButtonTextJustMe)
                                  .Exists());
            Assert.IsTrue(_browser.FindButton(WelcomePage.ButtonText2To19People)
                                  .Exists());
            Assert.IsTrue(_browser.FindButton(WelcomePage.ButtonText20PeopleOrMore)
                                  .Exists());
            Assert.IsTrue(_browser.FindCss(WelcomePage.ButtonCssNext)
                                  .Exists());
            Assert.AreEqual(WelcomePage.Title, _browser.Title);
        }
    }
}