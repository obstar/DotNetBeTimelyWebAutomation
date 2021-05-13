using DotNetBeTimelyWebAutomation.Tests.PageActions;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageSteps
{
    [Binding]
    [Scope(Feature = "SignUp")]
    [Scope(Feature = "SignUpLinks")]
    [Scope(Tag = "Register")]
    public class SignUpPageSteps
    {
        private readonly SignUpPageActions _signUpPageActions;

        public SignUpPageSteps(SignUpPageActions signUpPageActions)
        {
            _signUpPageActions = signUpPageActions;
        }

        [Given(@"I go to staging timely Sign up page")]
        public void GivenIGoToStagingTimelySignUpPage()
        {
            _signUpPageActions.NavigateToPage();
        }

        [When(@"I enter my custom details on Sign Up page")]
        public void WhenIEnterMyCustomDetailsOnSignUpPage()
        {
            _signUpPageActions.FillInSignUpForm();
        }

        [When(@"I click Start free 14 day trial button on Sign Up page")]
        public void WhenIClickStartFreeDayTrialButtonOnSignUpPage()
        {
            _signUpPageActions.ClickButtonStartFreeDayTrial();
        }

        [When(@"I click Log In link on Sign Up page")]
        public void WhenIClickLogInLinkOnSignUpPage()
        {
            _signUpPageActions.ClickLinkLogIn();
        }

        [Then(@"user can see Sign Up page")]
        public void ThenUserCanSeeSignUpPage()
        {
            _signUpPageActions.AssertPageLoaded();
        }
    }
}