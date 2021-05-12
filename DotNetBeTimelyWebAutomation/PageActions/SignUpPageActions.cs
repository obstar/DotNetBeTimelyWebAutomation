using Coypu;
using DotNetBeTimelyWebAutomation.Tests.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageActions
{
    [Binding]
    public class SignUpPageActions
    {
        private readonly BrowserSession _browser;

        public SignUpPageActions(BrowserSession browser)
        {
            _browser = browser;
        }

        public void NavigateToPage()
        {
            _browser.Visit(SignUpPage.Url);
        }

        public void AssertPageLoaded()
        {
            Assert.AreEqual("Register your Timely account - Timely", _browser.Title);
            Assert.IsTrue(_browser.FindLink(SignUpPage.LinkTextLogIn).Exists());
            Assert.IsTrue(_browser.FindButton(SignUpPage.ButtonTextSignUpWithGoogle).Exists());
            Assert.IsTrue(_browser.FindButton(SignUpPage.ButtonTextSignUpWithApple).Exists());
            Assert.IsTrue(_browser.FindId(SignUpPage.InputIdWorkEmail).Exists());
            Assert.IsTrue(_browser.FindId(SignUpPage.InputIdFullName).Exists());
            Assert.IsTrue(_browser.FindId(SignUpPage.InputIdPassword).Exists());
            Assert.IsTrue(_browser.FindCss(SignUpPage.ButtonCssStartFreeDayTrial).Exists());
            Assert.IsTrue(_browser.FindLink(SignUpPage.LinkTextTermsOfService).Exists());
        }
    }
}