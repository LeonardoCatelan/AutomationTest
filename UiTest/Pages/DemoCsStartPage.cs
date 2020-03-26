using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTest.UiTest.Pages
{
    public class DemoCsStartPage:Page
    {
        IWebElement searchBox;
        IWebElement magnify;
        IWebElement searchResults;
        IWebElement adidasTShirt;
        private By searchboxSelector = By.Id("search_input");
        private By magnifySelector = By.CssSelector("[title='Search']");
        private By resultsSelector = By.ClassName("ty-mainbox-title");
        private By adidasTShirtSelector = By.Id("det_img_11");

        public void PerformSearch(string text)
        {
            searchBox = wait.Until(ExpectedConditions.ElementToBeClickable(searchboxSelector));
            magnify = wait.Until(ExpectedConditions.ElementToBeClickable(magnifySelector));
            searchBox.SendKeys(text);
            magnify.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(resultsSelector));
            adidasTShirt = wait.Until(ExpectedConditions.ElementToBeClickable(adidasTShirtSelector));
            adidasTShirt.Click();
        }
        
        public DemoCsStartPage()
        {
            url = "http://demo.cs-cart.com/";
        }
    }
}
