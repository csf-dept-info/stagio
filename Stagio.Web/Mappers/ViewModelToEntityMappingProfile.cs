using AutoMapper;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Coordinator;

namespace Stagio.Web.Mappers
{
    class ViewModelToEntityMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToEntityMappings"; }
        }

        protected override void Configure()
        {
            //Student
            Mapper.CreateMap<ViewModels.Student.Edit, Student>()
                .ForMember(x => x.Password, y => y.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Student.Index, Student>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Student.CreateProfile, Student>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ImportStudentViewModel, Student>()
                .ForMember(x => x.StudentId, y => y.MapFrom(src => src.Identifier))
                .ForMember(x => x.Identifier, y => y.MapFrom(src => src.Identifier))
                .IgnoreAllNonExisting();

            //Employee
            Mapper.CreateMap<ViewModels.Employee.Create, Employee>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Employee.Edit, Employee>()
                .ForMember(x => x.Password, y => y.Ignore())
            .IgnoreAllNonExisting();

            //Company
            Mapper.CreateMap<ViewModels.Company.Create, Company>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Company.Edit, Company>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Company.CompanyItem, Company>()
               .IgnoreAllNonExisting();

            //Internship offers
            Mapper.CreateMap<ViewModels.InternshipOffer.Index, InternshipOffer>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.InternshipOffer.Create, InternshipOffer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Company, y => y.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.InternshipOffer.FullOffer, InternshipOffer>()
                .ForMember(x => x.Company, y => y.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.InternshipOffer.OfferDetails, InternshipOfferDetails>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.InternshipOffer.DisplayOfferDetails, InternshipOfferDetails>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.InternshipOffer.StaffMember, StaffMember>()
                .IgnoreAllNonExisting();

            //Internship applications
            Mapper.CreateMap<ViewModels.InternshipApplication.Create, InternshipApplication>()
                .ForMember(x => x.ApplyingStudent, y => y.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.InternshipApplication.EmployeeIndex, InternshipApplication>()
                .IgnoreAllNonExisting();

            //Coordinator
            Mapper.CreateMap<Index, Coordinator>()
                .IgnoreAllNonExisting();


            //Login
            Mapper.CreateMap<ViewModels.Account.Login, Employee>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Account.Login, Coordinator>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Account.Login, Student>()
                .IgnoreAllNonExisting();

            //Notifications
            Mapper.CreateMap<ViewModels.Notification.Notification, Notification>()
                .IgnoreAllNonExisting();

            //IntershipPeriod
            Mapper.CreateMap<ViewModels.Coordinator.ChoosePeriod, InternshipPeriod>()
                .IgnoreAllNonExisting();

            //DepartmentalArchives
            Mapper.CreateMap<ViewModels.Archives.Details, DepartmentalArchives>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ViewModels.Archives.Index, DepartmentalArchives>()
                .IgnoreAllNonExisting();
        }
    }
}