using DotNetBeTimelyWebAutomation.Tests.PageActions;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageSteps
{
    [Binding]
    [Scope(Feature = "SignUp")]
    public class WelcomeSteps
    {
        private readonly WelcomePageActions _welcomePageStepsPageActions;

        public WelcomeSteps(WelcomePageActions welcomePageStepsPageActions)
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