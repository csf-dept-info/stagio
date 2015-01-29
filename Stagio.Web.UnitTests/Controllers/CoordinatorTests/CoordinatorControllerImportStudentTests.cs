using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Web.ViewModels.Coordinator;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerImportStudentTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void import_student_should_return_default_view()
        {
            var viewResult = _coordinatorController.ImportStudent() as ViewResult;

            viewResult.ViewName.Should().Be(MVC.Coordinator.Views.ImportStudent);
        }

        [TestMethod]
        public void import_student_should_return_import_student_view_if_file_extension_is_invalid()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            _fileService.IsFileValid(".csv", file).Returns(false);

            var viewResult = _coordinatorController.ImportStudent(file) as ViewResult;
            var viewObtained = viewResult.ViewName;

            viewObtained.Should().Be(MVC.Coordinator.Views.ViewNames.ImportStudent);
        }

        [TestMethod]
        public void import_student_should_return_import_student_view_if_file_contain_invalid_data()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            _fileService.IsFileValid(".csv", file).Returns(true);
            IEnumerable<ImportStudentViewModel> importStudentViewModel = null;
            _fileService.ImportStudentInformationsFromFile(file).Returns(importStudentViewModel);

            var viewResult = _coordinatorController.ImportStudent(file) as ViewResult;
            var viewObtained = viewResult.ViewName;

            viewObtained.Should().Be(MVC.Coordinator.Views.ViewNames.ImportStudent);
        }

        [TestMethod]
        public void import_student_should_return_import_student_view_if_file_is_empty()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            _fileService.IsFileValid(".csv", file).Returns(true);
            var importStudentsViewModel = new List<Stagio.Web.ViewModels.Coordinator.ImportStudentViewModel>();
            _fileService.ImportStudentInformationsFromFile(file).Returns(importStudentsViewModel);

            var viewResult = _coordinatorController.ImportStudent(file) as ViewResult;
            var viewObtained = viewResult.ViewName;

            viewObtained.Should().Be(MVC.Coordinator.Views.ViewNames.ImportStudent);
        }

        [TestMethod]
        public void import_student_should_return_validate_import_view_if_file_contain_valid_data()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            const string viewExpected = "~/Views/Coordinator/ValidateImport.cshtml"; //TODO fix view returnName;
            var importStudentsViewModel = new List<Stagio.Web.ViewModels.Coordinator.ImportStudentViewModel>();


            importStudentsViewModel.Add(_fixture.Create<ImportStudentViewModel>());
            importStudentsViewModel.Add(_fixture.Create<ImportStudentViewModel>());
            _fileService.IsFileValid(".csv", file).Returns(true);
            _fileService.ImportStudentInformationsFromFile(file).Returns(importStudentsViewModel);

            var viewResult = _coordinatorController.ImportStudent(file) as ViewResult;
            var viewObtained = viewResult.ViewName;

            viewObtained.Should().Be(viewExpected);
        }
    }
}



