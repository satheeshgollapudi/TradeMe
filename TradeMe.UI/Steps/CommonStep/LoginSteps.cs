using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TradeMe.Framework.Config;
using TradeMe.UI.Steps.BaseStep;

namespace Talent.Automation.Steps
{
    [Binding]
    public class LoginSteps : Base
    {
        private readonly IWebDriver Driver;
        public LoginSteps(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

       

        [Given(@"I login")]
        public void GivenILogin()
        {
            try
            {
               
                Driver.Navigate().GoToUrl(new Uri(Settings.AUT));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }

    

