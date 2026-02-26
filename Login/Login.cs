using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mobiread.Test.Login
{

    class Login : BasePage  
    {
        public IWebElement Fusha_Perdoruesi => driver.FindElement(By.Name("username"));
        public IWebElement Fusha_Fjalekalimi => driver.FindElement(By.Name("password"));
        public IWebElement CheckBox_MeMbajMend => driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/label/span[1]/input"));
        public IWebElement Butoni_Hyr => driver.FindElement(By.XPath("/html/body/div/div/div/form/button"));


        public Login(IWebDriver driver) : base(driver)
        {
        }

        public void PerformLogin()
        {
            driver.Url = "https://mrfe-test.flare.al/login";
            Fusha_Perdoruesi.SendKeys("ketjona.test");
            Fusha_Fjalekalimi.SendKeys("Migen@!12");
            CheckBox_MeMbajMend.Click();
            Butoni_Hyr.Click();


        }
    }
}
