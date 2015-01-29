using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.CompanyPages;
using FluentAssertions;

namespace Stagio.Web.AcceptanceTests.ControllerTests.CompanyTests
{
    [TestClass]
    public class CompanyEditTests : GlobalBaseTest
    {
        [TestInitialize]
        public void EditTestsInitialize()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(TestData.Employee1);
            EditCompanyPage.GoTo();
        }

        [TestMethod]
        public void employee_can_see_his_current_company_informations()
        {
            AreEqual(EditCompanyPage.FirstCompany, TestData.Company1);
        }

        [TestMethod]
        public void employee_can_edit_his_company_profile()
        {
            //Arrange     
            var company = TestData.Company2;

            //Act
            EditCompanyPage.ModifyCompanyProfileWith(company);
            EditCompanyPage.GoTo();

            //Assert
            AreEqual(EditCompanyPage.FirstCompany, company);
        }

        private void AreEqual(Domain.Entities.Company company1, Domain.Entities.Company company2)
        {
            company1.Name.ShouldBeEquivalentTo(company2.Name);
            company1.Address.ShouldBeEquivalentTo(company2.Address);
            company1.Description.ShouldBeEquivalentTo(company2.Description);
            company1.Email.ShouldBeEquivalentTo(company2.Email);
            company1.PhoneNumber.ShouldBeEquivalentTo(company2.PhoneNumber);
            company1.WebSite.ShouldBeEquivalentTo(company2.WebSite);
        }
    }
}