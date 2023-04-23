using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCsharpReports.Framework
{
    public class DriverBase
    {
        private  IWebDriver driver;

        public IWebDriver Initiate(string _driverName)
        {
            switch (_driverName)
            {
                case "Chrome":
                   new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break ;
                default:
                    throw new ArgumentException("Driver not recognized");



            }

            return driver;

            
            
        }
    }
}
