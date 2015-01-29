using System;
using System.Linq;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public class InternshipPeriodService : IInternshipPeriodService
    {
        private readonly IEntityRepository<InternshipPeriod> _internshipPeriodRepository;

        public InternshipPeriodService(IEntityRepository<InternshipPeriod> internshipPeriodRepository)
        {
            _internshipPeriodRepository = internshipPeriodRepository;
        }

        public bool IsCurrentDateInInternshipPeriod()
        {
            var period = GetActualInternshipPeriod();

            if (period == null)
            {
                return true;
            }

            var vmPeriod = Mapper.Map<ViewModels.Coordinator.ChoosePeriod>(period);

            var start = vmPeriod.StartDate;
            var end = vmPeriod.EndDate;
            var now = DateTime.Now;

            return start <= now && now <= end;
        }

        public void AddToPeriodRepository(InternshipPeriod period)
        {
            _internshipPeriodRepository.Add(period);
        }

        public InternshipPeriod GetActualInternshipPeriod()
        {
            var periodRepo = _internshipPeriodRepository.GetAll().ToList();

            return periodRepo.LastOrDefault();
        }
    }
}