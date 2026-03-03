using Mobiread.Test.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using Mobiread.RoutesMangement.RoutesAssigned;

namespace Mobiread.Test.RoutesAssgnTests
{
    [TestFixture]
    public class RoutesAssgnTest : BasePage
    {
        [Test]
        public void PerformLogin_then_RoutesAssign()
        {
            Console.WriteLine("Test started...");

            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();

            Thread.Sleep(3000);
            //Caktimi i shtigjeve
            RoutesAssgn view = new RoutesAssgn(driver);
            view.RoutesAssign();

            Thread.Sleep(500);
            view.UnassignedRoutes();

            Console.WriteLine("Export completed.");
        }
    }
}

