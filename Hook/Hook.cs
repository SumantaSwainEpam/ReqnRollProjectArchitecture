using OpenQA.Selenium;
using Reqnroll.BoDi;
using ReqnRollProjectArchitecture.Credentials;
using ReqnRollProjectArchitecture.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReqnRollProjectArchitecture.Support;
using Reqnroll;
using System.IO;
using ReqnRollProjectArchitecture.Helpers;

namespace ReqnRollProjectArchitecture.Hook
{
    [Binding]
    internal sealed class Hook
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver = null;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hook(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LoggerHelper.InitLogger();
            LoggerHelper.Info("Initializing Test Execution...");
            ExtentReportManager.InitReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.Flush();
            LoggerHelper.Info("Test Execution Completed and Report Generated.");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            LoggerHelper.Info($"Starting Feature: {featureContext.FeatureInfo.Title}");
            ExtentReportManager.CreateFeature(featureContext.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            LoggerHelper.Info($"Starting Scenario: {_scenarioContext.ScenarioInfo.Title}");
            string browserType = CredentialsManager.GetBrowsers().FirstOrDefault() ?? CredentialsManager.GetDefaultBrowser();
            _driver = WebDriverFactory.Create(browserType);
            _objectContainer.RegisterInstanceAs(_driver);
            
            ExtentReportManager.CreateScenario(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepName = _scenarioContext.StepContext.StepInfo.Text;

            if (_scenarioContext.TestError == null)
            {
                LoggerHelper.Info($"Step Passed: {stepType} {stepName}");
                ExtentReportManager.CreateStep(stepType, stepName, true);
            }
            else
            {
                LoggerHelper.Error($"Step Failed: {stepType} {stepName} | Error: {_scenarioContext.TestError.Message}");
                var helper = new SeleniumHelper(_driver!);
                string screenshotPath = helper.TakeScreenshot(stepName);
                ExtentReportManager.CreateStep(stepType, stepName, false, _scenarioContext.TestError.Message, screenshotPath);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }


    }
}
