using Mobiread.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiread.Devices.AppVersion
{
    class AppVersions : BasePage
    {
        public AppVersions(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement Menu_Devices => driver.FindElement(By.XPath("//html/body/div/div/div[1]/div/div/div/div[2]/ul/div[14]/div[2]/span"));
        public IWebElement SubMenu_AppVersion => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[15]/div/div/div/div[2]/div[2]/span"));
        public IWebElement AddButton => driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/header/div/div[1]/button[2]"));
        public IWebElement AppVersionName => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[1]/div/input"));
        public IWebElement ApplicationNameField => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[1]/div/input"));
        public IWebElement VersionField => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[2]/div/input"));
        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[contains(@class,'MuiInputBase-inputMultiline')]"));
        public IWebElement UploadZipFile => driver.FindElement(By.XPath("//label[contains(text(),'Upload ZIP')]//input"));

        public IWebElement ActiveCheckbox => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[5]/label/span[1]"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]"));

        public void ViewAppVersion()
        {
            Thread.Sleep(1500);
            Menu_Devices.Click();
            Thread.Sleep(1500);
            SubMenu_AppVersion.Click();
            Thread.Sleep(1500);
            AddButton.Click();
            Thread.Sleep(1200);
            AppVersionName.SendKeys("Automation Test 1.0");
            Thread.Sleep(300);
            ApplicationNameField.SendKeys("Test App");
            Thread.Sleep(300);
            VersionField.SendKeys("1.0");
            Thread.Sleep(300);
            DescriptionField.SendKeys("This is a test app version created for automation testing purposes.");
            Thread.Sleep(800);
            UploadZipFile.SendKeys(@"C:\Users\Kreatx\Downloads\sample-1.zip");
            Thread.Sleep(800);
            ActiveCheckbox.Click();
            Thread.Sleep(800);
            SaveButton.Click();
            Thread.Sleep(1500);
        }
        public void EditAppVersion()
        {
            Thread.Sleep(1500);
            Menu_Devices.Click();
            Thread.Sleep(1500);
            SubMenu_AppVersion.Click();
            Thread.Sleep(1500);
            IWebElement EditButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[2]/div[1]/table/tbody/tr[1]/td[6]/div/button[1]"));
            EditButton.Click();
            Thread.Sleep(1500);
            ApplicationNameField.Clear();
            Thread.Sleep(500);
            ApplicationNameField.SendKeys("Test App Updated");
            Thread.Sleep(500);
            SaveButton.Click();
        }
        public void DeleteAppVersion()
        {
            Menu_Devices.Click();
            Thread.Sleep(1500);
            SubMenu_AppVersion.Click();
            Thread.Sleep(1500);
            IWebElement DeleteButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[2]/div[1]/table/tbody/tr[2]/td[6]/div/button[2]"));
            DeleteButton.Click();
            IWebElement ConfirmDeleteButton = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]"));
            ConfirmDeleteButton.Click();
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
        public void RunAllAppVersionFilterScenarios()
        {
            Thread.Sleep(2000);

            // ====== FIELDS (stable locators by label text) ======
            IWebElement ApplicationName = driver.FindElement(By.XPath("//label[normalize-space()='Application name']/following::input[@type='text'][1]"));
            IWebElement AppVersion = driver.FindElement(By.XPath("//label[normalize-space()='App Version']/following::input[@type='text'][1]"));
            IWebElement Description = driver.FindElement(By.XPath("//label[normalize-space()='Description']/following::input[@type='text'][1]"));
            IWebElement Path = driver.FindElement(By.XPath("//label[normalize-space()='Path']/following::input[@type='text'][1]"));

            // Active (MUI Select)
            IWebElement ActiveCombo = driver.FindElement(By.XPath("//label[normalize-space()='Active']/following::div[@role='combobox'][1]"));

            // Buttons (Clear = first, Apply = second)
            IWebElement ClearBtn = driver.FindElement(By.XPath("(//div[contains(@class,'css-uvvcyu')]//button)[1]"));
            IWebElement ApplyBtn = driver.FindElement(By.XPath("(//div[contains(@class,'css-uvvcyu')]//button)[2]"));

            // ====== Helpers ======
            void ClearFilters()
            {
                Thread.Sleep(400);
                ClearBtn.Click();
                Thread.Sleep(1500);
            }

            void ApplyFilters()
            {
                Thread.Sleep(400);
                ApplyBtn.Click();
                Thread.Sleep(2000);
            }

            void SetText(IWebElement el, string value)
            {
                Thread.Sleep(200);
                el.Click();
                Thread.Sleep(150);
                try { el.Clear(); } catch { }
                Thread.Sleep(150);
                el.SendKeys(value);
                Thread.Sleep(250);
            }

            void SelectActive(string optionText)
            {
                Thread.Sleep(400);
                ActiveCombo.Click();
                Thread.Sleep(900);

                IWebElement opt = driver.FindElement(By.XPath($"//*[@role='listbox']//*[normalize-space()='{optionText}']"));
                opt.Click();
                Thread.Sleep(800);
            }

            void AssertNoResults()
            {
                Thread.Sleep(1500);

                var msg = driver.FindElements(By.XPath(
                    "//*[contains(.,'No records found') or contains(.,'No data') or contains(.,'No results')]"
                ));

                Assert.That(msg.Count > 0, "Pritet mesazhi 'No records found/No data/No results' kur filtrat nuk kthejnë rezultate.");
            }

            // SCENARIO 1: vetëm Application name
            ClearFilters();
            SetText(ApplicationName, "Mobiread");
            ApplyFilters();

            // SCENARIO 2: vetëm App Version
            ClearFilters();
            SetText(AppVersion, "1.0");
            ApplyFilters();

            // SCENARIO 3: vetëm Description
          
            ClearFilters();
            SetText(Description, "test");
            ApplyFilters();

            // SCENARIO 4: vetëm Path
            ClearFilters();
            SetText(Path, "/");
            ApplyFilters();

            // SCENARIO 5: vetëm Active 
           
            ClearFilters();

            SelectActive("Inactive");
            ApplyFilters();

            // SCENARIO 6: kombinim 2 filtra (Application + Version)
            ClearFilters();
            SetText(ApplicationName, "Mobiread");
            SetText(AppVersion, "1.0");
            ApplyFilters();

            // SCENARIO 7: kombinim 3 filtra (Application + Version + Active)
           
            ClearFilters();
            SetText(ApplicationName, "Mobiread");
            SetText(AppVersion, "1.0");
            SelectActive("Active");
            ApplyFilters();

            // SCENARIO 8: të gjithë filtrat bashkë
            ClearFilters();
            SetText(ApplicationName, "Mobiread");
            SetText(AppVersion, "1.0");
            SetText(Description, "test");
            SetText(Path, "/");
            SelectActive("All");
            ApplyFilters();

            // SCENARIO 9: s’ka rezultate
            ClearFilters();
            SetText(ApplicationName, "___NO_SUCH_APP___");
            SetText(AppVersion, "999.999");
            SetText(Description, "___NO_SUCH_DESC___");
            SetText(Path, "___NO_SUCH_PATH___");
            ApplyFilters();
            AssertNoResults();

            // SCENARIO 10: Clear 
           
            ClearFilters();
        }


    }


}
