using Mobiread.Test.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using Mobiread.Routes_Management.Routes;

namespace Mobiread.Test.RoutesTests
{
    [TestFixture]
    public class RoutesTest : BasePage
    {
        [Test]
        public void PerformLogin_then_ViewRoutes()
        {
            Console.WriteLine("Test started...");

            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();

            Thread.Sleep(3000);
            //Caktimi i shtigjeve
            Routes view = new Routes(driver);
            view.ViewRoutes();

            Thread.Sleep(1000);
            view.CloseRoutes();

            Thread.Sleep(1000);
            view.ExportRoutes();

            Thread.Sleep(1000);
            view.ResetRoutes();

            Thread.Sleep(1000);
            view.SelectZoneFilter("Cerrave");

            Thread.Sleep(1000);
            view.SelectRoutesFilter("Leshnice");

            Console.WriteLine("Export completed.");
        }
    }
}


