using System;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace DotNetBeTimelyWebAutomation.Tests.Config.Driver
{
    public class CoypuDriver : SeleniumWebDriver
    {
        private static readonly TimeSpan CommandTimeout = TimeSpan.FromSeconds(360);

        public CoypuDriver(RemoteWebDriver underlyingDriver) : base(underlyingDriver,
                                                                    Coypu.Drivers.Browser.Firefox /*Do not pay any attention to this param - it will be ignored, but Browser ctor is private*/)
        {
            SessionId = underlyingDriver.SessionId.ToString();
        }

        public string SessionId { get; }

        public static CoypuDriver FromCaps(DriverOptions driverOptions)
        {
            RemoteWebDriver innerDriver;

            switch (driverOptions.BrowserName.ToLower())
            {
                case SupportedBrowsers.Chrome:
                    innerDriver = CreateChromeDriver(driverOptions);
                    break;
                case SupportedBrowsers.Firefox:
                    innerDriver = CreateFireFoxDriver(driverOptions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            innerDriver.Manage()
                       .Timeouts()
                       .AsynchronousJavaScript = TimeSpan.FromSeconds(1000);
            var driver = new CoypuDriver(innerDriver);
            return driver;
        }

        private static FirefoxDriver CreateFireFoxDriver(DriverOptions driverOptions)
        {
            var service = HideCommandPromptWindow(FirefoxDriverService.CreateDefaultService());
            var options = (FirefoxOptions) driverOptions;

            return new FirefoxDriver(service, options, CommandTimeout);
        }

        private static ChromeDriver CreateChromeDriver(DriverOptions driverOptions)
        {
            var service = HideCommandPromptWindow(ChromeDriverService.CreateDefaultService());
            var options = (ChromeOptions) driverOptions;
            options.AddArgument("allow-running");
            options.AddArgument("allow-running-insecure-content");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("no-sandbox");

            return new ChromeDriver(service, options);
        }

        private static TDriverService HideCommandPromptWindow<TDriverService>(TDriverService service)
            where TDriverService : DriverService
        {
            service.HideCommandPromptWindow = true;
            return service;
        }
    }
}