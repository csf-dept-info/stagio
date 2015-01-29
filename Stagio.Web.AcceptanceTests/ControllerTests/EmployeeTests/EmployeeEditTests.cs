using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects.EmployeePages;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.Navigation;

using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.EmployeeTests
{
    [TestClass]
    public class EmployeeEditTests : GlobalBaseTest
    {
        [TestInitialize]
        public void EditTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
        }

        [TestMethod]
        public void employee_should_visualize_personal_information()
        {
            //Arrange
            var employee = TestData.Employee1;

            //Act
            EditEmployeePage.GoTo();

            //Assert
            EditEmployeePage.FirstEmployee.Identifier.ShouldBeEquivalentTo(employee.Identifier);
            EditEmployeePage.FirstEmployee.PhoneNumber.ShouldBeEquivalentTo(employee.PhoneNumber);
            EditEmployeePage.FirstEmployee.ExtensionNumber.ShouldBeEquivalentTo(employee.ExtensionNumber);
        }

        [TestMethod]
        public void employee_can_edit_his_profile()
        {
            //Arrange
            var employee = TestData.Employee1;

            //Act
            EditEmployeePage.GoTo();
            EditEmployeePage.ModifyEmployeeProfileWith(employee);
            EditEmployeePage.GoTo();

            //Assert
            EditEmployeePage.FirstEmployee.Identifier.ShouldBeEquivalentTo(employee.Identifier);
            EditEmployeePage.FirstEmployee.PhoneNumber.ShouldBeEquivalentTo(employee.PhoneNumber);
            EditEmployeePage.FirstEmployee.ExtensionNumber.ShouldBeEquivalentTo(employee.ExtensionNumber);
        }

        [TestMethod]
        public void employee_can_edit_his_password()
        {     
            //Arrange
            const string NEW_PASSWORD = "newpassword123";
            var currentUser = TestData.Employee1;
            currentUser.Password = NEW_PASSWORD;

            //Act
            EditEmployeePage.GoTo();
            EditEmployeePage.ModifyEmployeePasswordWith(NEW_PASSWORD, TestData.Employee1.Password);

            PageNavigator.AllUsers.Logout.Select();

            LoginPage.GoTo();
            LoginPage.LoginAs(currentUser);

            //Assert
            HomePage.IsEmployeeLogged.Should().BeTrue();
        }
    }
}
