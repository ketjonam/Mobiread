using Mobiread.Test;
using OpenQA.Selenium;
using System.Threading;

namespace Mobiread.Devices.DeviceList
{
    class DevicesList : BasePage
    {
        public DevicesList(IWebDriver driver) : base(driver) { }

        public IWebElement Menu_Devices =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[14]/div[2]/span"));

        public IWebElement SubMenu_DevicesList =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[15]/div/div/div/div[1]/div[2]/span"));
        public IWebElement AddNewDeviceButton =>
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/header/div/div[1]/button[2]"));

        public void ViewDevicesList()
        {
            Thread.Sleep(1000);
            Menu_Devices.Click();

            Thread.Sleep(200);
            SubMenu_DevicesList.Click();

            Thread.Sleep(2000);
        }



public void AddNewDevice_FromModal()
    {
        Thread.Sleep(2000);
            AddNewDeviceButton.Click();


        IWebElement serialNumber = driver.FindElement(By.XPath("//div[@role='dialog']//label[normalize-space()='Serial Number']/following::input[@type='text'][1]"));

        IWebElement manufactureDate_dd = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[2]/div/div/div[1]/span[1]/span[2]"));
        IWebElement manufactureDate_mm = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[2]/div/div/div[1]/span[2]/span[2]"));
        IWebElement manufactureDate_yyyy = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[2]/div/div/div[1]/span[3]/span[2]"));

        IWebElement firstUseDate_dd = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[3]/div/div/div[1]/span[1]/span[2]"));
        IWebElement firstUseDate_mm = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[3]/div/div/div[1]/span[2]/span[2]"));
        IWebElement firstUseDate_yyyy = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div/div[3]/div/div/div[1]/span[3]/span[2]"));

            IWebElement appVersionInput = driver.FindElement(By.XPath("//div[@role='dialog']//label[normalize-space()='App Version']/following::input[@role='combobox'][1]"));
        IWebElement readersInput = driver.FindElement(By.XPath("//div[@role='dialog']//label[normalize-space()='Readers']/following::input[@role='combobox'][1]"));

        IWebElement addBtn = driver.FindElement(By.XPath("//div[@role='dialog']//button[normalize-space()='Add']"));
        IWebElement cancelBtn = driver.FindElement(By.XPath("//div[@role='dialog']//button[normalize-space()='Cancel']"));

        void SetText(IWebElement el, string value)
        {
            Thread.Sleep(200);
            el.Click();
            Thread.Sleep(200);
            try { el.Clear(); } catch { }
            Thread.Sleep(150);
            el.SendKeys(value);
            Thread.Sleep(300);
        }

      
        void SelectAutocomplete(IWebElement input, string optionText)
        {
            Thread.Sleep(300);
            input.Click();
            Thread.Sleep(200);
            try { input.Clear(); } catch { }
            Thread.Sleep(150);

            input.SendKeys(optionText);
            Thread.Sleep(1200);

            IWebElement option = null;

            var o1 = driver.FindElements(By.XPath($"//*[@role='listbox']//li[normalize-space()='{optionText}']"));
            if (o1.Count > 0) option = o1[0];

            if (option == null)
            {
                var o2 = driver.FindElements(By.XPath($"//*[@role='listbox']//*[@role='option' and normalize-space()='{optionText}']"));
                if (o2.Count > 0) option = o2[0];
            }

            if (option == null)
            {
                var o3 = driver.FindElements(By.XPath($"//*[@role='listbox']//*[contains(normalize-space(),'{optionText}')]"));
                if (o3.Count > 0) option = o3[0];
            }

            if (option == null)
            {
                var o4 = driver.FindElements(By.XPath("(//ul[contains(@class,'MuiAutocomplete-listbox')]//li)[1]"));
                if (o4.Count > 0) option = o4[0];
            }

            if (option == null)
                throw new NoSuchElementException($"Nuk u gjet opsioni ne autocomplete: {optionText}");

            option.Click();
            Thread.Sleep(800);
        }

        SetText(serialNumber, "56456445");
        manufactureDate_dd.SendKeys("05");
        manufactureDate_mm.SendKeys("03");
        manufactureDate_yyyy.SendKeys("2025");
        firstUseDate_dd.SendKeys("05");
        firstUseDate_mm.SendKeys("03");
        firstUseDate_yyyy.SendKeys("2026");




            SelectAutocomplete(appVersionInput, "1.0");
         
        Thread.Sleep(600);

        addBtn.Click();
        Thread.Sleep(1500);

       
        var stillOpen = driver.FindElements(By.XPath("//div[@role='dialog' and .//h2[contains(normalize-space(),'Add new device')]]"));
        Assert.That(stillOpen.Count == 0, "Modal 'Add new device' duhej te mbyllej pas Add.");
    }

        public void ExportDevicesList()
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
        public void FilterCheck()
        {
            Thread.Sleep(2000);

            IWebElement serialNumberInput = driver.FindElement(By.XPath("//label[normalize-space()='Serial Number']/following::input[@type='text'][1]"));

            IWebElement ManufactureData_dd = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/div/div[1]/span[1]/span[2]"));
            IWebElement ManufactureData_mm = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/div/div[1]/span[2]/span[2]"));
            IWebElement ManufactureData_yyyy = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/div/div[1]/span[3]/span[2]"));

            IWebElement FirstUseDate_dd = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/div/div[1]/span[1]/span[2]"));
            IWebElement FirstUseDate_mm = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/div/div[1]/span[2]/span[2]"));
            IWebElement FirstUseDate_yyyy = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/div/div[1]/span[3]/span[2]"));

            IWebElement versionAutoInput = driver.FindElement(By.XPath("//input[@placeholder='Version' and @role='combobox']"));
            IWebElement readerAutoInput = driver.FindElement(By.XPath("//label[normalize-space()='Reader']/following::input[@role='combobox'][1]"));

            IWebElement clearBtn = driver.FindElement(By.XPath("(//div[contains(@class,'css-uvvcyu')]//button)[1]"));
            IWebElement applyBtn = driver.FindElement(By.XPath("(//div[contains(@class,'css-uvvcyu')]//button)[2]"));

            void ClearAll()
            {
                Thread.Sleep(400);
                clearBtn.Click();
                Thread.Sleep(1500);
            }

            void Apply()
            {
                Thread.Sleep(300);
                applyBtn.Click();
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
                Thread.Sleep(300);
            }
         

            void SelectAutocomplete(IWebElement input, string optionText)
            {
                Thread.Sleep(250);
                input.Click();
                Thread.Sleep(200);
                try { input.Clear(); } catch { }
                Thread.Sleep(150);

                input.SendKeys(optionText);
                Thread.Sleep(1200);

                IWebElement option = null;

                var o1 = driver.FindElements(By.XPath($"//*[@role='listbox']//li[normalize-space()='{optionText}']"));
                if (o1.Count > 0) option = o1[0];

                if (option == null)
                {
                    var o2 = driver.FindElements(By.XPath($"//*[@role='listbox']//*[@role='option' and normalize-space()='{optionText}']"));
                    if (o2.Count > 0) option = o2[0];
                }

                if (option == null)
                {
                    var o3 = driver.FindElements(By.XPath($"//*[@role='listbox']//*[contains(normalize-space(),'{optionText}')]"));
                    if (o3.Count > 0) option = o3[0];
                }

                if (option == null)
                {
                    var o4 = driver.FindElements(By.XPath("(//ul[contains(@class,'MuiAutocomplete-listbox')]//li)[1]"));
                    if (o4.Count > 0) option = o4[0];
                }

                if (option == null)
                    throw new NoSuchElementException($"Nuk u gjet opsioni ne autocomplete: {optionText}");

                option.Click();
                Thread.Sleep(800);
            }

            void AssertHasResults(string context)
            {
                Thread.Sleep(1000);

            
                var rows = driver.FindElements(By.XPath("//table/tbody/tr"));

                bool hasNoRecordsMsg = driver.FindElements(By.XPath(
                    "//*[contains(.,'No records found') or contains(.,'No data') or contains(.,'No results')]"
                )).Count > 0;

                Assert.That(rows.Count > 0 && !hasNoRecordsMsg, $"Duhej te kishte rezultate per skenarin: {context}");
            }

            void AssertNoResults(string context)
            {
                Thread.Sleep(1000);

          
                var msg = driver.FindElements(By.XPath(
                    "//*[contains(.,'No records found') or contains(.,'No data') or contains(.,'No results')]"
                ));
                if (msg.Count > 0)
                {
                    Assert.That(msg[0].Displayed, $"Duhej te shfaqej 'No records...' per skenarin: {context}");
                    return;
                }

               
                var rows = driver.FindElements(By.XPath("//table/tbody/tr"));
               
                bool anyNo = rows.Any(r => r.Text.Contains("No records") || r.Text.Contains("No data") || r.Text.Contains("No results"));

                Assert.That(rows.Count == 0 || anyNo, $"Tabela duhej te mos kishte rezultate per skenarin: {context}");
            }

            // SCENARIO 1: vetëm Serial Number (pozitiv)
            ClearAll();
            SetText(serialNumberInput, "SN-123456-UPDATED");
            Apply();
            AssertHasResults("Serial Number only");

            // SCENARIO 2: Serial Number (negativ)
            ClearAll();
            SetText(serialNumberInput, "___NO_SUCH_SERIAL___");
            Apply();
            AssertNoResults("Serial Number negative");

            // SCENARIO 3: vetëm Manufacture Date (pozitiv)
            ClearAll();
            ManufactureData_dd.SendKeys("01");
            ManufactureData_mm.SendKeys("01");
            ManufactureData_yyyy.SendKeys("2025");
            Apply();
            AssertHasResults("Manufacture Date only");

           
            // SCENARIO 4: vetëm First Use Date (pozitiv)
            ClearAll();
            FirstUseDate_dd.SendKeys("15");
            FirstUseDate_mm.SendKeys("01");
            FirstUseDate_yyyy.SendKeys("2025");
            Apply();
            AssertHasResults("First Use Date only");

            // SCENARIO 5: vetëm Version (autocomplete) 
            ClearAll();
            SelectAutocomplete(versionAutoInput, "5.0");
            Apply();
            AssertHasResults("Version only");

            // SCENARIO 6: vetëm Reader (autocomplete)
            
            ClearAll();
            SelectAutocomplete(readerAutoInput, "lexues1");
            Apply();
            AssertHasResults("Reader only");

            // SCENARIO 7: kombinim Serial + Version (pozitiv)
            
            ClearAll();
            SetText(serialNumberInput, "SN-123456-UPDATED");
            SelectAutocomplete(versionAutoInput, "5.0");
            Apply();
            AssertHasResults("Serial + Version");

            // SCENARIO 8: kombinim Date + Reader (pozitiv)
           
            ClearAll();
            ManufactureData_dd.SendKeys("01");
            ManufactureData_mm.SendKeys("01");  
            ManufactureData_yyyy.SendKeys("2025");
            SelectAutocomplete(readerAutoInput, "lexues1");
            Apply();
            AssertHasResults("Manufacture Date + Reader");

            // SCENARIO 9: të gjithë filtrat bashkë (pozitiv)
            ClearAll();
            SetText(serialNumberInput, "SN-123456-UPDATED");
            ManufactureData_dd.SendKeys("01");
            ManufactureData_mm.SendKeys("01");
            ManufactureData_yyyy.SendKeys("2025");

            SelectAutocomplete(versionAutoInput, "5.0");
            SelectAutocomplete(readerAutoInput, "lexues1");
            Apply();
            AssertHasResults("All filters");

            // SCENARIO 10: NEGATIVE - kombinim që s’duhet të kthejë rezultate
            ClearAll();
            SetText(serialNumberInput, "___NO_SUCH_SERIAL___");
            SelectAutocomplete(versionAutoInput, "1.0");
            Apply();
            AssertNoResults("Negative mix");

            
            ClearAll();
        }
    }
}