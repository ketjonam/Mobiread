using Mobiread.Test;
using Mobiread.Test.RoutesAssgnTests;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V143.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiread.Anomalies
{
    class Anomaly : BasePage
    {
        public Anomaly(IWebDriver driver) : base(driver) { }
        public IWebElement Menu_Anomalies =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[11]/div[2]/span"));
        public IWebElement SubMenu_Anomaly =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[12]/div/div/div/div[1]/div[2]/span"));
        public IWebElement AddButton =>
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/header/div/div[1]/button[2]"));
        public IWebElement AnomalyCode =>
            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[1]/div/input"));
        public IWebElement AnomalyName => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[2]/div/input"));
        public IWebElement AnomalyDescription => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[4]/div/input"));
        public IWebElement Parent => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[1]"));
        public IWebElement AddAnomalyButton => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]"));

        public void AnomalyAdd()
        {
            Thread.Sleep(1000);
            Menu_Anomalies.Click();
            Thread.Sleep(500);
            SubMenu_Anomaly.Click();
            Thread.Sleep(2000);

        }
        public void AddAnomalywithSameName()
        {
            AddButton.Click();
            Thread.Sleep(1500);
            AnomalyCode.SendKeys("001");
            Thread.Sleep(1500);
            AnomalyName.SendKeys("test");
            Thread.Sleep(1500);
            AnomalyDescription.SendKeys("test");
            Thread.Sleep(1500);
            AddAnomalyButton.Click();
            Thread.Sleep(2000);

            IWebElement toastMessage = driver.FindElement(
    By.XPath("//div[@id='toast-container']//div[contains(@class,'toast-message')]"));

            Assert.That(toastMessage.Text,
                Is.EqualTo("A duplicate anomaly name was found."));
        }

        public void AddSubAnomaly()
        {
            Thread.Sleep(1000);
            AddButton.Click();
            Thread.Sleep(1500);
            AnomalyCode.SendKeys("431");
            Thread.Sleep(1500);
            AnomalyName.SendKeys("test-sub1");
            Thread.Sleep(15000);
            IWebElement input = driver.FindElement(By.XPath("//input[@role='combobox']"));

            input.Click();
            Thread.Sleep(500);

            string optionText = "rast pa lexim";
            input.SendKeys(optionText);
            Thread.Sleep(1200);

            IWebElement option = driver.FindElement(By.XPath($"//*[@role='listbox']//*[normalize-space()='{optionText}']"));
            option.Click();

            Thread.Sleep(1500);
            Thread.Sleep(1500);
            AnomalyDescription.SendKeys("test-sub1");
            Thread.Sleep(1500);
            AddAnomalyButton.Click();
        }
        public void ExportAnomalyList()
        {
            Thread.Sleep(2000);

            IWebElement ExportButton = driver
                .FindElements(By.XPath("/html/body/div/div/div[2]/div[1]/header/div/div[1]/button[1]"))
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
        public void DeleteAnomaly()
        {
            Thread.Sleep(2000);
            IWebElement ParentAnomalyClick = driver.FindElement(By.XPath("//table/tbody/tr[1]//*[name()='svg'][1]"));
            ParentAnomalyClick.Click();
            IWebElement DeleteButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div[2]/div[1]/table/tbody/tr[4]/td[4]/div/button[2]"));
            DeleteButton.Click();
            Thread.Sleep(1500);

            IWebElement ConfirmDeleteButton = null;

            try
            {
                ConfirmDeleteButton = driver.FindElement(By.XPath("//button[normalize-space()='Delete']"));
            }
            catch { }

            if (ConfirmDeleteButton == null)
            {
                try
                {
                    ConfirmDeleteButton = driver.FindElement(By.XPath("//div[contains(@class,'MuiDialogActions-root')]//button[normalize-space()='Delete']"));
                }
                catch { }
            }

            if (ConfirmDeleteButton == null)
            {
                try
                {
                    ConfirmDeleteButton = driver.FindElement(By.XPath("//button[contains(text(),'Delete')]"));
                }
                catch { }
            }

            if (ConfirmDeleteButton == null)
            {
                try
                {
                    ConfirmDeleteButton = driver.FindElement(By.XPath("//div[@role='dialog']//button[2]"));
                }
                catch { }
            }

            if (ConfirmDeleteButton == null)
            {
                throw new NoSuchElementException("Delete button nuk u gjet në modal.");
            }

            ConfirmDeleteButton.Click();
            Thread.Sleep(2000);
            IWebElement toastMessage = driver.FindElement(By.XPath("//div[@id='toast-container']//div[contains(@class,'toast-message')]"));
            Assert.That(toastMessage.Text, Is.EqualTo("Anomaly deleted successfully"));
        }
        public void EditAnomaly()
        {
            Thread.Sleep(2000);
            IWebElement ParentAnomalyClick = driver.FindElement(By.XPath("//table/tbody/tr[1]//*[name()='svg'][1]"));
            ParentAnomalyClick.Click();
            IWebElement EditButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div[2]/div[1]/table/tbody/tr[4]/td[4]/div/button[1]"));
            EditButton.Click();
            Thread.Sleep(1500);
            AnomalyName.Clear();
            Thread.Sleep(500);
            AnomalyName.SendKeys("test-edited");
            Thread.Sleep(1500);
            Thread.Sleep(2000);

            IWebElement SaveButton = null;

            try
            {
                SaveButton = driver.FindElement(By.XPath("//button[normalize-space()='Save']"));
            }
            catch { }

            if (SaveButton == null)
            {
                SaveButton = driver.FindElement(By.XPath("//button[contains(text(),'Save')]"));
            }

            SaveButton.Click();
            
        }
        public void FilterAnomalies(string filterText)
        {
            Thread.Sleep(2000);
            IWebElement CodeFilter = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div/div[1]/div/div[1]/div/div/input"));
            CodeFilter.SendKeys("Test");
            Thread.Sleep(500);
            IWebElement NameFilter = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div/div[1]/div/div[2]/div/div/input"));
            NameFilter.SendKeys("Test");
            Thread.Sleep(200);
            IWebElement DescriptionFilter = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div/div[1]/div/div[3]/div/div/input"));
            DescriptionFilter.SendKeys("Test");
            IWebElement SearchButton = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div/div[1]/div/div[4]/button[2]"));
            SearchButton.Click();

            Thread.Sleep(2000);
            var noDataMessage = driver.FindElement(By.XPath("//*[contains(text(),'No records found')]"));

            Assert.That(noDataMessage.Displayed,
                "Tabela duhet të shfaqë mesazhin 'No records found' kur filtrat nuk kthejnë rezultate.");
            
            Thread.Sleep(2500);

            IWebElement ClearButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div[1]/div/div[4]/button[1]"));
            ClearButton.Click();

           CodeFilter.SendKeys("001");
           NameFilter.SendKeys("Rast pa lexim");
           SearchButton.Click();
           
            Thread.Sleep(2000); 
            var rows = driver.FindElements(By.XPath("//table/tbody/tr"));
           bool containsUsername = rows.Any(r => r.Text.Contains("rast pa lexim"));

           Assert.That(containsUsername, Is.True
                //$"Tabela nuk përmban të dhëna që përmbajnë username: rast pa lexim"));
           );
        }
    }
}
