using Mobiread.Test;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using System.Threading;

namespace Mobiread.Readers.ReadersList
{
    class ReaderList : BasePage
    {
        public ReaderList(IWebDriver driver) : base(driver) { }

        public IWebElement Menu_Readers =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[5]/div[2]/span"));

        public IWebElement SubMenu_ReadersList =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[6]/div/div/div/div[1]/div[2]/span"));

        public IWebElement Username_Filter =>
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/input"));

        public IWebElement Search_Button =>
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[5]/button[2]"));

        public IWebElement Clear_Button =>
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[5]/button[1]"));

        public IWebElement PDASerial_Filter =>
            driver.FindElement(By.Id("«r2c»"));

        public void ViewReadersList(string usernameValue, string pdaSerialValue)
        {
            Thread.Sleep(1000);
            Menu_Readers.Click();

            Thread.Sleep(200);
            SubMenu_ReadersList.Click();

            Thread.Sleep(2000);

            Username_Filter.Clear();
            Thread.Sleep(200);
            Username_Filter.SendKeys(usernameValue);

            Thread.Sleep(500);
            Search_Button.Click();

            Thread.Sleep(2000);

            var rows = driver.FindElements(By.XPath("//table/tbody/tr"));
            bool containsUsername = rows.Any(r => r.Text.Contains(usernameValue));

            Assert.That(containsUsername, Is.True,
                $"Tabela nuk përmban të dhëna që përmbajnë username: {usernameValue}");

            PDASerial_Filter.Clear();
            Thread.Sleep(200);
            PDASerial_Filter.SendKeys(pdaSerialValue);

            Thread.Sleep(500);
            Search_Button.Click();

            Thread.Sleep(2000);

            
            var noDataMessage = driver.FindElement(By.XPath("//*[contains(text(),'No records found')]"));

            Assert.That(noDataMessage.Displayed,
                "Tabela duhet të shfaqë mesazhin 'No records found' kur filtrat nuk kthejnë rezultate.");

            Thread.Sleep(1000);
            Clear_Button.Click();

        }
        public void ExportReadersList()
        {
            Thread.Sleep(2000);

            IWebElement ExportButton = driver
                .FindElements(By.XPath("/html/body/div[1]/div/div[2]/div[1]/header/div/div[1]/button"))
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
                .FindElements(By.XPath("/html/body/div[3]/div[3]/div/div[2]/button[2]"))
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

    