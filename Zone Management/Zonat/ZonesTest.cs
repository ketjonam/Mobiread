using Mobiread.Test.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using Mobiread.Test.Zonat;

namespace Mobiread.Test.Zonat
{
    [TestFixture]
    public class ZonatTests : BasePage
    {
        [Test]
        public void PerformLogin_then_Should_Select_Zona_And_See_Result_In_Table()
        {
            Console.WriteLine("Test started...");

            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();

            Thread.Sleep(3000);

            // 2) Shko te Zonat
            Zonat view = new Zonat(driver);
            view.GoToZonatPage();
            view.SelectZona("Tirane");
            view.ExportData();

            Console.WriteLine("Export completed.");
        }
    }
}