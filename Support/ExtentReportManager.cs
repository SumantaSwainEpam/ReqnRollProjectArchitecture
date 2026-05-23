using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace ReqnRollProjectArchitecture.Support
{
    public class ExtentReportManager
    {
        private static ExtentReports? _extent;
        private static ThreadLocal<ExtentTest> _feature = new ThreadLocal<ExtentTest>();
        private static ThreadLocal<ExtentTest> _scenario = new ThreadLocal<ExtentTest>();
        
        public static string ReportPath { get; private set; } = string.Empty;

        public static void InitReport()
        {
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            var reportDir = Path.Combine(projectDir ?? AppDomain.CurrentDomain.BaseDirectory, "TestResults", "Reports");
            
            if (!Directory.Exists(reportDir))
            {
                Directory.CreateDirectory(reportDir);
                LoggerHelper.Info($"Created Report directory: {reportDir}");
            }

            ReportPath = Path.Combine(reportDir, $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
            LoggerHelper.Info($"Report path set to: {ReportPath}");

            var sparkReporter = new ExtentSparkReporter(ReportPath);
            sparkReporter.Config.DocumentTitle = "Automation Test Report";
            sparkReporter.Config.ReportName = "ReqnRoll Test Execution";
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
            _extent.AddSystemInfo("Application", "YourAppName");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
        }

        public static void CreateFeature(string featureName)
        {
            _feature.Value = _extent?.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureName);
        }

        public static void CreateScenario(string scenarioName)
        {
            _scenario.Value = _feature.Value?.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(scenarioName);
        }

        public static void CreateStep(string stepType, string stepName, bool isPassed, string? errorMessage = null, string? screenshotPath = null)
        {
            ExtentTest? step = null;

            switch (stepType)
            {
                case "Given":
                    step = _scenario.Value?.CreateNode<AventStack.ExtentReports.Gherkin.Model.Given>(stepName);
                    break;
                case "When":
                    step = _scenario.Value?.CreateNode<AventStack.ExtentReports.Gherkin.Model.When>(stepName);
                    break;
                case "Then":
                    step = _scenario.Value?.CreateNode<AventStack.ExtentReports.Gherkin.Model.Then>(stepName);
                    break;
                case "And":
                    step = _scenario.Value?.CreateNode<AventStack.ExtentReports.Gherkin.Model.And>(stepName);
                    break;
                default:
                    step = _scenario.Value?.CreateNode(stepName);
                    break;
            }

            if (isPassed)
            {
                step?.Pass("Step passed");
            }
            else
            {
                step?.Fail(errorMessage);
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    step?.AddScreenCaptureFromPath(screenshotPath);
                }
            }
        }

        public static void Flush()
        {
            _extent?.Flush();
            LoggerHelper.Info("Extent Report flushed.");
        }
    }
}
