using Coypu;

namespace DotNetBeTimelyWebAutomation.Tests.Config.Driver
{
    public class Browser : IBrowser
    {
        private readonly string _browserVersion;
        private readonly CoypuDriverBuilder _coypuDriverBuilder;

        public Browser(CoypuDriverBuilder coypuDriverBuilder,
                       string browser,
                       string browserVersion) : this(coypuDriverBuilder, browser)
        {
            _browserVersion = browserVersion;
        }

        public Browser(CoypuDriverBuilder coypuDriverBuilder,
                       string browser)
        {
            _coypuDriverBuilder = coypuDriverBuilder;
        }

        public BrowserSession CreateBrowserSession(SessionConfiguration sessionConfiguration)
        {
            sessionConfiguration.Browser = Coypu.Drivers.Browser.Parse(_coypuDriverBuilder.DriverOptions.BrowserName);
            var driver = CoypuDriver.FromCaps(_coypuDriverBuilder.DriverOptions);
            var browserSession = new BrowserSession(sessionConfiguration, driver);
            browserSession.MaximiseWindow();

            return browserSession;
        }
    }
}