using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace AutomationTest.UiTest.Pages
{
    public class DemoCsStartPage : Page
    {
        #region selectors
        private string searchboxSelector = "#search_input";
        private string magnifySelector = "[title='Search']";
        private string adidasTShirtSelector = ".ty-grid-list__image>a";
        private string addToCartSelector = "#button_cart_12";
        private string checkoutSelector = ".ty-btn.ty-btn__primary.cm-notification-close";
        private string phoneOrderingSelector = "#radio_2";
        private string adressSelector = "#litecheckout_s_address";
        private string zipSelector = "#litecheckout_s_zipcode";
        private string emailSelector = "#litecheckout_email";
        private string acceptTermsSelector = ".cm-agreement.checkbox";
        private string formSelector = "#litecheckout_payments_form";
        private By greenMessage = By.CssSelector(".cm-notification-content.notification-content.cm-auto-hide.alert-success");
        #endregion

        public void PerformSearch(string text)
        {
            SetZoom(50);
            TypeOnElement(searchboxSelector, "100g pants");
            ClickElement(magnifySelector);
            Console.WriteLine("Search Performed successfully");
        }
        public void BuyItem()
        {
            SetZoom(50);
            ClickElement(adidasTShirtSelector);
            ClickElement(addToCartSelector);
            ClickElement(checkoutSelector);
            SetZoom(25);
            ClickElement(phoneOrderingSelector);
            TypeOnElement(adressSelector, "Avenue Robson");
            TypeOnElement(zipSelector, "12345");
            TypeOnElement(emailSelector, "randomemail@hotmail.com");
            CheckElement(acceptTermsSelector, true);
            SubmitForm(formSelector);
            Thread.Sleep(2000);
            Console.WriteLine("Perform buy success");
        }


        private void TypeOnElement(string selector, string data)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    string code = $"document.querySelector('{selector}').value = '{data}'";
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript(code);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("unable to type");
                    Thread.Sleep(5000);
                    if (i == 5)
                        Assert.Fail("Failed to type on element");
                }
            }
        }

        private void CheckElement(string selector, bool flag)
        {
            string code = $"document.querySelector('{selector}').checked = '{flag}'";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(code);
        }



        public void SubmitForm(string form)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    string code = $"document.querySelector('{form}').submit()";
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript(code);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("unable to submit");
                    Thread.Sleep(5000);
                    if (i == 5)
                        Assert.Fail("Failed to submit form");
                }
            }
        }

        public bool CheckSuccessMessage()
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(greenMessage));
            return element.Displayed;
        }

        private void ClickElement(string element)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    string code = $"document.querySelector(\"{element}\").click()";
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript(code, element);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("unable to click");
                    Thread.Sleep(5000);
                    if (i == 5)
                        Assert.Fail("Failed to click");
                }
            }
        }
        public void SetZoom(int number)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    string code = $"document.body.style.zoom='{number}%';";
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript(code);
                    Thread.Sleep(3000);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("page isn't loaded");
                    Thread.Sleep(5000);
                    if (i == 5)
                        Assert.Fail("Failed to adjust the zoom.");
                }
            }


        }
        public DemoCsStartPage()
        {
            url = "http://demo.cs-cart.com/";
        }
    }
}
