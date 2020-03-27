using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationTest.UiTest.Pages
{
    public class DemoCsStartPage : Page
    {
        #region selectors
        IWebElement searchBox;
        IWebElement magnify;
        IWebElement adidasTShirt;
        IWebElement addToCart;
        IWebElement checkout;
        IWebElement phoneOrdering;
        private By searchboxSelector = By.Id("search_input");
        private By magnifySelector = By.CssSelector("[title='Search']");
        private By resultsSelector = By.ClassName("ty-mainbox-title");
        private By adidasTShirtSelector = By.Id("det_img_11");
        private By addToCartSelector = By.Id("button_cart_11");
        private By checkoutSelector = By.CssSelector(".ty-btn.ty-btn__primary.cm-notification-close");
        private By greenMessage = By.CssSelector(".cm-notification-content.notification-content.cm-auto-hide.alert-success");
        private By phoneOrderingSelector = By.Id("radio_2");
        //private string phoneOrderingSelector = ".radio_2";
        private string adressSelector = "#litecheckout_s_address";
        private string zipSelector = "#litecheckout_s_zipcode";
        private string emailSelector = "#litecheckout_email";
        private string acceptTermsSelector = ".cm-agreement.checkbox";
        private string formSelector = "#litecheckout_payments_form";
        #endregion

        private void TypeOnElement(string selector, string data)
        {
            string code = $"document.querySelector('{selector}').value = '{data}'";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(code);
        }

        private void CheckElement(string selector, bool flag)
        {
            string code = $"document.querySelector('{selector}').checked = '{flag}'";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(code);
        }

        public void PerformSearch(string text)
        {
            searchBox = wait.Until(ExpectedConditions.ElementToBeClickable(searchboxSelector));
            magnify = wait.Until(ExpectedConditions.ElementToBeClickable(magnifySelector));
            searchBox.SendKeys(text);
            magnify.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(resultsSelector));
        }

        public void SubmitForm(string form)
        {
            string code = $"document.querySelector('{form}').submit()";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(code);
        }

        public bool CheckSuccessMessage()
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(greenMessage));
            return element.Displayed;
        }

        private void ClickElement()
        {
            string code = "arguments[0].click();";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(code, phoneOrdering);
        }

        public void SetZoom(int number)
        {
            string code = $"document.body.style.zoom='{number}%';";
            phoneOrdering = wait.Until(ExpectedConditions.ElementExists(phoneOrderingSelector));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(code);
        }



        public void BuyItem()
        {
            adidasTShirt = wait.Until(ExpectedConditions.ElementToBeClickable(adidasTShirtSelector));
            adidasTShirt.Click();
            addToCart = wait.Until(ExpectedConditions.ElementToBeClickable(addToCartSelector));
            addToCart.Click();
            checkout = wait.Until(ExpectedConditions.ElementToBeClickable(checkoutSelector));
            checkout.Click();

            //string code = "arguments[0].click();document.body.style.zoom='30%';";
            //phoneOrdering = wait.Until(ExpectedConditions.ElementExists(phoneOrderingSelector)); 
            //Criar método pro clique e criar um método pro zoom.
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver; js.ExecuteScript(code, phoneOrdering);
            SetZoom(30);
            ClickElement();
            TypeOnElement(adressSelector, "Avenue Robson");
            TypeOnElement(zipSelector, "12345");
            TypeOnElement(emailSelector, "randomemail@hotmail.com");
            CheckElement(acceptTermsSelector, true);
            SubmitForm(formSelector);
        }
        public DemoCsStartPage()
        {
            url = "http://demo.cs-cart.com/";
        }
    }
}
