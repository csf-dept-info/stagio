using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.Web.Custom_Annotations.AllUsers;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class Create
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_TITLE)]
        [DisplayName(WebMessage.InternshipOfferMessage.REQUIRED_INTERNSHIP_TITLE)]
        public string Title { get; set; }

        [Required]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.COMPANY)]
        public Stagio.Domain.Entities.Company Company { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_CONTACT)]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.REQUIRED_CONTACT)]
        public ViewModels.InternshipOffer.StaffMember Contact { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.OTHER_CONTACT)]
        public ViewModels.InternshipOffer.StaffMember OtherContact { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_DESCRIPTION)]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.REQUIRED_DESCRIPTION)]
        public string Description { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.EXTRA_FILE)]
        [ValidateFile(ValidExtensions = new String[3] {".pdf", ".doc", ".docx"})]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = WebMessage.ErrorMessage.INVALID_FILE_SIZE)]
        public HttpPostedFileBase ExtraFile { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_DETAILS)]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.REQUIRED_DETAILS)]
        public ViewModels.InternshipOffer.OfferDetails Details { get; set; }

        [Required]
        [Range(1, 99)]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.REQUIRED_NUMBER_OF_TRAINEES)]
        public int NumberOfTrainees { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_PERSON_IN_CHARGE)]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.REQUIRED_PERSON_IN_CHARGE)]
        public ViewModels.InternshipOffer.StaffMember PersonInCharge { get; set; }

        [Required(ErrorMessage = WebMessage.ErrorMessage.INVALID_DATE_FORMAT)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.REQUIRED_DEADLINE)]
        public DateTime Deadline { get; set; }

        [HiddenInput]
        public int CompanyId { get; set; }

        [HiddenInput]
        public int EmployeeId { get; set; }
    }
}