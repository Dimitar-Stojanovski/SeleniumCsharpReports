using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpReports.Helpers
{
    public interface IGenericMethods
    {
        IWebElement findElement(By _locator);
        IList<IWebElement> findElements(By _locator, int index);
        string getTextFromElement(By _locator);
        bool isElementPresent(By _locator);
    }
}
