using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Company;

namespace Stagio.Web.UnitTests.Controllers.CompanyTests
{
    [TestClass]
    public class CompanyControllerCreateTests : CompanyBaseTests
    {
        [TestMethod]
        public void create_company_should_render_default_view()
        {
            var result = _companyController.Create() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void create_company_post_should_add_company_to_repository()
        {
            // Arrange   
            var company = _fixture.Create<Company>();
            var companyViewModel = Mapper.Map<Create>(company);
            var companyList = _fixture.CreateMany<Company>().AsQueryable();
            _companyRepository.GetAll().Returns(companyList);

            // Action
            _companyController.Create(companyViewModel);

            // Assert
            _companyRepository.Received().Add(Arg.Is<Company>(x => x.Id == company.Id));
        }

        [TestMethod]
        public void create_company_post_should_return_default_view_when_models_tate_is_not_valid()
        {
            //Arrange
            var companyViewModel = _fixture.Create<Create>();
            _companyController.ModelState.AddModelError("Error", "Error");
            var companyList = _fixture.CreateMany<Company>().AsQueryable();
            _companyRepository.GetAll().Returns(companyList);

            //Act
            var result = _companyController.Create(companyViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void create_company_post_should_return_default_view_if_company_name_already_exist()
        {
            //Arrange
            const int NUMBER_OF_COMPANIES_CREATED = 1;
           
            var companyViewModel = _fixture.Create<Create>();
            var company = _fixture.CreateMany<Company>(NUMBER_OF_COMPANIES_CREATED).AsQueryable();
            _companyRepository.GetAll().Returns(company);
            companyViewModel.Name = company.FirstOrDefault().Name;

            //Act
            var result = _companyController.Create(companyViewModel) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }
    }
}
