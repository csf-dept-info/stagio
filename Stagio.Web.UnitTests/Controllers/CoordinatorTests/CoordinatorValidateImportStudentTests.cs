using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Coordinator;
using NSubstitute;
using Ploeh.AutoFixture;
using FluentAssertions;

namespace Stagio.Web.UnitTests.Controllers.CoordinatorTests
{
    [TestClass]
    public class CoordinatorValidateImportStudentTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void validate_import_should_return_to_index_if_import_succeeded()
        {
            var importStudentsViewModel = new List<ImportStudentViewModel>
            {
                _fixture.Create<ImportStudentViewModel>(),
                _fixture.Create<ImportStudentViewModel>()
            };

            var result = _coordinatorController.ValidateImport(importStudentsViewModel) as RedirectToRouteResult;

            var action = result.RouteValues["Action"];

            action.Should().Be(MVC.Coordinator.Views.ViewNames.Index);
        }

        [TestMethod]
        public void validate_import_should_add_student_to_repository_if_student_are_new_subscriber()
        {
            var importStudentsViewModel = new List<ImportStudentViewModel>
            {
                _fixture.Create<ImportStudentViewModel>(),
                _fixture.Create<ImportStudentViewModel>()
            };

            var viewResult = _coordinatorController.ValidateImport(importStudentsViewModel) as ViewResult;

            foreach (var s in importStudentsViewModel)
            {
                _studentRepository.Received().Add(Arg.Is<Student>(x => x.Identifier == s.Identifier));
            }

        }

        [TestMethod]
        public void validate_import_should_renew_student_if_student_are_not_new_subscriber()
        {
            var importStudentsViewModel = _fixture.CreateMany<ImportStudentViewModel>(1);
            var studentQuerryable = _fixture.CreateMany<Student>(1).AsQueryable();

            _studentRepository.GetAll().Returns(studentQuerryable);
            _accountService.StudentExist(importStudentsViewModel.First().Identifier).Returns(true);
            studentQuerryable.First().Identifier = importStudentsViewModel.First().Identifier;

            _coordinatorController.ValidateImport(importStudentsViewModel);

            foreach (var s in importStudentsViewModel)
            {
                _studentRepository.Received().Update(Arg.Is<Student>(x => x.Identifier == s.Identifier));
            }

        }
    }
}

