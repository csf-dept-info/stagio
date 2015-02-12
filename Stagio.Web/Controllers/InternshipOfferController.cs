using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.Controllers.Utilities;
using Stagio.Web.ViewModels.InternshipOffer;
using AutoMapper;


namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public partial class InternshipOfferController : Controller
    {
        //Todo YM: cette classe contient beaucoup de repository. C'est un mauvais signe. 
        //Voir commentaire dans le post creat ci-dessous pour piste de solution.
        private readonly IEntityRepository<InternshipOffer> _internshipOfferRepository;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IEntityRepository<InternshipApplication> _internshipApplicationRepository;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IHttpContextService _httpContextService;
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;
        private readonly IFileSaveService _fileService;

        public InternshipOfferController(
            IEntityRepository<InternshipOffer> intershipOfferRepository,
            IEntityRepository<Employee> employeeRepository,
            IHttpContextService httpContextService,
            IEntityRepository<Coordinator> coordinatorRepository,
            IEmailService emailService,
            IFileSaveService fileSaveService,
            IEntityRepository<InternshipApplication> internshipApplicationRepository,
            INotificationService notificationService)
        {
            DependencyService.VerifyDependencies(intershipOfferRepository, employeeRepository, httpContextService, coordinatorRepository, emailService, fileSaveService, internshipApplicationRepository, notificationService);
            
            _internshipOfferRepository = intershipOfferRepository;
            _employeeRepository = employeeRepository;
            _httpContextService = httpContextService;
            _coordinatorRepository = coordinatorRepository;
            _emailService = emailService;
            _fileService = fileSaveService;
            _internshipApplicationRepository = internshipApplicationRepository;
            _notificationService = notificationService;
        }

        [Authorize(Roles = RoleNames.Student)]
        public virtual ActionResult StudentIndex()
        {
            var applicationOffers = GetInternshipOffersForCurrentStudent();

            var internshipOffers = _internshipOfferRepository.GetAll().ToList();

            var offersNoneApplicated = internshipOffers.Where(offer =>
                    applicationOffers.All(app => app.Id != offer.Id))
                .Where(offer => offer.Status == InternshipOffer.OfferStatus.Publicated)
                .ToList();

            var internshipOfferIndexViewModels = Mapper.Map<IEnumerable<Index>>(offersNoneApplicated);

            return View(MVC.InternshipOffer.Views.ViewNames.Index, internshipOfferIndexViewModels);
        }

        [Authorize(Roles = RoleNames.Coordinator)]
        public virtual ActionResult CoordinatorIndex()
        {
            var internshipOffers = _internshipOfferRepository.GetAll()
                .Where(offer => offer.Status != InternshipOffer.OfferStatus.Draft).ToList();

            var internshipOfferIndexViewModels = Mapper.Map<IEnumerable<ViewModels.InternshipOffer.Index>>(internshipOffers);
            ViewBag.PublicatedOffersOnly = false;
            return View(MVC.InternshipOffer.Views.ViewNames.Index, internshipOfferIndexViewModels);
        }

        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult EmployeeIndex()
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            var internshipOffers = _internshipOfferRepository.GetAll()
                .Where(offer => offer.CompanyId == employee.CompanyId).ToList();

            var internshipOfferIndexViewModels = Mapper.Map<IEnumerable<ViewModels.InternshipOffer.Index>>(internshipOffers);
            ViewBag.PublicatedOffersOnly = false;

            return View(MVC.InternshipOffer.Views.ViewNames.Index, internshipOfferIndexViewModels);
        }

        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult EmployeePublicatedOffersIndex()
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            var internshipOffers = _internshipOfferRepository.GetAll()
                .Where(offer => offer.CompanyId == employee.CompanyId)
                .Where(offer => offer.Status == InternshipOffer.OfferStatus.Publicated)
                .ToList();

            var internshipApplications = _internshipApplicationRepository.GetAll();

            var query = internshipOffers.Join(internshipApplications,
                    c => c.Id,
                    cm => cm.InternshipOfferId,
                    (c, cm) => new { Offer = c, application = cm })
                    .Select(x => x.Offer)
                    .Distinct();

            var internshipOfferIndexViewModels = Mapper.Map<IEnumerable<ViewModels.InternshipOffer.Index>>(query);
            ViewBag.PublicatedOffersOnly = true;

            return View(MVC.InternshipOffer.Views.ViewNames.Index, internshipOfferIndexViewModels);
        }

        [Authorize(Roles = RoleNames.Coordinator)]
        public virtual ActionResult CoordinatorPublicatedOffersIndex()
        {
            var internshipOffers = _internshipOfferRepository.GetAll()
                .Where(offer => offer.Status == InternshipOffer.OfferStatus.Publicated).ToList();

            var internshipApplications = _internshipApplicationRepository.GetAll();

            var query = internshipOffers.Join(internshipApplications,
                    c => c.Id,
                    cm => cm.InternshipOfferId,
                    (c, cm) => new { Offer = c, application = cm })
                    .Select(x => x.Offer).Distinct().ToList();

            var internshipOfferIndexViewModels = Mapper.Map<IEnumerable<ViewModels.InternshipOffer.Index>>(query);
            ViewBag.PublicatedOffersOnly = true;

            return View(MVC.InternshipOffer.Views.ViewNames.Index, internshipOfferIndexViewModels);
        }

        public virtual ActionResult ValidateOffer(int id)
        {
            var internshipOffer = _internshipOfferRepository.GetById(id);

            if (internshipOffer == null)
            {
                return HttpNotFound();
            }
            
            internshipOffer.Status = InternshipOffer.OfferStatus.Publicated;

            _internshipOfferRepository.Update(internshipOffer);

            _notificationService.RoleGroupNotification(RoleNames.Student, WebMessage.NotificationMessage.NEW_INTERNSHIP_OFFER_PUBLICATED, "InternshipOffer", "StudentIndex");
            _notificationService.CompanyNotification(internshipOffer.Company, WebMessage.NotificationMessage.ONE_OF_YOUR_OFFER_HAS_BEEN_PUBLICATED, "InternshipOffer", "EmployeePublicatedOffersIndex");

            const string feedbackMessage = WebMessage.InternshipOfferMessage.OFFER_ACCEPTED_SUCCESS;

            return RedirectToAction(MVC.InternshipOffer.CoordinatorIndex().Success(feedbackMessage));
        }

        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult Create()
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            if (employee == null)
            {
                return HttpNotFound();
            }

            //Créer une offre de stage avec des informations déjà préremplies
            var internshipOfferViewModel = new Create
            {
                EmployeeId = employee.Id,
                CompanyId = employee.CompanyId,
                Company = employee.Company,

                //Créer un staffMember à partir des informations de l'employé
                Contact = new ViewModels.InternshipOffer.StaffMember
                {
                    Name = employee.FullName(),
                    Email = employee.Identifier,
                    PhoneNumber = employee.FullPhoneNumber()
                },

                NumberOfTrainees = 1,

                Deadline = DateTime.Now.Date,
            };

            return View(internshipOfferViewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        [MultipleButton(Name = "action", Argument = "Create")]
        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult Create(Create internshipOfferViewModel)
        {
            //Todo YM Cette méthode contient beaucoup de responsabilités. Un refactoring important est à faire. 
            //Envisager de déléguer des resposabilités à un service InterShipOfferService (qui lui utilise les repositories nécessaires)
            //D'autres méthodes de cette classe pourraient sans aucun doute utiliser se service. 

            bool otherContactIgnored = false;

            if (AreFieldsEmpty(internshipOfferViewModel.OtherContact))
            {
                ModelState.Remove("OtherContact.Id");
                ModelState.Remove("OtherContact.Name");
                ModelState.Remove("OtherContact.Title");
                ModelState.Remove("OtherContact.PhoneNumber");
                ModelState.Remove("OtherContact.Email");

                otherContactIgnored = true;
            }

            if (FileFieldIsEmpty(internshipOfferViewModel))
            {
                ModelState.Remove("ExtraFile");
            }

            if (!ModelState.IsValid)
            {
                return View(internshipOfferViewModel);
            }

            string pathToExtraFile = null;
            if (!FileFieldIsEmpty(internshipOfferViewModel))
            {
                var employee = _employeeRepository.GetById(internshipOfferViewModel.EmployeeId);

                string pathEnding = _fileService.SaveOfferExtraFile(employee, internshipOfferViewModel);

                pathToExtraFile = pathEnding + "\\" + internshipOfferViewModel.ExtraFile.FileName;
            }

            var internshipOffer = _internshipOfferRepository.GetById(internshipOfferViewModel.Id);

            var offerAlreadyExists = (internshipOffer != null);

            //Mapping the offer depending on whether it already exists or not
            if (offerAlreadyExists)
            {
                Mapper.Map(internshipOfferViewModel, internshipOffer);
            }
            else
            {
                internshipOffer = Mapper.Map<InternshipOffer>(internshipOfferViewModel);
            }

            //Assigning attributes
            if (otherContactIgnored)
            {
                internshipOffer.OtherContact = null;
            }

            internshipOffer.PublicationDate = DateTime.Now;
            internshipOffer.PathToExtraFile = pathToExtraFile;
            internshipOffer.Status = InternshipOffer.OfferStatus.OnValidation;

            //Adding or updating
            if (offerAlreadyExists)
            {
                _internshipOfferRepository.Update(internshipOffer);
            }
            else
            {
                _internshipOfferRepository.Add(internshipOffer);
                _notificationService.NotifyNewInternshipOfferCreated(_httpContextService.GetUserId());
            }

            const string feedbackMessage = WebMessage.InternshipOfferMessage.OFFER_CREATED_SUCCESS;

            return RedirectToAction(MVC.InternshipOffer.EmployeeIndex().Success(feedbackMessage));
        }

        [HttpPost]
        [ActionName("Create")]
        [MultipleButton(Name = "action", Argument = "SaveDraft")]
        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult SaveDraft(ViewModels.InternshipOffer.Create _internshipOfferViewModel)
        {
            ModelState.Clear();

            if (_internshipOfferViewModel.EmployeeId != _httpContextService.GetUserId())
            {
                return HttpNotFound();
            }

            var internshipOffer = _internshipOfferRepository.GetById(_internshipOfferViewModel.Id);

            bool offerAlreadyExists = (internshipOffer != null);

            if (offerAlreadyExists)
            {
                //Cette validation est nécéssaire car nos DateTime ne sont pas nullable
                if (_internshipOfferViewModel.Deadline == default(DateTime))
                {
                    _internshipOfferViewModel.Deadline = DateTime.Now;
                }

                Mapper.Map(_internshipOfferViewModel, internshipOffer);

                _internshipOfferRepository.Update(internshipOffer);
            }
            else
            {
                var newInternshipOffer = Mapper.Map<InternshipOffer>(_internshipOfferViewModel);
                newInternshipOffer.PublicationDate = DateTime.Now;
                newInternshipOffer.Status = InternshipOffer.OfferStatus.Draft;

                _internshipOfferRepository.Add(newInternshipOffer);
            }

            const string feedbackMessage = WebMessage.InternshipOfferMessage.OFFER_DRAFT_SUCCESS;

            return RedirectToAction(MVC.InternshipOffer.EmployeeIndex().Warning(feedbackMessage));
        }

        public virtual ActionResult Edit(int offerId)
        {
            var internshipOffer = _internshipOfferRepository.GetById(offerId);

            if (internshipOffer == null)
            {
                //Todo YM: retour httpNotFound non testé
                return HttpNotFound();
            }
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            var offerVm = Mapper.Map<ViewModels.InternshipOffer.Create>(internshipOffer);
            offerVm.EmployeeId = employee.Id;

            return View("Create", offerVm);
        }

        public virtual ActionResult Details(int offerId)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }
            var internshipOffer = _internshipOfferRepository.GetById(offerId);

            if (internshipOffer == null)
            {
                return HttpNotFound();
            }

            var appList = GetInternshipOffersForCurrentStudent();

            ViewBag.IsApplicated = appList.Contains(internshipOffer);

            var offerVm = Mapper.Map<FullOffer>(internshipOffer);
            
            return View(offerVm);
        }

        [HttpPost]
        public virtual ActionResult Details(ViewModels.InternshipOffer.FullOffer offerVm)
        {
            Coordinator coordinator;
            InternshipOffer internshipOffer;

            try
            {
                internshipOffer = _internshipOfferRepository.GetById(offerVm.Id);
                offerVm.Title = internshipOffer.Title;
                coordinator = _coordinatorRepository.GetById(_httpContextService.GetUserId());
            }
            catch (Exception)
            {
                return HttpNotFound();
            }

            try
            {
                var mail = _emailService.BuildMail(internshipOffer.Contact.Email, coordinator.Identifier,
                           WebMessage.InternshipOfferMessage.DENY_OFFER_MAIL_SUBJECT, BuildDenyMailBody(offerVm));
                UpdateInternshipOfferToRefusedStatus(internshipOffer);
                _emailService.SendEmail(mail);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Body", WebMessage.InternshipOfferMessage.GENERIC_DENY_ERROR);
            }

            if (!ModelState.IsValid)
            {
                return View(MVC.InternshipOffer.Views.ViewNames.Details, internshipOffer);
            }

            const string feedbackMessage = WebMessage.InternshipOfferMessage.OFFER_DENIED_SUCCESS;

            return RedirectToAction(MVC.InternshipOffer.CoordinatorIndex().Success(feedbackMessage));
        }


        [HttpPost]
        [MultipleButton(Name = "action", Argument = "DeleteDraft")]
        public virtual ActionResult DeleteDraft(ViewModels.InternshipOffer.Create internshipOfferViewModel)
        {
            var offerId = internshipOfferViewModel.Id;
            var offer = _internshipOfferRepository.GetById(offerId);
            if (offer == null)
            {
                return HttpNotFound();
            }

            _internshipOfferRepository.Delete(offer);
            return RedirectToAction(MVC.InternshipOffer.EmployeeIndex()).Information(WebMessage.InternshipOfferMessage.DRAFT_DELETED_SUCCESS);
        }

        private bool AreFieldsEmpty(ViewModels.InternshipOffer.StaffMember _staffMember)
        {
            if (_staffMember == null)
            {
                return true;
            }

            var fieldsAreEmpty = (_staffMember.Name == null && _staffMember.Title == null &&
               _staffMember.PhoneNumber == null && _staffMember.Email == null);

            return fieldsAreEmpty;
        }

        private bool FileFieldIsEmpty(ViewModels.InternshipOffer.Create _create)
        {
            return (_create == null || _create.ExtraFile == null);
        }

        public virtual ActionResult DownloadFile(string pathToExtraFile, int offerId)
        {
            string pathBeginning;
            try
            {
                pathBeginning = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            }
            catch
            {
                pathBeginning = "";
            }
            string extraFilePath = pathBeginning + pathToExtraFile;

            string fileName = pathToExtraFile.Split('\\').Last();

            if (System.IO.File.Exists(extraFilePath))
            {
                return File(extraFilePath, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

            ModelState.AddModelError("pathToExtraFile", WebMessage.ErrorMessage.FILE_NOT_FOUND);
            TempData["ViewData"] = ViewData;
            return RedirectToAction(MVC.InternshipOffer.Details(offerId));
        }

        private void UpdateInternshipOfferToRefusedStatus(InternshipOffer internshipOffer)
        {
            internshipOffer.Status = InternshipOffer.OfferStatus.Refused;
            _internshipOfferRepository.Update(internshipOffer);
        }

        private static string BuildDenyMailBody(FullOffer offerVm)
        {
            //TODO Ajuster le message comme Guillaume le voulait. Ex.: Ajouter un lien vers le site (voir feuille de notes)
            var body = "Bonjour, " + Environment.NewLine + Environment.NewLine + "Votre offre " + offerVm.Title +
                       " a été refusée. Voici les raisons:" + Environment.NewLine + Environment.NewLine +
                       offerVm.DenyMessage;

            return body;
        }

        private IEnumerable<InternshipOffer> GetInternshipOffersForCurrentStudent()
        {
            var userId = _httpContextService.GetUserId();

            var appList = _internshipApplicationRepository.GetAll().AsEnumerable();
            var offerList = _internshipOfferRepository.GetAll().AsEnumerable();

            var query = offerList.Join(appList,
                    c => c.Id,
                    cm => cm.InternshipOfferId,
                    (c, cm) => new { Offer = c, application = cm })
                .Where(x => x.application.StudentId == userId)
                .Select(x => x.Offer);

            return query;
        }
    }
}
