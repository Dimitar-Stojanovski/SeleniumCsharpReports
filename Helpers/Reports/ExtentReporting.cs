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
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\ReportResults\";
            
            if (extentReports == null)
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

        public static void EndReporting(string info, string image)
        {
            EndTest(info, image);
            StartReporting().Flush();
        }

        

        private static void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        private static void Loginfo(string info)
        {
            extentTest.Info(info);
        }

        private static void LogScreenshot(string info,string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

        private static void EndTest(string info, string screenshot)
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    LogFail($"Test has failed with message: {message}");
                    LogScreenshot(info, screenshot);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    Loginfo($"Test skipped because:{message}");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    Loginfo("Test has passed succesfully");
                    break;
                default:
                    break;
            }
        }
    }
}
