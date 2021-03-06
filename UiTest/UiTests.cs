﻿using AutomationTest.Core;
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
        /// <summary>
        /// This test perform a buy in the Demo CS Cart Store, using the Happy Path
        /// </summary>
        [Test]
        public void BasicNavigation()
        {
            startPage.GoToUrl();
            startPage.PerformSearch("100g pants");           
            startPage.BuyItem();
            startPage.CheckSuccessMessage().Should().BeTrue("Success message not displayed, Test failed.");
        }
    }
}
