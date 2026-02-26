using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mobiread.Test.ForgotPassword
{

    class ForgotPasswordPage : BasePage
    {
        public IWebElement Linku_ForgotPassword => driver.FindElement(By.XPath("/html/body/div/div/div/form/div[3]/button"));
        public IWebElement Fusha_Email => driver.FindElement(By.Name("email"));
        public IWebElement Butoni_Send => driver.FindElement(By.XPath("/html/body/div/div/div/form/button"));

        public ForgotPasswordPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickForgotPassword()
        {
            driver.Url = "https://mrfe-test.flare.al/login";
            Linku_ForgotPassword.Click();
            Fusha_Email.SendKeys("ketjonamema@gmail.com");
            Butoni_Send.Click();
            Thread.Sleep(2000);


        }
    }
}
