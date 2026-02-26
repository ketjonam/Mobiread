using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Mobiread.Test.AddUsers
{
    public class AddUsersPage : BasePage
    {
        private readonly WebDriverWait wait;

        private readonly By addButton =
            By.CssSelector("button[aria-label='Add new user']");

        private readonly By nameInput =
            By.Name("name");

        private readonly By surnameInput =
            By.Name("surname");

        private readonly By emailInput =
            By.Name("email");

        private readonly By passwordInput =
            By.Name("password");

        private readonly By roleOpenButton =
            By.XPath("//legend[.//span[normalize-space()='Roles']]/ancestor::div[contains(@class,'MuiOutlinedInput-root')]//button[@aria-label='Open']");

        private By roleOption(string roleName) =>
            By.XPath($"//li[@role='option' and normalize-space()='{roleName}']");

        private readonly By confirmAddButton =
            By.XPath("//div[contains(@class,'MuiDialogActions-root')]//button[2]");

       

        public AddUsersPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
        }

        public void AddNewUsers()
        {
          
            wait.Until(ExpectedConditions.ElementToBeClickable(addButton)).Click();

           
            wait.Until(ExpectedConditions.ElementIsVisible(nameInput)).SendKeys("Ketjona");
            driver.FindElement(surnameInput).SendKeys("Mema");
            driver.FindElement(emailInput).SendKeys("ketjona.mema@kreatx.com");
            driver.FindElement(passwordInput).SendKeys("Ketjona12@!");

           
            SelectRole("Admin");

          
            wait.Until(ExpectedConditions.ElementToBeClickable(confirmAddButton)).Click();
        }

        private void SelectRole(string roleName)
        {
            
            wait.Until(ExpectedConditions.ElementToBeClickable(roleOpenButton)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(roleOption(roleName))).Click();
        }
    }
}