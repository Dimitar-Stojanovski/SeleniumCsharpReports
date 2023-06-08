using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCsharpReports.Framework;
using SeleniumCsharpReports.Helpers;
using SeleniumCsharpReports.Helpers.Reports;
using SeleniumCsharpReports.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpReports.Tests
{
    public class BaseTest
    {
        private  IWebDriver driver;
        private  WebDriverWait wait;
        private static int timeout = 20;
        private readonly string _browserName = "Chrome";
        private readonly string _url = "https://magento.softwaretestingboard.com/";
        private readonly IGenericMethods genericMethods;

        public HomePage homePage;

        public DriverBase driverBase;

        [SetUp]
        public void SetUp()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            driverBase = new DriverBase();
            driver = driverBase.Initiate(_browserName);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_url);
            homePage = new HomePage(driver, wait);

        }

        [TearDown]
        public void TearDown()
        {
            ExtentReporting.EndReporting("Ending test", browser.GetScreenShot());
            driver.Quit();
           
        }
    }
}
