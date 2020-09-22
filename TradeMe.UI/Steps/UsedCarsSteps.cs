using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TradeMe.UI.Page;
using TradeMe.UI.Steps.BaseStep;

namespace Talent.Automation.Steps
{
    [Binding]
    class UsedCarsSteps : Base
    {

        private readonly IWebDriver Driver;
        private readonly ScenarioContext context;

        public UsedCarsSteps(IWebDriver driver, ScenarioContext injectedContext) : base(driver)
        {
            this.Driver = driver;
            context = injectedContext;
        }

        [Given(@"I am on used cars page")]
        public void GivenIAmOnUsedCarsPage()
        {
            CurrentPage = GetInstance<UsedCarsPage>(Driver);
        }


        [Then(@"that the make '(.*)' exists")]
        public void ThenThatTheMakeExists(string make)
        {
            Assert.IsTrue(CurrentPage.As<UsedCarsPage>().MakeExists( make));
        }

    }
}