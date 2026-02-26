using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using NUnit.Framework;

namespace Mobiread.Test.FiltersCheck
{
    public class FiltersCheck : BasePage
    {
        private readonly WebDriverWait wait;

    
        private readonly By usernameInput =
            By.XPath("//label[normalize-space()='Username']/following::div[contains(@class,'MuiInputBase-root')][1]//input");

        private readonly By nameInput =
            By.XPath("//label[normalize-space()='Name']/following::div[contains(@class,'MuiInputBase-root')][1]//input");

        private readonly By surnameInput =
            By.XPath("//label[normalize-space()='Surname']/following::div[contains(@class,'MuiInputBase-root')][1]//input");
       
        private readonly By createdOnFromGroup =
            By.XPath("//label[normalize-space()='Created on (From)']/following::div[@role='group'][1]");

        private readonly By createdOnToGroup =
            By.XPath("//label[normalize-space()='Created on (To)']/following::div[@role='group'][1]");

        private readonly By firstSpinButtonInGroup =
            By.XPath(".//span[@role='spinbutton'][1]");

        private readonly By clearFiltersButton =
            By.XPath("//button[.//*[local-name()='path' and contains(@d,'M22 3')]]");

        private readonly By applyFiltersButton =
            By.XPath("//button[.//*[local-name()='path' and contains(@d,'M9 16.17')]]");

        private readonly By tableRows = By.XPath("//tbody/tr");

        public FiltersCheck(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
        }


        private void FocusAndType(By locator, string value)
        {
            for (int attempt = 0; attempt < 3; attempt++)
            {
                try
                {
                 
                    var el = wait.Until(ExpectedConditions.ElementExists(locator));

                   
                    ((IJavaScriptExecutor)driver).ExecuteScript(
                        "arguments[0].scrollIntoView({block:'center'});", el);

                 
                    wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();

                   
                    el = wait.Until(ExpectedConditions.ElementExists(locator));

                    
                    el.SendKeys(Keys.Control + "a");
                    el.SendKeys(Keys.Delete);

                    
                    el = wait.Until(ExpectedConditions.ElementExists(locator));
                    el.SendKeys(value);

                    return; 
                }
                catch (StaleElementReferenceException)
                {
                   
                }
            }

            
            throw new StaleElementReferenceException($"Element u bë stale vazhdimisht: {locator}");
        }

        
        public void SetUsername(string value) => FocusAndType(usernameInput, value);
        public void SetName(string value) => FocusAndType(nameInput, value);
        public void SetSurname(string value) => FocusAndType(surnameInput, value);

        public void SetCreatedFrom(DateTime dt) => SetDateTimeViaSections(createdOnFromGroup, dt);
        public void SetCreatedTo(DateTime dt) => SetDateTimeViaSections(createdOnToGroup, dt);

        private void SetDateTimeViaSections(By groupLocator, DateTime dt)
        {
            var group = wait.Until(ExpectedConditions.ElementIsVisible(groupLocator));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", group);

            group.Click();

            var daySpin = group.FindElement(firstSpinButtonInGroup);
            daySpin.Click();

            
            daySpin.SendKeys(dt.ToString("dd"));
            daySpin.SendKeys(Keys.Tab);

           
            driver.SwitchTo().ActiveElement().SendKeys(dt.ToString("MM"));
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);

           
            driver.SwitchTo().ActiveElement().SendKeys(dt.ToString("yyyy"));
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);

            
            driver.SwitchTo().ActiveElement().SendKeys(dt.ToString("HH"));
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);

            
            driver.SwitchTo().ActiveElement().SendKeys(dt.ToString("mm"));
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);

           
            driver.SwitchTo().ActiveElement().SendKeys(dt.ToString("ss"));
        }

        public void ApplyFilters()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(applyFiltersButton)).Click();
        }

        public void ClearFilters()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(clearFiltersButton)).Click();
        }

        public int GetRowCountSafe()
        {
            try
            {
                wait.Until(d => d.FindElements(tableRows).Count >= 0);
                return driver.FindElements(tableRows).Count;
            }
            catch
            {
                return 0;
            }
        }

        public void AssertAllRowsContain(string expected)
        {
            var rows = driver.FindElements(tableRows);
            Assert.That(rows.Count, Is.GreaterThan(0), "Nuk u gjet asnjë rresht në tabelë pas filtrimit.");

            foreach (var r in rows)
            {
                Assert.That(r.Text, Does.Contain(expected), $"Rreshti nuk përmban '{expected}': {r.Text}");
            }
        }
    }
}