using OpenQA.Selenium;
using System;

namespace MVPStudio.Framework.Base
{
    public class BasePage
    {
        public BasePage CurrentPage { get; set; }

        public TPage GetInstance<TPage>(IWebDriver driver) where TPage : BasePage
        {
            return Activator.CreateInstance(typeof(TPage), driver) as TPage;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}