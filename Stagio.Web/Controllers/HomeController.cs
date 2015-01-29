using System;
using System.Web.Mvc;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public partial class HomeController : Controller
    {
        private readonly IInternshipPeriodService _internshipPeriodService;

        public HomeController(IInternshipPeriodService internshipPeriodService)
        {
            if (internshipPeriodService == null) throw new NullReferenceException();
            _internshipPeriodService = internshipPeriodService;
        }

        public virtual ActionResult Index()
        {
            return View(_internshipPeriodService.IsCurrentDateInInternshipPeriod());
        }
    }
}