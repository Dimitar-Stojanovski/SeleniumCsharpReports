using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpReports.Helpers
{
    public class GenericMethods : IGenericMethods
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public GenericMethods(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement findElement(By _locator)
        {
            return wait.Until(x => x.FindElement(_locator));
        }

        public IList<IWebElement> findElements(By _locator, int index)
        {
            var _elements = wait.Until(x => x.FindElements(_locator));
            return _elements;
        }

        public string getTextFromElement(By _locator)
        {
            return findElement(_locator).Text;
        }

        public bool isElementPresent(By _locator)
        {
            return findElement(_locator).Displayed;
        }

       
    }
}
