using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using FluentAssertions;

namespace Protractor_Net_Demo
{
    [TestFixture]
    public class BasicTests
    {
        const string URL = "http://juliemr.github.io/protractor-demo/";

        IWebDriver _driver;
        NgWebDriver _ngDriver;

        [SetUp]
        public void Setup()
        {
            _driver  = new ChromeDriver();
            _driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            _ngDriver = new NgWebDriver(_driver);
        }

        [Test]
        public void Basic_Homepage_ShouldHaveATitle()
        {
            _ngDriver.Url = URL;
            var title = _ngDriver.Title;
            title.Should().Be("Super Calculator");
        }

        [Test]
        public void Basic_AddOneAndTwo_ShouldBeThree()
        {
            _ngDriver.Url = URL;
            var first = _ngDriver.FindElement(NgBy.Input("first"));
            var second = _ngDriver.FindElement(NgBy.Input("second"));
            var goButton = _ngDriver.FindElement(By.Id("gobutton"));

            first.SendKeys("1");
            second.SendKeys("2");
            goButton.Click();
            var latestResult = _ngDriver.FindElement(NgBy.Binding("latest")).Text;

            latestResult.Should().Be("3");
        }

        [TearDown]
        public void Teardown()
        {
            _ngDriver.Quit();
        }
    }
}
