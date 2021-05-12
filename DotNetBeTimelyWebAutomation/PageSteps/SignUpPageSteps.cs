using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageSteps
{
    [Binding]
    [Scope(Feature = "SignUp")]
    [Scope(Tag = "Register")]
    public class SignUpPageSteps
    {
        private SignUpPageActions _signUpPageActions;

        public SignUpPageSteps(SignUpPageActions signUpPageActions)
        {
            _signUpPageActions = signUpPageActions;
        }

        [Given(@"I go to staging timely Sign up page")]
        public void GivenIGoToStagingTimelySignUpPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user can see Sign Up page")]
        public void ThenUserCanSeeSignUpPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}