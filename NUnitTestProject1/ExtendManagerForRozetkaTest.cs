using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NUnitTestProject1
{
    public class ExtendManagerForRozetkaTest
    {
        public static ExtentReports extent;
        public static ExtentHtmlReporter _extentHtmlReporter;
        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string path = Assembly.GetCallingAssembly().CodeBase;
                string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;

                string reportPath = projectPath + "Reports\\TestRunReport.html";                
                _extentHtmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(_extentHtmlReporter);
                extent.AddSystemInfo("Time", DateTime.Now.ToString());                
            }
            return extent;
        }
    }
}
