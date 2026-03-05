using System;
using System.Threading;
using NUnit.Framework;
using Mobiread.Test;
using Mobiread.Test.Login;
using Mobiread.Devices.AppVersion;

namespace Mobiread.Devices.AppVersionTests
{
    [TestFixture]
    public class AppVersionTest : BasePage
    {
        [Test]
        public void PerformLogin_then_ViewAppVersion()
        {
            Console.WriteLine("Test started...");

            // Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();
            Thread.Sleep(3000);

            AppVersions view = new AppVersions(driver);
            view.ViewAppVersion();

            //Thread.Sleep(1000);
            //view.EditAppVersion();
            //Thread.Sleep(1000);
            //view.DeleteAppVersion();
            Thread.Sleep(1000);
            view.ExportAssignedVersions();
            Thread.Sleep(1000);
            view.RunAllAppVersionFilterScenarios();

            Console.WriteLine("Test Ended.");
        }
    }
}