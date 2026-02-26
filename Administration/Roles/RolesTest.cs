using NUnit.Framework;
using Mobiread.Test.Login;
using Mobiread.Test.Roles;

namespace Mobiread.Test.RolesTest
{
    [TestFixture]
    public class RolesTest : BasePage
    {
        [Test]
        public void CreateRole_WithClaims_AndPermissions()
        {
            var login = new LoginPage(driver);
            login.PerformLogin();

            var roles = new RolesPage(driver);

            // 1) shko te Roles nga menu
            roles.GoToRolesFromMenu();

            // 2) pastaj Add Role (duhet locator i butonit Add)
            roles.ClickAddRole();

            roles.SetRoleName("AutomationRole_Test");
            roles.SelectClaim("Routes");
            roles.SelectPermission("View routes");
            roles.SaveRole();
        }
    }
}