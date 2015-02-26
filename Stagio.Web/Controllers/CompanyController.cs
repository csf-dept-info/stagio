using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Company;
using Company = Stagio.Domain.Entities.Company;
using Edit = Stagio.Web.ViewModels.Company.Edit;
using System;

namespace Stagio.Web.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public partial class CompanyController : Controller
    {
        private readonly IEntityRepository<Company> _companyRepository;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IHttpContextService _httpContextService;
        private readonly INotificationService _notificationService;

        public CompanyController(
            IEntityRepository<Company> companyRepository,
            IEntityRepository<Employee> employeeRepository,
            IHttpContextService httpContextService,
            INotificationService notificationService)
        {
            DependencyService.VerifyDependencies(companyRepository, employeeRepository, httpContextService, notificationService);
            
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
            _httpContextService = httpContextService;
            _notificationService = notificationService;
        }

        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult Edit()
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());

            if (employee == null) return HttpNotFound();

            var company = _companyRepository.GetById(employee.CompanyId);

            if (company == null) return HttpNotFound();

            var viewModel = Mapper.Map<ViewModels.Company.Edit>(company);
            return View(viewModel);
        }


        [HttpPost]
        [Authorize(Roles = RoleNames.Employee)]
        public virtual ActionResult Edit(Edit companyViewModel)
        {
            var employee = _employeeRepository.GetById(_httpContextService.GetUserId());
           
            if (employee == null) { return HttpNotFound(); }
            
            var company = _companyRepository.GetById(employee.CompanyId);
            
            if (company == null) { return HttpNotFound(); }

            if (!ModelState.IsValid)
            {
                companyViewModel = Mapper.Map<Edit>(company);
                return View(companyViewModel);
            }

            Mapper.Map(companyViewModel, company);

            _companyRepository.Update(company);

            const string feedbackMessage = WebMessage.EmployeeMessage.COMPANY_PROFILE_EDIT_SUCCESS;
            
            return RedirectToAction(MVC.Employee.Index().Success(feedbackMessage));
        }

        public virtual ActionResult ChooseCompany()
        {
            var company = new ChooseCompany();

            var defaultCompany = new Company {Name = WebMessage.CompanyMessage.NEW_COMPANY};
            var companiesEntities = new List<Company> {defaultCompany};
            companiesEntities.AddRange(_companyRepository.GetAll().ToList());

            var companiesViewModels = Mapper.Map<List<CompanyItem>>(companiesEntities);

            company.CompaniesList = companiesViewModels;

            return View(company);
        }

        [HttpPost]
        public virtual ActionResult ChooseCompany(ChooseCompany company)
        {
            if (company.SelectedCompanyId == 0)
            {
                return RedirectToAction(MVC.Company.Create());
            }

            return RedirectToAction(MVC.Employee.Create(company.SelectedCompanyId));
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(ViewModels.Company.Create companyVm)
        {
            if (null != _companyRepository.GetAll().FirstOrDefault(c => c.Name == companyVm.Name))
            {
                ModelState.AddModelError("Name", WebMessage.CompanyMessage.NAME_ALREADY_USED);
            }

            if (!ModelState.IsValid)
            {
                return View(companyVm);
            }

            var company = Mapper.Map<Company>(companyVm);

            _companyRepository.Add(company);

            _notificationService.NewCompanyJoinedStagio(company, 
                WebMessage.NotificationMessage.ANewCompanyChoosedStagio(company.Name), 
                "", "");

            return RedirectToAction(MVC.Employee.Create(company.Id));
        }
    }
}
