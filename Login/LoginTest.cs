using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Test.ForgotPassword;
using NUnit.Framework;

namespace Mobiread.Test.Login
{
    [TestFixture]
    public class LoginTest : BasePage
    {
        [Test, Order(1)]
        public void PerformLogin()
        {
            Console.WriteLine("Test started...");   
            LoginPage login_Succeful = new LoginPage(driver);
            login_Succeful.PerformLogin();
            Console.WriteLine("Test finished.");
        }

        [Test, Order(2)]
        public void ClickForgotPassword()
        {
            Console.WriteLine("Test started...");
            ForgotPasswordPage Perform = new ForgotPasswordPage(driver);
            Perform.ClickForgotPassword();
            Console.WriteLine("Test finished.");

        }
    }
}
