using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Readers.ReadersList;
using Mobiread.Test;
using Mobiread.Test.Login;

namespace Mobiread.Readers.ReadersListTest
{
    [TestFixture]
    public class ReaderListTest : BasePage
    {
        [Test]
        public void PerformLogin_then_ViewReadersList()
        {
            Console.WriteLine("Test started...");
            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();
            Thread.Sleep(3000);
            // 2) View Readers List
            ReaderList view = new ReaderList(driver);
            view.ViewReadersList("test", "test"); 
            Thread.Sleep(3000);
            view.ExportReadersList();
            Console.WriteLine("Test completed.");
        }
    }
}
