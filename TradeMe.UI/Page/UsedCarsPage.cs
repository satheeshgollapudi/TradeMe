using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Talent.Automation.Steps.BaseStep;
using TradeMe.Framework.Extensions;
using TradeMe.UI.Steps.BaseStep;

namespace TradeMe.UI.Page
{
    class UsedCarsPage : Base
    {
        private readonly IWebDriver Driver;
        // private readonly ExcelData CreateArticle;
        public UsedCarsPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            //ExcelUtil.SetDataSource("motors.xlsx");
            // CreateArticle = ExcelUtil.DataSet.SelectSheet("Used Cars").GetRowByKey("cars");

        }

        private IList<IWebElement> UsedCarsListing => Driver.WaitForElements(By.XPath(" //td[starts-with(@class,'make_item')]/a"));
        private IWebElement UsedCars => Driver.WaitForDisplayed(By.XPath("//h1[@class = 'landing-header motors-heading-used-cars']"));
        public Boolean MakeExists(string make)
        {          
            string title = UsedCars.Text;
            if(title == "Used cars")
            {
                Console.WriteLine("Used Cars page displayed");
            }
            string listing = make;  
            foreach (var chooseMake in UsedCarsListing)
            {
                string A = chooseMake.Text;
                if (A==listing)
                {
                    Console.WriteLine("make :" + listing + "exists");
                    return true;                   
                }
            }
            Console.WriteLine("make :" + listing + " does not exists");
            return false;
            }
        }
    }



    

