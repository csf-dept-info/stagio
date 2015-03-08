using AutoMapper;
using Stagio.Domain.Entities;

namespace Stagio.Web.Mappers
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EntityToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ApplicationUser, ViewModels.Account.Login>()
                .IgnoreAllNonExisting();

            //Student
            Mapper.CreateMap<Student, ViewModels.Student.Index>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.Student.Edit>()
                .ForMember(x => x.Password, y => y.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.Account.Login>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.Coordinator.ImportStudentViewModel>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.Student.CreateProfile>()
                .ForMember(x => x.Identifier, y => y.Ignore())
                .IgnoreAllNonExisting();

            //Employee
            Mapper.CreateMap<Employee, ViewModels.Employee.Create>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<Employee, ViewModels.Employee.Edit>()
                .ForMember(x => x.Password, y => y.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Employee, ViewModels.Account.Login>()
                .IgnoreAllNonExisting();

            //Company
            Mapper.CreateMap<Company, ViewModels.Company.Create>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Company, ViewModels.Company.Edit>()
                           .IgnoreAllNonExisting();

            Mapper.CreateMap<Company, ViewModels.Company.CompanyItem>()
                .IgnoreAllNonExisting();

            //Internship offers
            Mapper.CreateMap<InternshipOffer, ViewModels.InternshipOffer.Index>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<InternshipOffer, ViewModels.InternshipOffer.Create>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(src => src.ExtraFile, opt => opt.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<InternshipOffer, ViewModels.InternshipOffer.FullOffer>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<InternshipOfferDetails, ViewModels.InternshipOffer.OfferDetails>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<InternshipOfferDetails, ViewModels.InternshipOffer.DisplayOfferDetails>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<StaffMember, ViewModels.InternshipOffer.StaffMember>()
                .IgnoreAllNonExisting();

            //Coordinator
            Mapper.CreateMap<Coordinator, ViewModels.Coordinator.Index>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Coordinator, ViewModels.Account.Login>()
                .IgnoreAllNonExisting();

            //Internship applications
            Mapper.CreateMap<InternshipApplication, ViewModels.InternshipApplication.Create>()
                .ForMember(x => x.Resume, y => y.Ignore())
                .ForMember(x => x.CoverLetter, y => y.Ignore())
               .IgnoreAllNonExisting();

            Mapper.CreateMap<InternshipApplication, ViewModels.InternshipApplication.EmployeeIndex>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<InternshipApplication, ViewModels.InternshipApplication.StudentIndex>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.InternshipOfferTitle, opt => opt.MapFrom(src => src.GetOfferTitle()))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.GetCompanyName()))
                .ForMember(dest => dest.LastProgressionUpdateDate, opt => opt.MapFrom(src => src.GetLastUpdateDate()))
                .IgnoreAllNonExisting();

            //IntershipPeriod
            Mapper.CreateMap<InternshipPeriod, ViewModels.Coordinator.ChoosePeriod>()
                .IgnoreAllNonExisting();

            //Notifications
            Mapper.CreateMap<Notification, ViewModels.Notification.Notification>()
               .IgnoreAllNonExisting();

            //DepartmentalArchives
            Mapper.CreateMap<DepartmentalArchives, ViewModels.Archives.Details>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<DepartmentalArchives, ViewModels.Archives.Index>()
                .IgnoreAllNonExisting();
        }
    }
}