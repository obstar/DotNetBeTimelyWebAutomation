using Coypu;
using DotNetBeTimelyWebAutomation.Tests.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageActions
{
    [Binding]
    public class LoginPageActions
    {
        private readonly BrowserSession _browser;

        public LoginPageActions(BrowserSession browser)
        {
            _browser = browser;
        }

        public void AssertPageLoaded()
        {
            Assert.IsTrue(_browser.FindCss(LoginPage.LinkCssSignUp)
                                  .Exists());
            Assert.IsTrue(_browser.FindId(LoginPage.InputIdEmail)
                                  .Exists());
            Assert.IsTrue(_browser.FindId(LoginPage.ButtonIdNext)
                                  .Exists());
            Assert.IsTrue(_browser.FindLink(LoginPage.LinkTextIForgotMyPassword)
                                  .Exists());
            Assert.IsTrue(_browser.FindButton(LoginPage.ButtonTextSignInWithGoogle)
                                  .Exists());
            Assert.IsTrue(_browser.FindButton(LoginPage.ButtonTextSignInWithApple)
                                  .Exists());
            Assert.IsTrue(_browser.FindLink(LoginPage.LinkTextReadMore)
                                  .Exists());
            Assert.AreEqual(LoginPage.Title, _browser.Title);
        }
    }
}