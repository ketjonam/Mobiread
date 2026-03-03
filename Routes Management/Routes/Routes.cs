using NUnit.Framework;
using Mobiread.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiread.Routes_Management.Routes
{
    class Routes : BasePage
    {
        public Routes(IWebDriver driver) : base(driver) { }

        public IWebElement Menu_RouteManagement =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[2]/div[2]/span"));
        public IWebElement SubMenu_Routes =>
                driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[3]/div/div/div/div[1]/div[2]/span"));

        public void ViewRoutes()
        {
            Thread.Sleep(1000);
            Menu_RouteManagement.Click();
            Thread.Sleep(200);
            SubMenu_Routes.Click();
        }

        public void CloseRoutes()
        {
            Thread.Sleep(2000);

            IWebElement SelectRow = driver
                .FindElements(By.XPath("//table/tbody/tr[1]"))
                .FirstOrDefault();

            if (SelectRow == null)
                throw new NoSuchElementException("Table row not found.");

            SelectRow.Click();

            Thread.Sleep(1500);

            IWebElement CloseButton = driver
                .FindElements(By.XPath("/html/body/div/div/div[2]/div[1]/header/div/div[1]/button[3]"))
                .FirstOrDefault();

            if (CloseButton == null)
            {
                CloseButton = driver
                    .FindElements(By.XPath("//button[contains(normalize-space(.),'Close')]"))
                    .FirstOrDefault();
            }

            if (CloseButton == null)
                throw new NoSuchElementException("Close button not found.");

            CloseButton.Click();

            Thread.Sleep(2000);

            IWebElement ConfirmClose = driver
                .FindElements(By.XPath("//html/body/div[2]/div[3]/div/div[2]/button[2]"))
                .FirstOrDefault();

            if (ConfirmClose == null)
            {
                ConfirmClose = driver
                    .FindElements(By.XPath("//*[@role='dialog']//button[2]"))
                    .FirstOrDefault();
            }

            if (ConfirmClose == null)
            {
                ConfirmClose = driver
                    .FindElements(By.XPath("//*[@role='dialog']//button[contains(normalize-space(.),'Confirm') or contains(normalize-space(.),'Close')]"))
                    .FirstOrDefault();
            }

            if (ConfirmClose == null)
                throw new NoSuchElementException("Confirm close button not found.");

            ConfirmClose.Click();

            Thread.Sleep(2000);
        }

        public void ExportRoutes()
        {
            Thread.Sleep(2000);

            IWebElement ExportButton = driver
                .FindElements(By.XPath("/html/body/div[1]/div/div[2]/div[1]/header/div/div[1]/button[1]"))
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

        public void ResetRoutes()
        {
            Thread.Sleep(2000);

            IWebElement SelectRow = driver.FindElement(By.XPath("//table/tbody/tr[1]"));
            SelectRow.Click();

            IWebElement ResetButton = driver
                .FindElements(By.XPath("/html/body/div[1]/div/div[2]/div[1]/header/div/div[1]/button[2]"))
                .FirstOrDefault();

            if (ResetButton == null)
            {
                ResetButton = driver
                    .FindElements(By.XPath("//button[contains(normalize-space(.),'Reset')]"))
                    .FirstOrDefault();
            }

            if (ResetButton == null)
                throw new NoSuchElementException("Reset button not found.");

            ResetButton.Click();

            Thread.Sleep(2000);

            IWebElement ConfirmReset = driver
                .FindElements(By.XPath("/html/body/div[3]/div[3]/div/div[2]/button[2]"))
                .FirstOrDefault();

            if (ConfirmReset == null)
            {
                ConfirmReset = driver
                    .FindElements(By.XPath("//*[@role='dialog']//button[2]"))
                    .FirstOrDefault();
            }

            if (ConfirmReset == null)
            {
                ConfirmReset = driver
                    .FindElements(By.XPath("//button[contains(normalize-space(.),'Confirm') or contains(normalize-space(.),'Reset')]"))
                    .FirstOrDefault();
            }

            if (ConfirmReset == null)
                throw new NoSuchElementException("Confirm reset button not found.");

            ConfirmReset.Click();

            Thread.Sleep(2000);
        }

        public void SelectZoneFilter(string optionText)
        {
            Thread.Sleep(1500);

            // Gjej input me placeholder "Zone"
            IWebElement input = driver.FindElement(
                By.XPath("//input[@placeholder='Zone' and @role='combobox']")
            );

            input.Click();
            Thread.Sleep(800);

            input.Clear();
            Thread.Sleep(200);

            input.SendKeys(optionText);
            Thread.Sleep(1200);


            IWebElement option = driver.FindElement(
                By.XPath($"//*[@role='listbox']//*[normalize-space()='{optionText}']")
            );

            option.Click();
            Thread.Sleep(1500);
            IWebElement ApplyFilterButton = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[5]/button[2]"));
            ApplyFilterButton.Click();
        }
        public void SelectRoutesFilter(string optionText)
        {
            Thread.Sleep(1500);

            IWebElement input = driver.FindElement(
                By.XPath("//input[@placeholder='Routes' and @role='combobox']")
            );

            input.Click();
            Thread.Sleep(800);

            input.Clear();
            Thread.Sleep(200);

            input.SendKeys(optionText);
            Thread.Sleep(1200);

            IWebElement option = driver.FindElement(
                By.XPath($"//*[@role='listbox']//*[normalize-space()='{optionText}']")
            );

            option.Click();
            Thread.Sleep(1500);

            IWebElement ApplyFilterButton = driver.FindElement(
                By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div/div[5]/button[2]")
            );

            ApplyFilterButton.Click();
            Thread.Sleep(3000);

            // ===== ASSERT =====

            var rows = driver.FindElements(By.XPath("//table/tbody/tr"));

            bool containsFilteredValue = rows.Any(r => r.Text.Contains(optionText));

            Assert.That(containsFilteredValue,
                $"Tabela nuk përmban vlerën e filtruar: {optionText}");
        }
    }
}
