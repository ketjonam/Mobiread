using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
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

        // ===== AUTOCOMPLETE (Zonat) - FIX me fallback =====

        // input i autocomplete (fallback i fortë)
        public IWebElement ZonaCombobox_Input
        {
            get
            {
                // 1) input me role combobox
                var a = driver.FindElements(By.XPath("//input[@role='combobox']")).FirstOrDefault();
                if (a != null) return a;

                // 2) input brenda MuiAutocomplete-root
                var b = driver.FindElements(By.XPath("//div[contains(@class,'MuiAutocomplete-root')]//input")).FirstOrDefault();
                if (b != null) return b;

                // 3) input me aria-autocomplete=list
                var c = driver.FindElements(By.XPath("//input[@aria-autocomplete='list']")).FirstOrDefault();
                if (c != null) return c;

                // 4) input type text (fallback i fundit)
                var d = driver.FindElements(By.XPath("//input[@type='text']")).FirstOrDefault();
                if (d != null) return d;

                throw new NoSuchElementException("ZonaCombobox_Input: nuk u gjet input i autocomplete.");
            }
        }

        // butoni "Open" (fallback)
        public IWebElement ZonaCombobox_OpenButton
        {
            get
            {
                var a = driver.FindElements(By.XPath("//button[@aria-label='Open']")).FirstOrDefault();
                if (a != null) return a;

                var b = driver.FindElements(By.XPath("//button[contains(@class,'MuiAutocomplete-popupIndicator')]")).FirstOrDefault();
                if (b != null) return b;

                // fallback: button që ka svg shigjetë poshtë brenda autocomplete
                var c = driver.FindElements(By.XPath("//div[contains(@class,'MuiAutocomplete-endAdornment')]//button")).FirstOrDefault();
                if (c != null) return c;

                throw new NoSuchElementException("ZonaCombobox_OpenButton: nuk u gjet butoni Open.");
            }
        }

        public IWebElement Zona_Listbox
        {
            get
            {
                // MUI listbox del shpesh si portal
                return driver.FindElement(By.XPath("//*[@role='listbox']"));
            }
        }

        // ===== METHODS =====

        public void GoToZonatPage()
        {
            Thread.Sleep(1000);
            Menu_MenaxhimiZonave.Click();

            Thread.Sleep(1000);
            Nenmenu_Zonat.Click();

            Thread.Sleep(5000); // prit render të faqes/tabelës/filtrave
        }

        // ========== SCENARIOS ==========

        public void OpenZonaDropdown_ByButton()
        {
            Thread.Sleep(1500);
            var btn = ZonaCombobox_OpenButton;

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", btn);
            Thread.Sleep(400);

            try { btn.Click(); }
            catch { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", btn); }

            Thread.Sleep(1500);
        }

        public void OpenZonaDropdown_ByInput()
        {
            Thread.Sleep(1500);
            var input = ZonaCombobox_Input;

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", input);
            Thread.Sleep(400);

            try { input.Click(); }
            catch { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", input); }

            Thread.Sleep(1500);
        }

        public void SelectZona_ByTypingAndEnter(string zona)
        {
            Thread.Sleep(800);

            // hap dropdown (provo butonin, po s’bëri punë kalo te input)
            try { OpenZonaDropdown_ByButton(); }
            catch { OpenZonaDropdown_ByInput(); }

            Thread.Sleep(500);

            var input = ZonaCombobox_Input;
            input.Clear();
            Thread.Sleep(300);

            input.SendKeys(zona);
            Thread.Sleep(1200);

            input.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }

        public void SelectZona_ByClickOption(string optionText)
        {
            Thread.Sleep(800);

            try { OpenZonaDropdown_ByButton(); }
            catch { OpenZonaDropdown_ByInput(); }

            Thread.Sleep(800);

            var option = driver.FindElement(By.XPath($"//*[@role='listbox']//*[normalize-space()='{optionText}']"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", option);
            Thread.Sleep(400);

            try { option.Click(); }
            catch { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", option); }

            Thread.Sleep(2000);
        }
    }
}