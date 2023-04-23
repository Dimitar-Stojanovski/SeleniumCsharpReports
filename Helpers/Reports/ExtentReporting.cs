using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpReports.Helpers.Reports
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (extentReports==null)
            {
                Directory.CreateDirectory(path);
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);
                extentReports.AttachReporter(htmlReporter);
            }

            return extentReports;
        }

        public static void CreateTest(string _name)
        {
            extentTest = StartReporting().CreateTest(_name);
        }

        public static void EndReporting()
        {
            StartReporting().Flush();
        }
    }
}
