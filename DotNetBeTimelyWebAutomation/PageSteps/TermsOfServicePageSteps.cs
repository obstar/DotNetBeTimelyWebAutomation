using DotNetBeTimelyWebAutomation.Tests.PageActions;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.PageSteps
{
    [Binding]
    [Scope(Feature = "SignUpLinks")]
    public class TermsOfServicePageSteps
    {
        private readonly TermsOfServicePageActions _termsOfServicePageActions;

        public TermsOfServicePageSteps(TermsOfServicePageActions termsOfServicePageActions)
        {
            _termsOfServicePageActions = termsOfServicePageActions;
        }

        [Then(@"user can see Terms Of Service page")]
        public void ThenUserCanSeeTermsOfServicePage()
        {
            _termsOfServicePageActions.AssertPageLoaded();
        }
    }
}