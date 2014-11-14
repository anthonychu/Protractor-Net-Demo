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

        IWebDriver driver;
        SuperCalculatorPage page;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            page = new SuperCalculatorPage(driver, URL);
        }

        [Test]
        public void PageObject_AddOneAndTwo_ShouldBeThree()
        {
            page.Add("1", "2");
            page.LatestResult.Should().Be("3");
        }

        [Test]
        public void PageObject_ThreeSubtractOne_ShouldBeTwo()
        {
            page.Subtract("3", "1");
            page.LatestResult.Should().Be("2");
        }

        [Test]
        public void PageObject_PerformTwoOperations_ShouldHaveTwoItemsInHistory()
        {
            page.Add("1", "1");
            page.Add("1", "1");

            page.History.Should().HaveCount(2);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
