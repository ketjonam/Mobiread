using Mobiread.Test.Login;
using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
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

            // 2) Go to Zonat page
            Zonat View = new Zonat(driver);
            View.GoToZonatPage();

            Thread.Sleep(3000);

            // 3) Select Zona (zgjidh njërin variant)
            View.SelectZona_ByTypingAndEnter("Tirane");
            // View.SelectZona_ByClickOption("Tirane");

            Thread.Sleep(3000);

            // 4) Verify table has rows
            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            Assert.That(rows.Count, Is.GreaterThan(0), "Tabela nuk ka rreshta pas zgjedhjes së zones.");

            Console.WriteLine($"Rows after filter: {rows.Count}");
        }
    }
}