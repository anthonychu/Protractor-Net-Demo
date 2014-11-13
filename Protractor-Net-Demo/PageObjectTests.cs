using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using Protractor_Net_Demo.Pages;

namespace Protractor_Net_Demo
{
    [TestFixture]
    public class PageObjectTests
    {
        const string URL = "http://juliemr.github.io/protractor-demo/";

        IWebDriver _driver;
        SuperCalculatorPage _page;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            _page = new SuperCalculatorPage(_driver, URL);
        }

        [Test]
        public void PageObject_AddOneAndTwo_ShouldBeThree()
        {
            _page.Add("1", "2");
            _page.LatestResult.Should().Be("3");
        }

        [Test]
        public void PageObject_ThreeSubtractOne_ShouldBeTwo()
        {
            _page.Subtract("3", "1");
            _page.LatestResult.Should().Be("2");
        }

        [Test]
        public void PageObject_PerformTwoOperations_ShouldHaveTwoItemsInHistory()
        {
            _page.Add("1", "1");
            _page.Add("1", "1");

            _page.History.Should().HaveCount(2);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
