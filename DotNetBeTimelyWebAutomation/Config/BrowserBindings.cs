using System;
using BoDi;
using Coypu;
using Coypu.Drivers.Selenium;
using DotNetBeTimelyWebAutomation.Tests.Config.Driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace DotNetBeTimelyWebAutomation.Tests.Config
{
    [Binding]
    public class BrowserBindings
    {
        private static EndPoints _endPoints;
        private BrowserSession _browser;
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _specFlowContainer;

        public BrowserBindings(IObjectContainer specFlowContainer,
                               ScenarioContext scenarioContext)
        {
            _specFlowContainer = specFlowContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun(Order = 0)]
        public static void BeforeAllTests()
        {
            _endPoints = EndPoints.Production;
        }

        [BeforeScenario(Order = 10)]
        public void BeforeScenario()
        {
            Console.WriteLine($"-> [BeforeScenario] {_scenarioContext.ScenarioInfo.Title}");

            _specFlowContainer.RegisterInstanceAs(_endPoints);

            var sessionConfiguration = new SessionConfiguration
                                       {
                                           AppHost = _endPoints.ServerHost,
                                           SSL = _endPoints.ServerScheme.Equals("https"),
                                           Driver = typeof(SeleniumWebDriver),
                                           Timeout = TimeSpan.FromSeconds(15),
                                           RetryInterval = TimeSpan.FromSeconds(1)
                                       };
            _browser = new CoypuDriverBuilder().FromAutoTestOptions(sessionConfiguration,
                                                                    "DotNetGiphyWebAutomation",
                                                                    _scenarioContext.ScenarioInfo.Title);

            _specFlowContainer.RegisterInstanceAs(_browser);
        }

        [BeforeStep(Order = 10)]
        public void BeforeStep()
        {
            Console.WriteLine($"\t-> [BeforeStep] {_scenarioContext.StepContext.StepInfo.Text}");
        }

        [AfterScenario(Order = 10)]
        public void AfterEachScenario()
        {
            var nUnitStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var failed = nUnitStatus is not TestStatus.Passed and not TestStatus.Skipped;
            Console.WriteLine($"-> [AfterScenario] {_scenarioContext.ScenarioInfo.Title}");

            _browser?.Dispose();

            try
            {
                if (!failed) return;
                var error = _scenarioContext.TestError;
                Console.WriteLine("-> [AfterScenario] test has failed!");
                Console.WriteLine($"-> [AfterScenario] An error occurred: {(error != null ? error.Message : "unknown")}");
                Console.WriteLine($"-> [AfterScenario] It was of type: {(error != null ? error.GetType().Name : "unknown")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("-> Could not mark session as failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}