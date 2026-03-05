using Mobiread.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiread.Devices.AssignVersiontoReaders
{
    class AssignVersion : BasePage
    {
        public AssignVersion(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement Menu_Devices => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[14]/div[2]/span"));
        public IWebElement SubMenu_AssignVersion => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[15]/div/div/div/div[3]/div[2]/span"));
        public IWebElement SelectReader => driver.FindElement(By.XPath("//table/tbody/tr[1]//input[@type='checkbox']"));
        public IWebElement SelectVersion => driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/header/div/div[1]/button[2]"));
        public IWebElement AssignButton => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]"));

        public void AssignVersionToReaders()
        {
            Thread.Sleep(3000);
            Menu_Devices.Click();

            Thread.Sleep(1500);
            SubMenu_AssignVersion.Click();

            Thread.Sleep(3000);
            SelectReader.Click();

            Thread.Sleep(1500);
            SelectVersion.Click();

            Thread.Sleep(2000);

            IWebElement versionInput = driver.FindElement(
                By.XPath("//div[contains(@class,'MuiDialog-container')]//input[@role='combobox' and contains(@class,'MuiAutocomplete-input')]")
            );

            versionInput.Click();
            Thread.Sleep(500);

            versionInput.Clear();
            Thread.Sleep(200);

            versionInput.SendKeys("versioni i ri - 5.0");
            Thread.Sleep(2000);


            try
            {
                IWebElement openBtn = driver.FindElement(By.XPath("//div[contains(@class,'MuiDialog-container')]//button[@aria-label='Open']"));
                openBtn.Click();
                Thread.Sleep(1200);
            }
            catch { }

            IWebElement option = null;

            try { option = driver.FindElement(By.XPath("//*[@role='listbox']//li[1]")); } catch { }
            if (option == null) { try { option = driver.FindElement(By.XPath("//*[@role='listbox']//*[@role='option'][1]")); } catch { } }
            if (option == null) { try { option = driver.FindElement(By.XPath($"//*[@role='listbox']//*[contains(normalize-space(), 'versioni i ri - 5.0')]")); } catch { } }
            if (option == null) { try { option = driver.FindElement(By.XPath("(//ul[contains(@class,'MuiAutocomplete-listbox')]//li)[1]")); } catch { } }

            if (option == null)
                throw new NoSuchElementException("Nuk u gjet asnjë opsion në dropdown (listbox/option).");

            option.Click();
            Thread.Sleep(800);

            AssignButton.Click();
            Thread.Sleep(1500);
        }

        public void ExportAssignedVersions()
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
        public void RunAllFilterScenarios()
        {
            Thread.Sleep(2000);

            IWebElement ReaderInput = driver.FindElement(By.XPath("//input[@placeholder='Reader' and @role='combobox']"));
            IWebElement StatusCombo = driver.FindElement(By.XPath("//label[normalize-space()='Status']/following::div[@role='combobox'][1]"));
            IWebElement ZoneCodeInput = driver.FindElement(By.XPath("//label[normalize-space()='Zone Code']/following::input[@type='text'][1]"));
            IWebElement ZoneInput = driver.FindElement(By.XPath("//input[@placeholder='Zone' and @role='combobox']"));
            IWebElement AppNameInput = driver.FindElement(By.XPath("//label[normalize-space()='Application name']/following::input[@type='text'][1]"));
            IWebElement VersionInput = driver.FindElement(By.XPath("//input[@placeholder='Version' and @role='combobox']"));

            IWebElement ClearBtn = driver.FindElement(By.XPath("(//div[contains(@class,'css-uvvcyu')]//button)[1]"));
            IWebElement ApplyBtn = driver.FindElement(By.XPath("(//div[contains(@class,'css-uvvcyu')]//button)[2]"));

            void ClearFilters()
            {
                Thread.Sleep(500);
                ClearBtn.Click();
                Thread.Sleep(1500);
            }

            void ApplyFilters()
            {
                Thread.Sleep(400);
                ApplyBtn.Click();
                Thread.Sleep(2000);
            }

            void SelectAutocompleteOption(IWebElement input, string text)
            {
                Thread.Sleep(500);
                input.Click();
                Thread.Sleep(300);

                try { input.Clear(); } catch { }
                Thread.Sleep(150);

                input.SendKeys(text);
                Thread.Sleep(1500);

                IWebElement option = null;

                var opt1 = driver.FindElements(By.XPath($"//*[@role='listbox']//li[normalize-space()='{text}']"));
                if (opt1.Count > 0) option = opt1[0];

                if (option == null)
                {
                    var opt2 = driver.FindElements(By.XPath($"//*[@role='listbox']//*[@role='option' and normalize-space()='{text}']"));
                    if (opt2.Count > 0) option = opt2[0];
                }

                if (option == null)
                {
                    var opt3 = driver.FindElements(By.XPath($"//*[@role='listbox']//*[contains(normalize-space(),'{text}')]"));
                    if (opt3.Count > 0) option = opt3[0];
                }

                if (option == null)
                {
                    var opt4 = driver.FindElements(By.XPath($"(//ul[contains(@class,'MuiAutocomplete-listbox')]//li)[1]"));
                    if (opt4.Count > 0) option = opt4[0];
                }

                if (option == null)
                    throw new NoSuchElementException($"Nuk u gjet opsioni i autocomplete për: {text}");

                option.Click();
                Thread.Sleep(800);
            }

            void SelectStatus(string statusText)
            {
                Thread.Sleep(500);
                StatusCombo.Click();
                Thread.Sleep(1000);

                IWebElement option = driver.FindElement(By.XPath($"//*[@role='listbox']//*[normalize-space()='{statusText}']"));
                option.Click();
                Thread.Sleep(800);
            }

            void AssertNoResults()
            {
                Thread.Sleep(1500);

                var msg = driver.FindElements(By.XPath(
                    "//*[contains(.,'No records found') or contains(.,'No data') or contains(.,'No results')]"
                ));

                if (msg.Count == 0)
                {
                    var rows = driver.FindElements(By.XPath("//table/tbody/tr"));
                 
                    throw new NoSuchElementException("Nuk u gjet mesazhi 'No records found/No data/No results' pas filtrit negativ.");
                }
            }

            // SCENARIO 1: Reader 
            ClearFilters();
            SelectAutocompleteOption(ReaderInput, "test");
            ApplyFilters();

            // SCENARIO 2: Status 
           
            ClearFilters();
            SelectStatus("Active");   
            ApplyFilters();

            // SCENARIO 3: Zone Code 
            ClearFilters();
            ZoneCodeInput.Click();
            Thread.Sleep(200);
            try { ZoneCodeInput.Clear(); } catch { }
            Thread.Sleep(150);
            ZoneCodeInput.SendKeys("001");
            ApplyFilters();

            // SCENARIO 4: Zone 
            ClearFilters();
            SelectAutocompleteOption(ZoneInput, "Pogradec");
            ApplyFilters();

           
            // SCENARIO 5: Application name 
            ClearFilters();
            AppNameInput.Click();
            Thread.Sleep(200);
            try { AppNameInput.Clear(); } catch { }
            Thread.Sleep(150);
            AppNameInput.SendKeys("Mobiread");
            ApplyFilters();

            // SCENARIO 6: Version
            ClearFilters();
            SelectAutocompleteOption(VersionInput, "5.0");
            ApplyFilters();

            
            // SCENARIO 7: Të gjithë filtrat bashkë
            ClearFilters();
            SelectAutocompleteOption(ReaderInput, "test");
            SelectStatus("All");
            ZoneCodeInput.Click();
            Thread.Sleep(150);
            try { ZoneCodeInput.Clear(); } catch { }
            ZoneCodeInput.SendKeys("001");
            Thread.Sleep(200);
            SelectAutocompleteOption(ZoneInput, "Pogradec");
            AppNameInput.Click();
            Thread.Sleep(150);
            try { AppNameInput.Clear(); } catch { }
            AppNameInput.SendKeys("Mobiread");
            Thread.Sleep(200);
            SelectAutocompleteOption(VersionInput, "5.0");
            ApplyFilters();

            
            // SCENARIO 8: s’ka rezultate
            ClearFilters();
            ZoneCodeInput.Click();
            Thread.Sleep(150);
            try { ZoneCodeInput.Clear(); } catch { }
            ZoneCodeInput.SendKeys("ZZZ999");
            Thread.Sleep(200);

            AppNameInput.Click();
            Thread.Sleep(150);
            try { AppNameInput.Clear(); } catch { }
            AppNameInput.SendKeys("___NO_SUCH_APP___");
            Thread.Sleep(200);

            ApplyFilters();
            AssertNoResults();

            ClearFilters();
        }
    }
}
