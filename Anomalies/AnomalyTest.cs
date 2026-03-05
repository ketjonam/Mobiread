using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Test;
using Mobiread.Test.Login;  
using Mobiread.Anomalies; 

namespace Mobiread.AnomalyTests
{
    [TestFixture]
    public class AnomalyTest : BasePage
    {
        [Test]
        public void PerformLogin_then_AnomalyAdd()
        {
            Console.WriteLine("Test started...");
            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();
            Thread.Sleep(3000);
            //Caktimi i anomalisë
            Anomaly view = new Anomaly(driver);
            view.AnomalyAdd();
            Thread.Sleep(3000);
            //view.AddSubAnomaly();
            //Thread.Sleep(3000);
            //view.ExportAnomalyList();
            //Thread.Sleep(1500);
            //view.DeleteAnomaly();
            //view.EditAnomaly();
            view.FilterAnomalies(""); 
            Console.WriteLine("Test Ended.");
        }
    }
}
