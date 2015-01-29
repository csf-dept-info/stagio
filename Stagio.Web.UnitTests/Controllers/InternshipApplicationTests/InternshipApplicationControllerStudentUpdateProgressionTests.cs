using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.InternshipApplication;

using AutoMapper;
using NSubstitute;
using Ploeh.AutoFixture;
using FluentAssertions;

namespace Stagio.Web.UnitTests.Controllers.InternshipApplicationTests
{
    [TestClass]
    public class InternshipApplicationControllerStudentUpdateProgressionTests : InternshipApplicationControllerBaseClassTests
    {
        [TestMethod]
        public void upgrade_progression_post_should_return_http_not_found_if_internship_application_id_does_not_exist()
        {
            //Arrange   
            var application = this.init_internship_application();

            var student = this.init_logged_in_student();

            application.StudentId = student.Id;

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            var wrongApplication = _fixture.Create<InternshipApplication>();
            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(wrongApplication);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void upgrade_progression_post_should_return_http_not_found_if_current_student_id_does_not_exist()
        {
            //Arrange   
            var application = this.init_internship_application();

            var student = _fixture.Create<Student>();
            application.StudentId = student.Id;

            var wrongStudent = _fixture.Create<Student>();
            _httpContext.GetUserId().Returns(wrongStudent.Id);
            _studentRepository.GetById(student.Id).Returns(wrongStudent);

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(application);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void upgrade_progression_post_should_return_http_not_found_if_internship_application_student_id_does_not_correspond_to_current_connected_student()
        {
            //Arrange   
            var application = this.init_internship_application();

            var student = this.init_logged_in_student();

            var wrongStudent = _fixture.Create<Student>();
            application.StudentId = wrongStudent.Id;

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(application);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void upgrade_progression_post_should_return_http_not_found_if_internship_application_is_already_at_maximum_progression()
        {
            //Arrange   
            var application = this.init_internship_application();
            application.Progression = InternshipApplication.ApplicationStatus.StudentAcceptedOffer;
            
            var student = this.init_logged_in_student();
            application.StudentId = student.Id;

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(application);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel);

            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void upgrade_progression_post_should_update_internship_application_status_to_studentHadInterview_if_status_was_studentHasApplied()
        {
            //Arrange   
            var application = this.init_internship_application();
            application.Progression = InternshipApplication.ApplicationStatus.StudentHasApplied;

            var student = this.init_logged_in_student();
            application.StudentId = student.Id;

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(application);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel);

            //Assert
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.Id == application.Id));
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.Progression == InternshipApplication.ApplicationStatus.StudentHadInterview));
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.InterviewDate == applicationViewModel.LastProgressionUpdateDate));
        
        }

        [TestMethod]
        public void upgrade_progression_post_should_update_internship_application_status_to_companyAcceptedStudent_if_status_was_studentHadInterview()
        {
            //Arrange   
            var application = this.init_internship_application();
            application.Progression = InternshipApplication.ApplicationStatus.StudentHadInterview;

            var student = this.init_logged_in_student();
            application.StudentId = student.Id;

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(application);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel);

            //Assert
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.Id == application.Id));
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.Progression == InternshipApplication.ApplicationStatus.CompanyAcceptedStudent));
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.CompanyAcceptedDate == applicationViewModel.LastProgressionUpdateDate));
        
        }

        [TestMethod]
        public void upgrade_progression_post_should_update_internship_application_status_to_studentAcceptedOffer_if_status_was_companyAcceptedStudent()
        {
            //Arrange   
            var application = this.init_internship_application();
            application.Progression = InternshipApplication.ApplicationStatus.CompanyAcceptedStudent;

            var student = this.init_logged_in_student();
            application.StudentId = student.Id;

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(application);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel);

            //Assert
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.Id == application.Id));
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.Progression == InternshipApplication.ApplicationStatus.StudentAcceptedOffer));
            _internshipApplicationRepository.Received().Update(Arg.Is<InternshipApplication>(x => x.StudentAcceptedDate == applicationViewModel.LastProgressionUpdateDate));

        }

        [TestMethod]
        public void upgrade_progression_post_should_return_to_student_application_index_if_data_is_valid()
        {
            //Arrange   
            var application = this.init_internship_application();
            application.Progression = InternshipApplication.ApplicationStatus.CompanyAcceptedStudent;

            var student = this.init_logged_in_student();
            application.StudentId = student.Id;

            var applicationViewModel = Mapper.Map<StudentIndex>(application);

            _internshipApplicationRepository.GetById(applicationViewModel.Id).Returns(application);

            //Act
            var result = _internshipApplicationController.UpdateProgression(applicationViewModel) as RedirectToRouteResult;

            //Assert
            result.RouteValues["Action"].ShouldBeEquivalentTo("StudentApplicationIndex");
        }

        private InternshipApplication init_internship_application()
        {
            var application = _fixture.Create<InternshipApplication>();
            application.InternshipOffer = _fixture.Create<InternshipOffer>();
            application.InternshipOffer.Company = _fixture.Create<Company>();
            application.Progression = InternshipApplication.ApplicationStatus.StudentHasApplied;

            return application;
        }

        private Student init_logged_in_student()
        {
            var student = _fixture.Create<Student>();
            _httpContext.GetUserId().Returns(student.Id);
            _studentRepository.GetById(student.Id).Returns(student);

            return student;
        }
    }
}
