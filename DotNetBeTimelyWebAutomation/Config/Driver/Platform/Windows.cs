using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DotNetBeTimelyWebAutomation.Tests.Config.Driver.Platform
{
    internal class Windows : IBrowserSelection
    {
        private readonly CoypuDriverBuilder _coypuDriverBuilder;

        public Windows(CoypuDriverBuilder coypuDriverBuilder,
                       string osVersion,
                       DriverOptions driverOptions,
                       string resolution = "1920x1080")
        {
            _coypuDriverBuilder = coypuDriverBuilder;
            _coypuDriverBuilder.DriverOptions = driverOptions;


            switch (TestsRunOptions.DesiredBrowser)
            {
                case SupportedBrowsers.Chrome:
                {
                    var options = _coypuDriverBuilder.DriverOptions as ChromeOptions;
                    options.AddAdditionalCapability("os", "Windows", true);
                    options.AddAdditionalCapability("os_version", osVersion, true);
                    options.AddAdditionalCapability("resolution", resolution, true);
                    options.AddAdditionalCapability("screenResolution", resolution, true);
                    break;
                }
                case SupportedBrowsers.Firefox:
                {
                    var profile = new FirefoxProfile();

                    _coypuDriverBuilder.DriverOptions.AcceptInsecureCertificates = true;
                    profile.AcceptUntrustedCertificates = true;
                    profile.AssumeUntrustedCertificateIssuer = false;
                    profile.SetPreference("security.enterprise_roots.enabled", true);
                    (_coypuDriverBuilder.DriverOptions as FirefoxOptions).Profile = profile;
                    var options = _coypuDriverBuilder.DriverOptions as FirefoxOptions;
                    options.AddAdditionalCapability("os", "Windows", true);
                    options.AddAdditionalCapability("os_version", osVersion, true);
                    options.AddAdditionalCapability("resolution", resolution, true);
                    options.AddAdditionalCapability("screenResolution", resolution, true);
                    options.AddAdditionalCapability("platform", $"Windows {osVersion}", true);
                    break;
                }
            }
        }

        public IBrowser Firefox()
        {
            return new Browser(_coypuDriverBuilder, SupportedBrowsers.Firefox, "64");
        }

        public IBrowser Firefox(string version)
        {
            return new Browser(_coypuDriverBuilder, SupportedBrowsers.Firefox, version);
        }

        public IBrowser Chrome()
        {
            return new Browser(_coypuDriverBuilder, SupportedBrowsers.Chrome);
        }

        public IBrowser Chrome(string version)
        {
            return new Browser(_coypuDriverBuilder, SupportedBrowsers.Chrome, version);
        }

        public IBrowser DefaultForPlatform()
        {
            return new Browser(_coypuDriverBuilder, SupportedBrowsers.Chrome);
        }
    }
}