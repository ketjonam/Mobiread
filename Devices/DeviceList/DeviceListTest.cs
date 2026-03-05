using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Test;
using Mobiread.Test.Login; 
using Mobiread.Devices.DeviceList;

namespace Mobiread.Devices.DeviceListTests  
{
    [TestFixture]
    public class DeviceListTest : BasePage
    {
        [Test]
        public void PerformLogin_then_ViewDeviceList()
        {
            Console.WriteLine("Test started...");
            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();
            Thread.Sleep(3000);
            // 2) View Device List
            DevicesList view = new DevicesList(driver);
            view.ViewDevicesList();
            Thread.Sleep(1500);
            view.AddNewDevice_FromModal();
            //Thread.Sleep(3000);
            //view.ExportDevicesList();
            //view.FilterCheck();

            Console.WriteLine("Test Ended.");
        }
    }
}
