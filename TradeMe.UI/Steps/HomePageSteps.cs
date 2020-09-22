using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TradeMe.UI.Page.Trademe;
using TradeMe.UI.Steps.BaseStep;

namespace TradeMeUI.Steps
{
    public class HomePageSteps : Base
    {
        private readonly IWebDriver Driver;
        private readonly ScenarioContext context;

        public HomePageSteps(IWebDriver driver, ScenarioContext injectedContext) : base(driver)
        {
            this.Driver = driver;
            context = injectedContext;
        }

       

        [Given(@"I am on Trademe Home page")]
        public void GivenIAmOnTrademeHomePage()
        {
            CurrentPage = GetInstance<TrademeHomePage>(Driver);
        }


      



    }
}
