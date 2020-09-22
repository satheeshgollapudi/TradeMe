using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TradeMe.Framework.Config;
using TradeMe.Framework.Extensions;
using TradeMe.UI.Steps.BaseStep;

namespace Talent.Automation.Steps.BaseStep
{
    [Binding]
    public class NavigationSteps : Base
    {
        private readonly IWebDriver Driver;

        public NavigationSteps(IWebDriver driver) : base(driver)
        {
            Driver = driver;
           
        }

        [Given(@"I navigate to '(.*)' page")]
        public void GivenINavigateToPage(string page)
        {
            switch (page)
            {
                case "Trademe Home page":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT));
                    Driver.WaitForPageLoaded("motors");
                    break;

                case "motors page":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "motors"));
                    Driver.WaitForPageLoaded("motors");
                    break;

                case "used cars page":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "motors/used-cars"));
                    Driver.WaitForPageLoaded("used-cars");
                    break;


            }
        }

    }
}