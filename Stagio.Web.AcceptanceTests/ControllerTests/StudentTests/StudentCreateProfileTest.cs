using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.StudentPages;

namespace Stagio.Web.AcceptanceTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentCreateProfileTest : GlobalBaseTest 
    {
        [TestInitialize]
        public void CreateProfileTestsInitialize()    
        {
            SubscribeStudentPage.GoTo();
            SubscribeStudentPage.FillStudentIdWith(TestData.NotSubscribedStudent);
            CreateStudentProfilePage.GoTo();
        }

        [TestMethod]
        public void student_can_subscribe_by_creating_a_profile()
        {
            CreateStudentProfilePage.FillForm(TestData.ToSubscribeStudent);
            CreateStudentProfilePage.Submit();
            HomePage.IsStudentLogged.Should().BeTrue();
        }
    }
}
