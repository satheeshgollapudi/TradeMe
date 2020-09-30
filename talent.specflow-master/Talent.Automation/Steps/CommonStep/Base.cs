using MVPStudio.Framework.Base;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps.BaseStep
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
