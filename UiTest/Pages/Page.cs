using System;
using System.Collections.Generic;
using System.Text;
using AutomationTest.Core;

namespace AutomationTest.UiTest.Pages
{
    public abstract class Page:WebDriver
    {
        public string url;
        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
