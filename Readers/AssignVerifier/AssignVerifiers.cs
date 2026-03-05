using Mobiread.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiread.Readers.AssignVerifiers
{
    class AssignVerifiers : BasePage
    {
        public AssignVerifiers(IWebDriver driver) : base(driver) { }

        public IWebElement Menu_Readers => 
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[5]/div[2]/span"));

        public IWebElement SubMenu_AssignVerifiers =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[6]/div/div/div/div[5]/div[2]/span"));

        public IWebElement ChooseVerifier =>
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div[1]/div/div/div/div/div/input"));

        public void VerifierAssign()
        {
            Thread.Sleep(1000);
            Menu_Readers.Click();

            Thread.Sleep(500);
            SubMenu_AssignVerifiers.Click();

            Thread.Sleep(2000);
        }

        public void SelectVerifier(string optionText)
        {
            Thread.Sleep(1500);

            ChooseVerifier.Click();
            Thread.Sleep(800);

            ChooseVerifier.Clear();
            Thread.Sleep(200);

            ChooseVerifier.SendKeys(optionText);
            Thread.Sleep(1200);

            IWebElement option = driver.FindElement(By.XPath(
                $"//*[@role='listbox']//*[normalize-space()='{optionText}']"
            ));

            option.Click();
            Thread.Sleep(1500);
        }

        public void AllReaders()
        {
            Thread.Sleep(1500);

            IWebElement FirstReaderSelect = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div/div[3]/div[1]/p"
            ));
            FirstReaderSelect.Click();

            Thread.Sleep(1500);

            IWebElement SelectAllReaders = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div/div[1]/label/span[1]/input"
            ));
            SelectAllReaders.Click();

            Thread.Sleep(1500);
        }
        public void Button()
        {
            Thread.Sleep(1500);
            IWebElement button = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[2]/div/div/span[1]/button"
            ));
            button.Click();
        }
        public void AssignedReaders()
        {
            Thread.Sleep(1500);
            IWebElement SelectReader = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/p"
            ));
            SelectReader.Click();

            IWebElement Button2 = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[2]/div/div/span[2]/button"
            ));
            Button2.Click();

            IWebElement SaveButton = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[1]/header/div/div[1]/button"
            ));
            SaveButton.Click();

        }
    }
}
