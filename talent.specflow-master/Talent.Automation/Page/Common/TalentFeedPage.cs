using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page
{
    public class TalentFeedPage : Base
    {
        private readonly IWebDriver Driver;
        public TalentFeedPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public string TalentFeedPageTitle()
        {
            return Driver.Title;
        }
    }
}
