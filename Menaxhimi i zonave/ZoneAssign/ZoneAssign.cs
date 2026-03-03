using Mobiread.Test;
using OpenQA.Selenium;
using System.Threading;

namespace Mobiread.Menaxhimi_i_zonave.ZoneAssign
{
    class ZoneAssign : BasePage
    {
        public ZoneAssign(IWebDriver driver) : base(driver) { }

        public IWebElement Menu_MenaxhimiZonave =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[1]"));

        public IWebElement SubMenu_ZonesAssgn =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[2]/div/div/div/div[2]/div[2]/span"));

        public IWebElement ChooseReader =>
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div/div[1]/div/div/div/div/div/input"));

        public void ZonesAssign()
        {
            Thread.Sleep(1000);
            Menu_MenaxhimiZonave.Click();

            Thread.Sleep(500);
            SubMenu_ZonesAssgn.Click();

            Thread.Sleep(2000);
        }

        public void SelectReader(string optionText)
        {
            Thread.Sleep(1500);

            IWebElement input = driver.FindElement(By.XPath(
                "//label[normalize-space()='Choose Reader']/following::input[@role='combobox'][1]"
            ));

            input.Click();
            Thread.Sleep(800);

            input.Clear();
            Thread.Sleep(200);

            input.SendKeys(optionText);
            Thread.Sleep(1200);

            IWebElement option = driver.FindElement(By.XPath(
                $"//*[@role='listbox']//*[normalize-space()='{optionText}']"
            ));

            option.Click();
            Thread.Sleep(1500);
        }

        public void UnassignedZones()
        {
            Thread.Sleep(1500);

            IWebElement unassignedzonesselect = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div/div[3]/div[1]/p"
            ));
            unassignedzonesselect.Click();

            Thread.Sleep(1500);

            IWebElement unassignedzonesoption1 = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div/div[3]/div[2]//*[self::li or self::p][1]"
            ));
            unassignedzonesoption1.Click();

            Thread.Sleep(1500);

            IWebElement unassignedzonesselectall = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div/div[1]/label/span[1]/input"
            ));
            unassignedzonesselectall.Click();

            Thread.Sleep(1000);
        }
        public void Button()
        {
            Thread.Sleep(1500);
            IWebElement button = driver.FindElement(By.XPath(
                "/html/body/div[1]/div/div[2]/div[2]/div/div/div/div[2]/div[2]/div/div/span[1]/button"
            ));
            button.Click();
        }
        public void AssignedZones() 
        {
            Thread.Sleep(1500);
            IWebElement Selectzones = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div[3]/p"
            ));
            Selectzones.Click();
            IWebElement Selectzonesoption1 = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div[4]/p"
            ));
            Selectzonesoption1.Click();

            IWebElement Selectzonesoption2= driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div[5]/p"
            ));
            Selectzonesoption2.Click();

            IWebElement Button2 = driver.FindElement(By.XPath(
                "/html/body/div[1]/div/div[2]/div[2]/div/div/div/div[2]/div[2]/div/div/span[2]/button"
            ));
            Button2.Click();

            IWebElement SaveButton = driver.FindElement(By.XPath(
                "/html/body/div/div/div[2]/div[1]/header/div/div[1]/button/span[1]"
            ));
            SaveButton.Click();

        }
    }    

}