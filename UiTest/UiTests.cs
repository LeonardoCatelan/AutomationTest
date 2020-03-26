using AutomationTest.Core;
using AutomationTest.UiTest.Pages;
using FluentAssertions;
using NUnit.Framework;


namespace AutomationTest.UiTest
{
    [TestFixture]
    public class UiTests
    {
        DemoCsStartPage startPage;
        [SetUp]
        public void BaseSetUp()
        {
            WebDriver.StartDriver();
            startPage = new DemoCsStartPage();
        }
        [TearDown]
        public void BaseTearDown()
        {
            WebDriver.CloseDriver();
        }
        [Test]
        public void BasicNavigation()
        {
            startPage.GoToUrl();
            startPage.PerformSearch("T-Shirt");
            startPage.BuyItem();
            startPage.CheckSuccessMessage().Should().BeTrue("Message not displayed");
        }
    }
}
