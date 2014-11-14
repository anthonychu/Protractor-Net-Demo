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

        IWebDriver driver;
        NgWebDriver ngDriver;

        [SetUp]
        public void Setup()
        {
            driver  = new ChromeDriver();
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            ngDriver = new NgWebDriver(driver);
        }

        [Test]
        public void Basic_Homepage_ShouldHaveATitle()
        {
            ngDriver.Url = URL;
            var title = ngDriver.Title;
            title.Should().Be("Super Calculator");
        }

        [Test]
        public void Basic_AddOneAndTwo_ShouldBeThree()
        {
            ngDriver.Url = URL;
            var first = ngDriver.FindElement(NgBy.Input("first"));
            var second = ngDriver.FindElement(NgBy.Input("second"));
            var goButton = ngDriver.FindElement(By.Id("gobutton"));

            first.SendKeys("1");
            second.SendKeys("2");
            goButton.Click();
            var latestResult = ngDriver.FindElement(NgBy.Binding("latest")).Text;

            latestResult.Should().Be("3");
        }

        [TearDown]
        public void Teardown()
        {
            ngDriver.Quit();
        }
    }
}
