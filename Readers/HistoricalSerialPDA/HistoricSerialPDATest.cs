using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Readers.HistoricalSerialPDA;
using Mobiread.Test;
using Mobiread.Test.Login;
using OpenQA.Selenium.DevTools.V143.Animation;

namespace Mobiread.Readers.HistoricalSerialPDATests
{
    [TestFixture]
    public class HistoricSerialPDATest : BasePage
    {
        [Test]
        public void PerformLogin_then_FilterHistoricalSerialPDA()
        {
            Console.WriteLine("Test Started...");

            //Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();
            // View Historic Serial PDA
            HistoricSerialPDA historicalSerialPDA = new HistoricSerialPDA(driver);
            string pdaSerialValue = "123456";
            historicalSerialPDA.FilterHistoricalSerialPDA(pdaSerialValue);

            Thread.Sleep(2000);
            historicalSerialPDA.ExportHistoricSerialPDA();
            Console.WriteLine("Test completed.");
        }
    }
}
