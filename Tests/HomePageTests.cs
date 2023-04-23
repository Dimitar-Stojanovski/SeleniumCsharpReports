using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCsharpReports.Tests
{
    public class HomePageTests:BaseTest
    {
        [Test]
        public void ClickOnCreateAccountBtn()
        {
            homePage.ClickCreateAccountBtn();
            
        }
    }
}
