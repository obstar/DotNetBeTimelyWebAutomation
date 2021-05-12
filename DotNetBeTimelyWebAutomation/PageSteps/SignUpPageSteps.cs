using DotNetBeTimelyWebAutomation.Tests.PageActions;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageSteps
{
    [Binding]
    [Scope(Feature = "SignUp")]
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

        [Then(@"user can see Sign Up page")]
        public void ThenUserCanSeeSignUpPage()
        {
            _signUpPageActions.AssertPageLoaded();
        }
    }
}