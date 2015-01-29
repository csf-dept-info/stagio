using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Company;
using Company = Stagio.Domain.Entities.Company;

namespace Stagio.Web.UnitTests.Controllers.CompanyTests
{
    [TestClass]
    public class CompanyControllerEditTests : CompanyBaseTests
    {
        [TestMethod]
        public void edit_should_return_view_with_companyVM_when_companyId_isValid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            var company = _fixture.Create<Company>();
            company.Employees.Add(employee);
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _companyRepository.GetById(employee.CompanyId).Returns(company);
            _httpContextService.GetUserId().Returns(employee.Id);
            var viewModelExpected = Mapper.Map<Edit>(company);

            //Action
            var viewResult = _companyController.Edit() as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as Edit;

            //Assert
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_employee_id_is_invalid()
        {
            //Arrange
            const int INVALID_ID = 9999;
            _httpContextService.GetUserId().Returns(INVALID_ID);

            //Action
            var result = _companyController.Edit();

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_company_id_is_invalid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            Company company = null;

            _employeeRepository.GetById(employee.Id).Returns(employee);
            _companyRepository.GetById(employee.CompanyId).Returns(company);
            _httpContextService.GetUserId().Returns(employee.Id);

            //Action
            var result = _companyController.Edit();

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_company_when_companyId_is_valid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContextService.GetUserId().Returns(employee.Id);

            var company = _fixture.Create<Company>();
            _companyRepository.GetById(employee.CompanyId).Returns(company);
            var companyViewModel = Mapper.Map<Edit>(company);

            //Action
            var actionResult = _companyController.Edit(companyViewModel);

            // Assert
            _companyRepository.Received().Update(Arg.Is<Company>(x => x.Id == company.Id));
        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContextService.GetUserId().Returns(employee.Id);

            var company = _fixture.Create<Company>();
            _companyRepository.GetById(employee.CompanyId).Returns(company);
            var companyEditPageViewModel = Mapper.Map<Company, Edit>(company);

            //Act
            var routeResult = _companyController.Edit(companyEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _employeeRepository.GetById(employee.Id).Returns(employee);
            _httpContextService.GetUserId().Returns(employee.Id);

            var company = _fixture.Create<Company>();
            _companyRepository.GetById(employee.CompanyId).Returns(company);
            var companyEditPageViewModel = Mapper.Map<Company, Edit>(company);

            _companyController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _companyController.Edit(companyEditPageViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");

        }

        [TestMethod]
        public void edit_post_should_return_http_not_found_when_companyID_is_not_valid()
        {
            //Arrange 
            var company = _fixture.Create<Edit>();
            _companyRepository.GetById(Arg.Any<int>()).Returns(a => null);

            //Act
            var result = _companyController.Edit(company);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
