using Mobiread.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Devices.AssignVersiontoReaders;
using Mobiread.Test.Login;
using OpenQA.Selenium.DevTools.V143.Animation;

namespace Mobiread.Devices.AssignVersiontoReadersTests
{
    [TestFixture]
    public class AssignVersionTest : BasePage
    {
        [Test]
        public void PerformLogin_then_AssignVersiontoReaders()
        {
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();
            Thread.Sleep(3000);
            AssignVersion assignVersion = new AssignVersion(driver);
            assignVersion.AssignVersionToReaders();
            Thread.Sleep(3000);
            assignVersion.ExportAssignedVersions();
            Thread.Sleep(3000);
            assignVersion.RunAllFilterScenarios();
        }
    }
}
