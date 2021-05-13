using System;
using Coypu;
using DotNetBeTimelyWebAutomation.Tests.Context;
using DotNetBeTimelyWebAutomation.Tests.PageObjects;
using DotNetBeTimelyWebAutomation.Tests.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageActions
{
    [Binding]
    public class SignUpPageActions
    {
        private readonly BrowserSession _browser;
        private readonly FormDataGenerator _formDataGenerator;
        private readonly SessionContext _sessionContext;

        public SignUpPageActions(BrowserSession browser,
                                 FormDataGenerator formDataGenerator,
                                 SessionContext sessionContext)
        {
            _browser = browser;
            _formDataGenerator = formDataGenerator;
            _sessionContext = sessionContext;
        }

        public void NavigateToPage()
        {
            _browser.Visit(SignUpPage.Url);
        }

        public void AssertPageLoaded()
        {
            Assert.IsTrue(_browser.FindLink(SignUpPage.LinkTextLogIn)
                                  .Exists());
            Assert.IsTrue(_browser.FindButton(SignUpPage.ButtonTextSignUpWithGoogle)
                                  .Exists());
            Assert.IsTrue(_browser.FindButton(SignUpPage.ButtonTextSignUpWithApple)
                                  .Exists());
            Assert.IsTrue(_browser.FindId(SignUpPage.InputIdWorkEmail)
                                  .Exists());
            Assert.IsTrue(_browser.FindId(SignUpPage.InputIdFullName)
                                  .Exists());
            Assert.IsTrue(_browser.FindId(SignUpPage.InputIdPassword)
                                  .Exists());
            Assert.IsTrue(_browser.FindCss(SignUpPage.ButtonCssStartFreeDayTrial)
                                  .Exists());
            Assert.IsTrue(_browser.FindLink(SignUpPage.LinkTextTermsOfService)
                                  .Exists());
            Assert.AreEqual(SignUpPage.Title, _browser.Title);
        }

        public void ClickButtonStartFreeDayTrial()
        {
            _browser.FindCss(SignUpPage.ButtonCssStartFreeDayTrial)
                    .Click();
            _browser.FindCss(SignUpPage.ButtonCssStartFreeDayTrial)
                    .Missing();
        }

        public void ClickLinkLogIn()
        {
            _browser.ClickLink(SignUpPage.LinkTextLogIn);
        }

        public void ClickLinkTermsOfService()
        {
            _browser.ClickLink(SignUpPage.LinkTextTermsOfService);
        }

        public void FillInSignUpForm()
        {
            FillInWorkEmail($"jakub{_formDataGenerator.AnAlphaNumericCode(5)}@memorytest.ai");
            FillInFullName($"Jakub {_formDataGenerator.AnAlphaCode(5)}");
            FillInPassword($"password{_formDataGenerator.AnAlphaNumericCode(5)}");
        }

        private void FillInWorkEmail(string workEmail)
        {
            Console.WriteLine($"\t -> Work email: {workEmail}");
            _browser.FindId(SignUpPage.InputIdWorkEmail)
                    .FillInWith(workEmail);
            _sessionContext.User.Email = workEmail;
        }

        private void FillInFullName(string fullName)
        {
            Console.WriteLine($"\t -> Full Name: {fullName}");
            _browser.FindId(SignUpPage.InputIdFullName)
                    .FillInWith(fullName);
            _sessionContext.User.FullName = fullName;
        }

        private void FillInPassword(string password)
        {
            Console.WriteLine($"\t -> Password: {password}");
            _browser.FindId(SignUpPage.InputIdPassword)
                    .FillInWith(password);
            _sessionContext.User.Password = password;
        }
    }
}