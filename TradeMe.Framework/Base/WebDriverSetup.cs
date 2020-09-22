using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace TradeMe.Framework.Base
{
    public class WebDriverSetup
    {
        private readonly IObjectContainer _objectContainer;
        public IWebDriver Driver { get; set; }

        public WebDriverSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            // to stop the exception "The HTTP request to the remote WebDriver server for URL http://localhost:52847/session/... timed out after 60 seconds.'
            var startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "TradeMe.Framework");
            Driver = new ChromeDriver(startupPath);
            // Driver = new FirefoxDriver(); 
            _objectContainer.RegisterInstanceAs(Driver);
            Driver.Manage().Window.Maximize();
        }
    }
}