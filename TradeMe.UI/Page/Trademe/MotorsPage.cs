using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Talent.Automation.Steps.BaseStep;
using TradeMe.Framework.Extensions;
using TradeMe.Framework.Helps.Excel;
using TradeMe.UI.Steps.BaseStep;

namespace TradeMe.UI.Page.Trademe
{
    class MotorsPage :Base
    {
        private readonly IWebDriver Driver;
       // private readonly ExcelData CreateArticle;
        public MotorsPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            ExcelUtil.SetDataSource("motors.xlsx");
           // CreateArticle = ExcelUtil.DataSet.SelectSheet("Used Cars").GetRowByKey("X");

        }

        private IWebElement Cars => Driver.WaitForElement(By.XPath("//a[contains(text(),'Cars for sale')]"));
        private IWebElement MotorBike => Driver.WaitForElement(By.XPath("//a[contains(text(),'Motorbikes for sale')]"));
        private IList<IWebElement> Cards => Driver.FindElements(By.XPath("//table[@class='limited']/tbody/tr/td[2]/div"));

        private IWebElement Nissan => Driver.WaitForElement(By.XPath("//a[contains(text(),'Nissan')]"));
        private IWebElement Tourers => Driver.WaitForElement(By.XPath("//a[contains(text(),'Tourers')]"));

        private IWebElement NissanDetailsButton => Driver.WaitForElement(By.XPath("//span[@class='tmm-search-card-list-view__profile-nickname']"));

        private IWebElement TourersDetailsButton => Driver.WaitForElement(By.XPath("//span[@class='tmm-search-card-list-view__profile-nickname']"));

        private IList<IWebElement> UsedCarsListing => Driver.WaitForElements(By.XPath("(//ul[@class='motors-landing-list'])[1]/li[1]/ul/li/a"));

        private IList<IWebElement> MotorbikeListing => Driver.WaitForElements(By.XPath("(//ul[@class='motors-landing-list'])[2]/li[1]/ul/li/a"));

        private IList<IWebElement> KeyDetails => Driver.WaitForElements(By.XPath("//div[@id = 'AttributesDisplay_attributesSection']/ul/li"));
        public string MotorsPageTitle()
        {
            return Driver.Title;
        }

        public void ClickCars()
        {
            Cars.Click();
           
        }

        public void ChooseUsedCarsListing()
        {
            foreach (var chooselisting in UsedCarsListing)
            {
                string listing = "Cars for sale";

                string A = chooselisting.Text;
                if (A == listing)
                {
                    
                    IWebElement ClickListingLink = Driver.FindElement(By.XPath("//a[contains(text(),'" + listing + "')]"));

                    ClickListingLink.Click();
                    break;
                }
            }
        }
        public void ClickMotorbikes()
        {
            MotorBike.Click();
        }

        public void ChooseMotorbikesListing()
        {
            foreach (var chooselisting in MotorbikeListing)
            {
                string listing = "Motorbikes for sale";

                string brand = chooselisting.Text;
                if (brand == listing)
                {                    
                    IWebElement ClickListingLink = Driver.FindElement(By.XPath("//a[contains(text(),'" + listing + "')]"));
                    ClickListingLink.Click();
                    break;
                }
            }
        }

        public void ClickNissan()
        {
            Nissan.Click();
        }

        public void ClickTourers()
        {
            Tourers.Click();
        }

        public void ClickNissanDetails()
        {
            NissanDetailsButton.Click();
        }

        public void ClickTourersDetails()
        {
            TourersDetailsButton.Click();
        }

        public void VerifyKeyDetails()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

           
            for (int i = 1; i <= KeyDetails.Count; i++)
            {
              
                string key = Driver.FindElement(By.XPath("(//div[@id = 'AttributesDisplay_attributesSection']/ul/li)[" + i + "]/div[@class='key-details-attribute-label']/label")).Text;
                string value = Driver.FindElement(By.XPath("(//div[@id = 'AttributesDisplay_attributesSection']/ul/li)[" + i + "]/div[@class='key-details-attribute-value']/span")).Text;
                keyValuePairs.Add(key, value);
            }
            foreach (var detail in keyValuePairs)
            {
                Console.WriteLine("Detail: " + detail.Key + ", Value: " + detail.Value);
            }          
        }

        public Boolean VerifyAtleastOneListingPresent()
        {
            bool result = false;
            for (int i = 1; i <= UsedCarsListing.Count; i++)
            {
                string Listing = Driver.FindElement(By.XPath("(//ul[@class='motors-landing-list'])[1]/li[1]/ul/li[" + i + "]/span")).Text;
                string TrimmedListing = Listing.Trim('(', ')');
                Console.WriteLine("Ateast one listing present " + TrimmedListing);
                if (Int32.Parse(TrimmedListing) > 0)
                {
                    result = true;
                }
                
            }
            if (!result)
            {
                Console.WriteLine("No listing present");
            }
            return result;
        }
    }


}

