using Mobiread.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiread.Readers.HistoricalSerialPDA
{
    class HistoricSerialPDA : BasePage
    {
        public HistoricSerialPDA(IWebDriver driver) : base(driver) { }

        public IWebElement Menu_Readers =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[5]/div[2]/span"));
        public IWebElement SubMenu_HistoricalSerialPDA => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[6]/div/div/div/div[4]/div[2]/span"));
        public IWebElement Username_Filter =>
                driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/input"));
        public IWebElement FullName_Filter =>
                driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/input"));
        public IWebElement PDASerial_Filter => driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/input"));
       public IWebElement ZoneCode_Filter =>
                driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[5]/div/div/input"));
        public IWebElement Search_Button =>
                driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[6]/button[2]"));
        public IWebElement Clear_Button =>  driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[6]/button[1]"));

        public void FilterHistoricalSerialPDA(string pdaSerialValue)
        {
            Thread.Sleep(1000);
            Menu_Readers.Click();

            Thread.Sleep(200);
            SubMenu_HistoricalSerialPDA.Click();

            Thread.Sleep(2000);
            Username_Filter.SendKeys("test");
            FullName_Filter.SendKeys("test");   
            PDASerial_Filter.SendKeys("test");
            ZoneCode_Filter.SendKeys("test");

            Search_Button.Click();

            Thread.Sleep(2000);

            var noDataMessage = driver.FindElement(By.XPath("//*[contains(text(),'No records found')]"));

            Assert.That(noDataMessage.Displayed,
                "Tabela duhet të shfaqë mesazhin 'No records found' kur filtrat nuk kthejnë rezultate.");

            Thread.Sleep(500);
            Clear_Button.Click();
        }
        public void ExportHistoricSerialPDA()
        {
            Thread.Sleep(2000);

            IWebElement ExportButton = driver
                .FindElements(By.XPath("/html/body/div/div/div[2]/div[1]/header/div/div[1]/button"))
                .FirstOrDefault();

            if (ExportButton == null)
            {
                ExportButton = driver
                    .FindElements(By.XPath("//button[contains(normalize-space(.),'Export')]"))
                    .FirstOrDefault();
            }

            if (ExportButton == null)
                throw new NoSuchElementException("Export button not found.");

            ExportButton.Click();

            Thread.Sleep(2000);

            IWebElement ExportButtonModal = driver
                .FindElements(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]"))
                .FirstOrDefault();

            if (ExportButtonModal == null)
            {
                ExportButtonModal = driver
                    .FindElements(By.XPath("//*[@role='dialog']//button[2]"))
                    .FirstOrDefault();
            }

            if (ExportButtonModal == null)
            {
                ExportButtonModal = driver
                    .FindElements(By.XPath("//*[@role='dialog']//button[contains(normalize-space(.),'Export')]"))
                    .FirstOrDefault();
            }

            if (ExportButtonModal == null)
                throw new NoSuchElementException("Export modal button not found.");

            ExportButtonModal.Click();

            Thread.Sleep(2000);
        }

    }
}
