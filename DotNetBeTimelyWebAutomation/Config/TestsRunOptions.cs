using System;
using DotNetBeTimelyWebAutomation.Tests.Config.Driver;
using NUnit.Framework;

namespace DotNetBeTimelyWebAutomation.Tests.Config
{
    public class TestsRunOptions
    {
        public static string DesiredBrowser => GetParamOrDefault("TestRun_Browser", SupportedBrowsers.Chrome);
        public static string DesiredBrowserVersion => GetParamOrDefault("TestRun_BrowserVersion", "latest");
        public static string DesiredOperatingSystem => GetParamOrDefault("TestRun_OperatingSystem", "Windows");
        public static string DesiredOperatingSystemVersion => GetParamOrDefault("TestRun_OperatingSystemVersion", "10");

        private static T GetParamOrDefault<T>(string paramName,
                                              T defaultValue)
        {
            T paramValue;
            if (!string.IsNullOrEmpty(TestContext.Parameters[paramName]))
                paramValue = (T) Convert.ChangeType(TestContext.Parameters[paramName],
                                                    typeof(T));
            else if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(paramName)))
                paramValue = (T) Convert.ChangeType(Environment.GetEnvironmentVariable(paramName),
                                                    typeof(T));
            else
                paramValue = defaultValue;

            return paramValue;
        }
    }
}