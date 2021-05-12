using DotNetBeTimelyWebAutomation.Tests.PageActions;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageSteps
{
    [Binding]
    [Scope(Feature = "SignUp")]
    public class WelcomePageSteps
    {
        private readonly WelcomePageActions _welcomePageStepsPageActions;

        public WelcomePageSteps(WelcomePageActions welcomePageStepsPageActions)
        {
            _welcomePageStepsPageActions = welcomePageStepsPageActions;
        }

        [Then(@"user can see Welcome page")]
        public void ThenUserCanSeeWelcomePage()
        {
            _welcomePageStepsPageActions.AssertPageLoaded();
        }
    }
}