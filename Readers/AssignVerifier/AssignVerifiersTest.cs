using Mobiread.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Readers.AssignVerifiers;
using Mobiread.Test.Login;

namespace Mobiread.Readers.AssignVerifiersTests
{
    [TestFixture]
    public class AssignVerifiersTest : BasePage
    {
        [Test]
        public void PerformLogin_then_VerifierAssign()
        {
            Console.WriteLine("Test started...");
            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();
            Thread.Sleep(3000);
            //Caktimi i verifikuesve
            Mobiread.Readers.AssignVerifiers.AssignVerifiers view = new Mobiread.Readers.AssignVerifiers.AssignVerifiers(driver);
            view.VerifierAssign();
            Thread.Sleep(2000);
            view.SelectVerifier("verifikues.kreatx1");
            Thread.Sleep(2000);
            view.AllReaders();
            Thread.Sleep(2000);
            view.Button();
            Thread.Sleep(500);
            view.AssignedReaders();
            Console.WriteLine("Export completed.");
        }
    }
}
