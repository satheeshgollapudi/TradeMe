using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TradeMe.Framework.Base;

namespace TradeMe.UI.Steps.BaseStep
{
    [Binding]
    public class Base : BasePage
    {
        private readonly IWebDriver Driver;
        public Base(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
