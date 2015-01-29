using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.CompanyPages;
using Stagio.Web.Automation.PageObjects.EmployeePages;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.EmployeeTests
{
    [TestClass]
    public class EmployeControllerSubscribeTests : GlobalBaseTest
    {
        [TestInitialize]
        public void EditTestsInitialize()
        {
            CreateEmployeePage.GoTo();
        }

        [TestMethod]
        public void employee_can_create_an_account_by_selecting_an_existing_company()
        {
            CreateEmployeePage.SelectAnExistingCompany();
            CreateEmployeePage.FillCreationFormWith(TestData.Employee3);

            HomePage.HasFeedBackMessage(WebMessage.EmployeeMessage.ACCOUNT_CREATE_SUCCESS).Should().BeTrue();
        }

        [TestMethod]
        public void employee_can_create_an_account_by_creating_a_new_company()
        {
            CreateEmployeePage.SelectCreateNewCompany();
            CreateCompanyPage.FillCompanyFieldsWith(TestData.Company6);
            CreateEmployeePage.FillCreationFormWith(TestData.Employee3);
                
            HomePage.HasFeedBackMessage(WebMessage.EmployeeMessage.ACCOUNT_CREATE_SUCCESS).Should().BeTrue();
        }
    }
}
