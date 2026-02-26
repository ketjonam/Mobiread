using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobiread.Test;
using Mobiread.Test.AddUsers;
using Mobiread.Test.FiltersCheck;
using Mobiread.Test.Login;
using NUnit.Framework;

namespace Mobiread.Administration.Users
{
    [TestFixture]
    public class AdministrationTest : BasePage
    {
        [Test, Order(1)]
        public void PerformLogin_then_AddNewUsers()
        {
            Console.WriteLine("Test started...");

            // 1) Login
            LoginPage login = new LoginPage(driver);
            login.PerformLogin();

            // 2) Add User
            AddUsersPage addUsers = new AddUsersPage(driver);
            addUsers.AddNewUsers();

            Console.WriteLine("Test completed successfully.");

        }
        [Test, Order(2)]
        public void Filters_Username_Name_Surname_CreatedOn_FromTo()
        {
            var login = new LoginPage(driver);
            login.PerformLogin();

            // nëse duhet: driver.Url = "URL e Users page";

            var filters = new FiltersCheck(driver);

            filters.SetUsername("ketjona");
            filters.SetName("Ketjona");
            filters.SetSurname("Mema");

            filters.SetCreatedFrom(new System.DateTime(2025, 1, 1, 0, 0, 0));
            filters.SetCreatedTo(new System.DateTime(2026, 12, 31, 23, 59, 59));

            filters.ApplyFilters();
            // Shto assert sipas tabelës tënde

            filters.ClearFilters();
            filters.ApplyFilters();
        }
    }
}
