using System.Web.Mvc;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.Archives
{
    public class Index
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public InternshipPeriod InternshipPeriod { get; set; }
    }
}