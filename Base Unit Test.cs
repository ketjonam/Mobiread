using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.IO;


namespace Mobiread.Test
{
    public class BaseUnitTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("window-size=1920,1080");

            driver = new EdgeDriver(options);

            driver.Manage().Window.Maximize();
        }

        public void OpenBrowser(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void EndTest()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}