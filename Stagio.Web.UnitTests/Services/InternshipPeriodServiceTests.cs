using System.Linq;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.Controllers;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class InternshipPeriodServiceTests : AllControllersBaseClassTests
    {
        public IInternshipPeriodService _internshipPeriodService;
        public IEntityRepository<InternshipPeriod> _internshipPeriodRepository;

        [TestInitialize]
        public void Initialize()
        {
            _internshipPeriodRepository = Substitute.For<IEntityRepository<InternshipPeriod>>();
            _internshipPeriodService = Substitute.For<InternshipPeriodService>(_internshipPeriodRepository);
        }

        [TestMethod]
        public void add_period_should_add_to_internship_period_repository_when_valid()
        {
            // Arrange
            var period = TestData.ValidInternshipPeriod;

            //Act
            _internshipPeriodService.AddToPeriodRepository(period);

            // Assert
            _internshipPeriodRepository.Received().Add(Arg.Is<InternshipPeriod>(x => x.Id == period.Id));
        }

        [TestMethod]
        public void is_current_date_in_internship_period_should_return_true_if_repository_is_empty()
        {
            // Arrange

            //Act
            var validPeriod = _internshipPeriodService.IsCurrentDateInInternshipPeriod();

            // Assert
            validPeriod.Should().BeTrue();
        }

        [TestMethod]
        public void is_current_date_in_internship_period_should_return_true_if_current_date_is_in_the_period()
        {
            // Arrange
            var periods = _fixture.CreateMany<InternshipPeriod>(3).AsQueryable();
            periods.Last().StartDate = TestData.ValidInternshipPeriod.StartDate;
            periods.Last().EndDate = TestData.ValidInternshipPeriod.EndDate;

            _internshipPeriodRepository.GetAll().Returns(periods);

            //Act

            var validPeriod = _internshipPeriodService.IsCurrentDateInInternshipPeriod();

            // Assert
            validPeriod.Should().BeTrue();
        }

        [TestMethod]
        public void is_current_date_in_internship_period_should_return_false_if_current_date_is_not_in_the_period()
        {
            // Arrange

            var periods = _fixture.CreateMany<InternshipPeriod>(3).AsQueryable();
            periods.Last().StartDate = TestData.InvalidInternshipPeriod.StartDate;
            periods.Last().EndDate = TestData.InvalidInternshipPeriod.EndDate;

            _internshipPeriodRepository.GetAll().Returns(periods);

            //Act
            var validPeriod = _internshipPeriodService.IsCurrentDateInInternshipPeriod();

            // Assert
            validPeriod.Should().BeFalse();
        }
    }
}
