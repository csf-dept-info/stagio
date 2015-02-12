using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Domain.SecurityUtilities;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.Controllers;

namespace Stagio.Web.UnitTests.Services
{

    [TestClass]
    public class AccountServiceTest : AllControllersBaseClassTests
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private IEntityRepository<Student> _studentRepository;
        private AccountService _accountService;

        [TestInitialize]
        public void test_initialize()
        {
            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _studentRepository = Substitute.For<IEntityRepository<Student>>();

            _accountService = new AccountService(_userRepository, _studentRepository);
        }

        [TestMethod]
        public void account_service_should_return_a_user_when_email_and_password_are_valid()
        {               
            const string pword = "pomme1230";
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            users.First().Password = _accountService.HashPassword(pword);
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser(users.First().Identifier, pword);

            user.First().ShouldBeEquivalentTo(users.First());
        }

        [TestMethod]
        public void account_service_should_return_empty_list_when_password_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser(users.First().Identifier, "INVALID PASSWORD");

            user.Should().BeEmpty();
        }

        [TestMethod]
        public void account_service_should_return_empty_list_when_email_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser("INVALID EMAIL", users.First().Password);

            user.Should().BeEmpty();
        }

        [TestMethod]
        public void account_service_get_student_by_identifier_should_user_if_found()
        {
            var users = _fixture.CreateMany<Student>(3).AsQueryable();
            _studentRepository.GetAll().Returns(users);

            var user = _accountService.GetStudentByStudentId(users.First().StudentId);

            user.Should().Be(users.First());
        }

        [TestMethod]
        public void account_service_get_student_by_identifier_should_null_if_user_not_found()
        {
            var users = _fixture.CreateMany<Student>(3).AsQueryable();
            _studentRepository.GetAll().Returns(users);

            var user = _accountService.GetStudentByStudentId("invalidIdentifier");

            user.Should().BeNull();
        }

        [TestMethod]
        public void account_service_student_exist_should_return_true_if_student_exist()
        {
            var users = _fixture.CreateMany<Student>(3).AsQueryable();
            _studentRepository.GetAll().Returns(users);

            var exist = _accountService.StudentExist("invalidIdentifier");

            exist.Should().BeFalse();
        }

        [TestMethod]
        public void account_service_student_exist_should_return_false_if_student_does_not_exist()
        {
            var users = _fixture.CreateMany<Student>(3).AsQueryable();
            _studentRepository.GetAll().Returns(users);

            var exist = _accountService.StudentExist(users.First().StudentId);

            exist.Should().BeTrue();
        }

        [TestMethod]
        public void account_service_user_exist_should_return_true_if_user_exist()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var exist = _accountService.UserIdentifierExist("invalidIdentifier");

            exist.Should().BeFalse();
        }

        [TestMethod]
        public void account_service_user_exist_should_return_false_if_user_does_not_exist()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var exist = _accountService.UserIdentifierExist(users.First().Identifier);

            exist.Should().BeTrue();
        }
    }
}