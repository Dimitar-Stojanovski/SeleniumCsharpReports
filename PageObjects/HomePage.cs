using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCsharpReports.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpReports.PageObjects
{
    public class HomePage:GenericMethods
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private By _createAccountBtn = By.XPath("//*[@class='panel wrapper']/div/ul/li[2]/a");
        

        public HomePage(IWebDriver driver, WebDriverWait wait):base(driver,wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void ClickCreateAccountBtn()
        {
            findElement(_createAccountBtn);
        }
    }
}
