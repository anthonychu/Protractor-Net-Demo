using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor_Net_Demo.Pages;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace Protractor_Net_Demo.SuperCalculatorSpecs
{
    [Binding]
    public class SimpleMathSteps
    {
        const string URL = "http://juliemr.github.io/protractor-demo/";

        IWebDriver driver;
        SuperCalculatorPage page;

        [Before]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
        }

        [Given(@"I have a new calculator")]
        public void GivenIHaveANewCalculator()
        {
            page = new SuperCalculatorPage(driver, URL);
        }

        [When(@"I add (.*) and (.*)")]
        public void WhenWhenIAddAnd(string first, string second)
        {
            page.Add(first, second);
        }

        [When(@"I divide (.*) by (.*)")]
        public void WhenIDivideBy(string first, string second)
        {
            page.Divide(first, second);
        }

        [Then(@"the latest result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            page.LatestResult.Should().Be(expectedResult);
        }

        [After]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
