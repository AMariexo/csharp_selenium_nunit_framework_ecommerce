using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Utils
{
    public static class ExtentManager
    {

        private static ExtentReports _extent;
        private static ExtentSparkReporter _reporter;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "TestReport.html");
                Console.WriteLine(reportPath);
                _reporter = new ExtentSparkReporter(reportPath);
                _reporter.Config.DocumentTitle = "Automation Test Report";
                _reporter.Config.ReportName = "Regression Suite";

                _extent = new ExtentReports();
                _extent.AttachReporter(_reporter);
            }
            return _extent;
        }

        public static void RecordResultsForEachTest(ExtentTest test, TestStatus status, String? message)
        {
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    test.Pass("Test Passed");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    test.Fail("The test failed.." + message);
                    break;
            }
        }
    }
}
