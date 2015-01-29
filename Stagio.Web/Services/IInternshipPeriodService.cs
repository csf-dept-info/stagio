using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IInternshipPeriodService
    {
        bool IsCurrentDateInInternshipPeriod();

        void AddToPeriodRepository(InternshipPeriod period);

        InternshipPeriod GetActualInternshipPeriod();
    }
}
