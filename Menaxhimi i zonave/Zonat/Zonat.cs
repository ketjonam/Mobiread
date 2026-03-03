using OpenQA.Selenium;
using System.Threading;

namespace Mobiread.Test.Zonat
{
    class Zonat : BasePage
    {
        public Zonat(IWebDriver driver) : base(driver) { }

        // ===== MENU =====
        public IWebElement Menu_MenaxhimiZonave =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[1]"));

        public IWebElement Nenmenu_Zonat =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[2]/div/div/div/div[1]"));

        // ===== METHODS (të thjeshta) =====

        public void GoToZonatPage()
        {
            Thread.Sleep(1000);
            Menu_MenaxhimiZonave.Click();

            Thread.Sleep(1000);
            Nenmenu_Zonat.Click();

            Thread.Sleep(5000);
        }

        public void SelectZona(string zona)
        {
            Thread.Sleep(2000);

            // input i autocomplete (si te testi yt)
            IWebElement input = driver.FindElement(By.XPath("//input[@role='combobox']"));
            input.Click();
            Thread.Sleep(500);

            input.Clear();
            Thread.Sleep(200);

            input.SendKeys(zona);
            Thread.Sleep(1500);

            input.SendKeys(Keys.Enter);
            Thread.Sleep(2500);
        }

        public void ExportData()
        {
            Thread.Sleep(2000);

            // Butoni Export (nga HTML që dërgove)
            IWebElement export =
                driver.FindElement(By.CssSelector("button[aria-label='Export data table']"));
            export.Click();

            Thread.Sleep(2000);

            // Checkbox në modal
            IWebElement checkbox =
                driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div/ul/li[3]/div[1]/span/input"));
            checkbox.Click();

            Thread.Sleep(1500);

            // Butoni Export në modal
            IWebElement exportModal =
                driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]"));
            exportModal.Click();

            Thread.Sleep(3000);
        }
    }
}