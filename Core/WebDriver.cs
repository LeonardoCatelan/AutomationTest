using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTest.Core
{
    public class WebDriver
    {
        public static ChromeDriver driver;
        public static WebDriverWait wait;
        public static void StartDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public static void CloseDriver()
        {
            driver.Quit();
        }
    }
}
