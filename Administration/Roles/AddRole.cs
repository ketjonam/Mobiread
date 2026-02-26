using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Mobiread.Test.Roles
{
    public class RolesPage : BasePage
    {
        private readonly WebDriverWait wait;

        private readonly By rolesMenuItem =
    By.XPath("//div[contains(@class,'MuiListItemText-root')]//span[normalize-space()='Roles']");

        private readonly By addButton =
            By.CssSelector("button[aria-label='Add Role']");

        private readonly By roleNameInput =
            By.CssSelector("input.role-name-input");

        private readonly By searchClaimsInput =
            By.CssSelector("input.search-box-input");

        private readonly By selectAllCheckbox =
            By.XPath("//span[normalize-space()='Select All']/preceding::input[1]");

        private readonly By ADDButton =
            By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]");

        public RolesPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
        }

        
        private By ChipByText(string text) =>
            By.XPath($"//div[@role='button' and .//span[normalize-space()='{text}']]");

        private By CheckboxByLabel(string label) =>
            By.XPath($"//span[normalize-space()='{label}']/preceding::input[1]");

        
        private void SafeClick(By locator)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
                    return;
                }
                catch (StaleElementReferenceException)
                {

                }


                wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
            }
        }

        public void GoToRolesFromMenu()
        {
            SafeClick(rolesMenuItem);
        }

        public void ClickAddRole()
        {
            SafeClick(addButton);

        }

        public void SetRoleName(string name)
        {
            var input = wait.Until(ExpectedConditions.ElementIsVisible(roleNameInput));
            input.SendKeys(Keys.Control + "a");
            input.SendKeys(Keys.Delete);
            input.SendKeys("Lexues1"); 
        }

        public void SelectClaim(string claimName)
        {
            SafeClick(ChipByText(claimName));
        }

        public void SearchClaim(string text)
        {
            var input = wait.Until(ExpectedConditions.ElementIsVisible(searchClaimsInput));
            input.SendKeys(Keys.Control + "a");
            input.SendKeys(Keys.Delete);
            input.SendKeys("text"); 
        }

        public void SelectAllClaims()
        {
            SafeClick(selectAllCheckbox);
        }

        public void SelectPermission(string permissionLabel)
        {
            SafeClick(CheckboxByLabel(permissionLabel));
        }

        public void SaveRole()
        {
            SafeClick(ADDButton);
        }
    }
}