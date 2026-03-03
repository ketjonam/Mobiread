using Mobiread.Test;
using OpenQA.Selenium;
using System.Threading;

namespace Mobiread.RoutesMangement.RoutesAssigned
{
    class RoutesAssgn : BasePage
    {
        public RoutesAssgn(IWebDriver driver) : base(driver) { }

        public IWebElement Menu_RouteManagement =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[2]/div[2]/span"));

        public IWebElement SubMenu_AssignRoute =>
            driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/div/div[2]/ul/div[3]/div/div/div/div[2]/div[2]/span"));

        public IWebElement ChooseReader =>
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div[1]/div[2]/div[1]/div[2]/p"));
        public IWebElement SelectDate =>
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[9]/div[1]/span[1]"));
        public void RoutesAssign()
        {
            Thread.Sleep(1000);
            Menu_RouteManagement.Click();

            Thread.Sleep(500);
            SubMenu_AssignRoute.Click();

            Thread.Sleep(500);
            ChooseReader.Click();

            Thread.Sleep(500);
            SelectDate.Click();
        }

        public void UnassignedRoutes()
        {
            IWebElement unassignedrouteselect = driver.FindElement(By.XPath(
                  "/html/body/div[2]/div[3]/div/div[1]/div[2]/div[1]/div/div/div[3]/div[1]/p"
              ));
            unassignedrouteselect.Click();
            
            IWebElement option2 = driver.FindElement(By.XPath(
                "/html/body/div[2]/div[3]/div/div[1]/div[2]/div[1]/div/div/div[3]/div[2]/p"
            ));
            option2.Click();

            IWebElement Button = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div[2]/div[2]/div/div/span[1]/button"));
            Button.Click();

            IWebElement SaveButton = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[2]/button[2]"));
            SaveButton.Click();

        }
    }
}
