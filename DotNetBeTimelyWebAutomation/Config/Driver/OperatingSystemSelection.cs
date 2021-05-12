using System;
using DotNetBeTimelyWebAutomation.Tests.Config.Driver.Platform;
using OpenQA.Selenium;

namespace DotNetBeTimelyWebAutomation.Tests.Config.Driver
{
    public class OperatingSystemSelection : IOperatingSystemSelection
    {
        private readonly CoypuDriverBuilder _coypuDriverBuilder;

        public OperatingSystemSelection(CoypuDriverBuilder coypuDriverBuilder)
        {
            _coypuDriverBuilder = coypuDriverBuilder;
        }

        public IBrowserSelection BrowsersForDesiredOperatingSystemAutoTestOption(DriverOptions options)
        {
            IBrowserSelection browserSelection;
            switch (TestsRunOptions.DesiredOperatingSystem)
            {
                case "Windows":
                    browserSelection = Windows(TestsRunOptions.DesiredOperatingSystemVersion, options);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Unhandled OperatingSystem {TestsRunOptions.DesiredOperatingSystem}");
            }

            return browserSelection;
        }

        public IBrowserSelection Windows(string osVersion,
                                         DriverOptions options,
                                         string resolution = "1920x1080")
        {
            return new Windows(_coypuDriverBuilder, osVersion, options, resolution);
        }

        public IBrowserSelection BrowsersFromParameters(string operatingSystem,
                                                        string operatingSystemVersion,
                                                        DriverOptions options)
        {
            IBrowserSelection browserSelection;
            switch (operatingSystem.ToLower())
            {
                case "windows":
                    browserSelection = Windows(operatingSystemVersion, options);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Unhandled OperatingSystem {TestsRunOptions.DesiredOperatingSystem}");
            }

            return browserSelection;
        }
    }
}