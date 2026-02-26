using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Mobiread.Test
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        protected BasePage()
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");

            driver = new EdgeDriver(options);
        }

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
