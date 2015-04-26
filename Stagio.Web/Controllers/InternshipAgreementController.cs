using System;
using System.Web;
using System.Web.Mvc;

using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.InternshipAgreement;

using AutoMapper;

namespace Stagio.Web.Controllers
{
    public partial class InternshipAgreementController : Controller
    {
        private readonly IEntityRepository<InternshipAgreement> _agreementRepository;
        private readonly IEntityRepository<InternshipApplication> _applicationRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IHttpContextService _httpContext;
        private readonly NotificationService _notificationService;

        public InternshipAgreementController(
            IEntityRepository<InternshipAgreement> agreementRepository,
            IEntityRepository<InternshipApplication> applicationRepository,
            IEntityRepository<Coordinator> coordinatorRepository,
            NotificationService notificationService,
            IHttpContextService httpContext)
        {
            DependencyService.VerifyDependencies(agreementRepository, applicationRepository, coordinatorRepository, httpContext);
            
            _agreementRepository = agreementRepository;
            _applicationRepository = applicationRepository;
            _coordinatorRepository = coordinatorRepository;
            _notificationService = notificationService;
            _httpContext = httpContext;
        }

        [Authorize(Roles = RoleNames.Coordinator)]
        public virtual ActionResult Create(int internshipApplicationId)
        {
            var application = _applicationRepository.GetById(internshipApplicationId);

            if (application == null)
            {
                return HttpNotFound();
            }

            var coordinator = _coordinatorRepository.GetById(_httpContext.GetUserId());

            var internshipAgreementViewModel = new Create()
            {
                InternshipApplicationId = application.Id,

                StudentName = application.ApplyingStudent.FullName(),
                StudentIdentifier = application.ApplyingStudent.StudentId,

                CompanyName = application.InternshipOffer.Company.Name,
                CompanyAddress = application.InternshipOffer.Company.Address,

                PersonInCharge = Mapper.Map<Stagio.Web.ViewModels.InternshipOffer.StaffMember>(application.InternshipOffer.PersonInCharge),

                Coordinator = Mapper.Map<Stagio.Web.ViewModels.InternshipOffer.StaffMember>(coordinator),

                CompanyCommitmentMessage = WebMessage.InternshipAgreementMessage.CompanySection.COMMITMENT_MESSAGE,
                StudentCommitmentMessage = WebMessage.InternshipAgreementMessage.StudentSection.COMMITMENT_MESSAGE,
                SchoolCommitmentMessage = WebMessage.InternshipAgreementMessage.SchoolSection.COMMITMENT_MESSAGE,

            };

            return View(internshipAgreementViewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Coordinator)]
        public virtual ActionResult Create(Create viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var application = _applicationRepository.GetById(viewModel.InternshipApplicationId);

            if (application == null)
            {
                return HttpNotFound();
            }

            var internshipAgreement = Mapper.Map<InternshipAgreement>(viewModel);

            _agreementRepository.Add(internshipAgreement);

            string feedbackMessage = WebMessage.InternshipAgreementMessage.AGREEMENT_CREATE_SUCCESS;

            _notificationService.NotifyInternhipAgreementActivated(viewModel.Id, viewModel.CompanyName, internshipAgreement.InternshipApplicationId, internshipAgreement.PersonInChargeId, internshipAgreement.Coordinator.Id);

            return RedirectToAction(MVC.InternshipApplication.GetApplicationsForSpecificStudent(application.ApplyingStudent.Id).Success(feedbackMessage));
        }
    }
}