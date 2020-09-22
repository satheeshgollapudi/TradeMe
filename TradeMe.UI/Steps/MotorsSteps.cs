using NUnit.Framework;
using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;
using TradeMe.UI.Page.Trademe;
using TradeMe.UI.Steps.BaseStep;

namespace TradeMe.UI.Steps
{
    [Binding]
    public class MotorsSteps : Base
    {

        private readonly IWebDriver Driver;

        public MotorsSteps(IWebDriver driver) : base(driver)
        {
            Driver = driver;

        }


        [Given(@"I am on motors page")]
        public void GivenIAmOnMotorsPage()
        {
            CurrentPage = GetInstance<MotorsPage>(Driver);
        }

        [Given(@"I click on Cars for sale")]
        public void GivenIClickOnCarsForSale()
        {
            CurrentPage.As<MotorsPage>().ChooseUsedCarsListing();
        }

        [Given(@"I click on motor bikes for sale")]
        public void GivenIClickOnMotorBikesForSale()
        {
            CurrentPage.As<MotorsPage>().ClickMotorbikes();
        }

        [Given(@"I click on Nissan")]
        public void GivenIClickOnNissan()
        {
            CurrentPage.As<MotorsPage>().ClickNissan();
        }


        [Given(@"I click on Tourers")]
        public void GivenIClickOnTourers()
        {
            CurrentPage.As<MotorsPage>().ClickTourers();
        }

        [Given(@"I click on Nissan details button")]
        public void GivenIClickOnNissanDetailsButton()
        {
            CurrentPage.As<MotorsPage>().ClickNissanDetails();
        }


        [Given(@"I click on Tourers details button")]
        public void GivenIClickOnTourersDetailsButton()
        {
            CurrentPage.As<MotorsPage>().ClickTourersDetails();
        }

        [Then(@"Details are displayed")]
        public void ThenDetailsAreDisplayed()
        {
            CurrentPage.As<MotorsPage>().VerifyKeyDetails();
        }

        [Then(@"Check there is at least one listing in the TradeMe UsedCars category")]
        public void ThenCheckThereIsAtLeastOneListingInTheTradeMeUsedCarsCategory()
        {
            Assert.IsTrue(CurrentPage.As<MotorsPage>().VerifyAtleastOneListingPresent());
        }

    }
}
