using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.Navigation;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.StudentPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentEditTests : GlobalBaseTest
    {
        [TestInitialize]
        public void EditTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.SubscribedStudent1);
        }

        [TestMethod]
        public void student_can_visualize_his_personal_information()
        {
            //Arrange
            var student = TestData.SubscribedStudent1;

            //Act
            EditStudentPage.GoTo();
          
            //Assert
            EditStudentPage.Student.Identifier.ShouldBeEquivalentTo(student.Identifier);
            EditStudentPage.Student.PhoneNumber.ShouldBeEquivalentTo(student.PhoneNumber);
        }

        [TestMethod]
        public void student_can_edit_his_profile()
        {
            //Arrange
            var student = TestData.SubscribedStudent1;

            //Act
            EditStudentPage.GoTo();
            EditStudentPage.ModifyStudentProfileWith(student);
            EditStudentPage.GoTo();

            //Assert
            EditStudentPage.Student.Identifier.ShouldBeEquivalentTo(student.Identifier);
            EditStudentPage.Student.PhoneNumber.ShouldBeEquivalentTo(student.PhoneNumber);
        }

        [TestMethod]
        public void student_can_edit_his_password()
        {
            //Arrange
            var student = TestData.SubscribedStudent1;

            //Act
            EditStudentPage.GoTo();
            EditStudentPage.ModifyStudentPasswordWith(student, TestData.Employee2.Password);

            PageNavigator.AllUsers.Logout.Select();
            LoginPage.GoTo();
            LoginPage.LoginAs(student);
        }
    }
}
