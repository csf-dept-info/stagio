using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerArchivesTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void archives_list_should_return_view_with_past_internship_periods()
        {
            const int ARCHIVES_COUNT = 2;
            var archives = _fixture.CreateMany<DepartmentalArchives>(ARCHIVES_COUNT);

            _archivesService.GetArchives().Returns(archives.AsQueryable());

            var result = _coordinatorController.InternshipsPeriodsList() as ViewResult;
            var model = result.Model as ViewModels.Coordinator.PeriodsList;

            model.ShouldBeEquivalentTo(archives, options => options.ExcludingMissingProperties());
        }

        [TestMethod]
        public void details_should_return_view_with_model_when_archive_id_is_valid()
        {
            //Arrange
            var archive = _fixture.Create<DepartmentalArchives>();
            _archivesService.GetArchiveById(archive.Id).Returns(archive);
            var viewModelExpected = Mapper.Map<ViewModels.Archives.Details>(archive);

            //Action
            var viewResult = _coordinatorController.InternshipPeriodDetails(archive.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Archives.Details;

            //Assert
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);
        }

        [TestMethod]
        public void details_should_return_http_not_found_when_archive_id_is_invalid()
        {
            const int INVALID_ID = 9999;

            var result = _coordinatorController.InternshipPeriodDetails(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
