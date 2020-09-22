using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;
using TradeMe.UI.Steps.BaseStep;

namespace TradeMe.UI.Page.Trademe
{
    class TrademeHomePage : Base
    {

        private readonly IWebDriver Driver;

        public TrademeHomePage(IWebDriver driver) : base(driver)
        {
            Driver = driver;

        }
    }
       
}

