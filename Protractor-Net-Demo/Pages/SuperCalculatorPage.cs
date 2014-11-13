using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protractor_Net_Demo.Pages
{
    public class SuperCalculatorPage
    {
        private NgWebDriver _ngDriver;

        public SuperCalculatorPage(IWebDriver driver, string url)
        {
            _ngDriver = new NgWebDriver(driver);
            _ngDriver.Url = url;
        }

        public string LatestResult 
        { 
            get { return _ngDriver.FindElement(NgBy.Binding("latest")).Text; }
        }

        public IEnumerable<SuperCalculatorPageHistory> History
        {
            get { 
                return _ngDriver.FindElements(NgBy.Repeater("result in memory"))
                    .Select(e => new SuperCalculatorPageHistory(e));
            }
        }

        public void Add(string first, string second)
        {
            DoMath(first, second, "+");
        }

        public void Subtract(string first, string second)
        {
            DoMath(first, second, "-");
        }

        private void DoMath(string first, string second, string op)
        {
            SetFirst(first);
            SetSecond(second);
            SetOperator(op);
            ClickGo();
        }

        private void SetFirst(string number)
        {
            var first = _ngDriver.FindElement(NgBy.Input("first"));
            first.Clear();
            first.SendKeys(number);
        }

        private void SetSecond(string number)
        {
            var second = _ngDriver.FindElement(NgBy.Input("second"));
            second.Clear();
            second.SendKeys(number);
        }

        private void SetOperator(string op)
        {
            var operatorSelect = new SelectElement(_ngDriver.FindElement(NgBy.Select("operator")));
            operatorSelect.SelectByText(op);
        }

        private void ClickGo()
        {
            _ngDriver.FindElement(By.Id("gobutton")).Click();
        }

    }

    public class SuperCalculatorPageHistory
    {
        public string Time { get; set; }
        public string Expression { get; set; }
        public string Result { get; set; }

        public SuperCalculatorPageHistory()
        {
        }

        public SuperCalculatorPageHistory(IWebElement element)
        {
            var tds = element.FindElements(By.TagName("td"));
            Time = tds[0].Text;
            Expression = tds[1].Text;
            Result = tds[2].Text;
        }
    }
}
