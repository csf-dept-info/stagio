using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Company;

namespace Stagio.Web.UnitTests.Controllers.CompanyTests
{
    [TestClass]
    public class CompanyControllerChooseTests : CompanyBaseTests
    {
        [TestMethod]
        public void choose_company_should_render_default_view()
        {
            var result = _companyController.ChooseCompany() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void choose_company_should_return_view_with_companies()
        {
            // Arrange   
            const int OFFER_COUNT = 5;
            var companies = _fixture.CreateMany<Company>(OFFER_COUNT);
            _companyRepository.GetAll().Returns(companies.AsQueryable());
            var companiesEntities = new List<Company> { new Company { Name = WebMessage.CompanyMessage.NEW_COMPANY } };
            companiesEntities.AddRange(companies);

            // Action
            var result = _companyController.ChooseCompany() as ViewResult;
            
            var model = result.Model as ChooseCompany;

            // Assert
            model.CompaniesList.ShouldBeEquivalentTo(companiesEntities, options => options.ExcludingMissingProperties());
        }

        [TestMethod]
        public void choose_company_should_return_create_employee_view()
        {
            const int COMPANY_ID = 5;
            var company = _fixture.Create<ChooseCompany>();
            company.Id = COMPANY_ID;

            //Act
            var routeResult = _companyController.ChooseCompany(company) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Employee.Views.ViewNames.Create);
        }

        [TestMethod]
        public void choose_company_should_return_create_company_view()
        {
            const int COMPANY_ID = 0;
            var company = _fixture.Create<ChooseCompany>();
            company.SelectedCompanyId = COMPANY_ID;

            //Act
            var routeResult = _companyController.ChooseCompany(company) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Company.Views.ViewNames.Create);
        }
    }
}
