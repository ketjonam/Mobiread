using Mobiread.Test.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using Mobiread.Menaxhimi_i_zonave.ZoneAssign;

namespace Mobiread.Test.ZonesAssignTests
{
    [TestFixture]
    public class ZonesAssignTests : BasePage
    {
        [Test]
        public void PerformLogin_then_ZonesAssign()
        {
            Console.WriteLine("Test started...");

            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();

            Thread.Sleep(3000);
            //Caktimi i zonave
            ZoneAssign view = new ZoneAssign(driver);
            view.ZonesAssign();

            Thread.Sleep(2000);
            view.SelectReader("lexues1");

            Thread.Sleep(500);
            view.UnassignedZones();

            Thread.Sleep(500);
            view.Button();

            Thread.Sleep(500);
            view.AssignedZones();

            Console.WriteLine("Export completed.");
        }
    }
}
