using DotNetBeTimelyWebAutomation.Tests.PageActions;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageSteps
{
    [Binding]
    [Scope(Feature = "SignUpLinks")]
    public class LoginPageSteps
    {
        private readonly LoginPageActions _loginPageActions;

        public LoginPageSteps(LoginPageActions loginPageActions)
        {
            _loginPageActions = loginPageActions;
        }

        [Then(@"user can see Login page")]
        public void ThenUserCanSeeLoginPage()
        {
            _loginPageActions.AssertPageLoaded();
        }
    }
}