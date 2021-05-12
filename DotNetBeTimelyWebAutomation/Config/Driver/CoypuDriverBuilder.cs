using System;
using Coypu;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DotNetBeTimelyWebAutomation.Tests.Config.Driver
{
    public class CoypuDriverBuilder : IPlatformSelection
    {
        public DriverOptions DriverOptions { get; set; }

        public IOperatingSystemSelection Desktop()
        {
            return new OperatingSystemSelection(this);
        }

        public BrowserSession FromAutoTestOptions(SessionConfiguration sessionConfiguration,
                                                  string productName,
                                                  string testName)
        {
            switch (TestsRunOptions.DesiredBrowser)
            {
                case SupportedBrowsers.Chrome:
                    DriverOptions = new ChromeOptions();
                    break;
                case SupportedBrowsers.Firefox:
                    DriverOptions = new FirefoxOptions();
                    break;
                case "Default":
                    DriverOptions = new ChromeOptions(); // Chrome is default browser
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unhandled Browser {TestsRunOptions.DesiredBrowser}");
            }

            var browserSelection = Desktop()
                .BrowsersForDesiredOperatingSystemAutoTestOption(DriverOptions);

            IBrowser browser;

            switch (TestsRunOptions.DesiredBrowser)
            {
                case SupportedBrowsers.Chrome:
                    browser = browserSelection.Chrome(TestsRunOptions.DesiredBrowserVersion);
                    break;
                case SupportedBrowsers.Firefox:
                    browser = browserSelection.Firefox(TestsRunOptions.DesiredBrowserVersion);
                    break;
                case "Default":
                    browser = browserSelection.DefaultForPlatform();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unhandled Browser {TestsRunOptions.DesiredBrowser}");
            }

            return browser.CreateBrowserSession(sessionConfiguration);
        }
    }

    public interface IPlatformSelection
    {
        IOperatingSystemSelection Desktop();
    }

    public interface IOperatingSystemSelection
    {
        IBrowserSelection BrowsersForDesiredOperatingSystemAutoTestOption(DriverOptions options);
    }

    public interface IBrowserSelection
    {
        IBrowser Firefox();
        IBrowser Firefox(string version);
        IBrowser Chrome();
        IBrowser Chrome(string version);
        IBrowser DefaultForPlatform();
    }

    public interface IBrowser
    {
        BrowserSession CreateBrowserSession(SessionConfiguration sessionConfiguration);
    }
}