using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.InternshipApplication
{
    public class StudentIndex
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int InternshipOfferId { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OFFER_TITLE)]
        public string InternshipOfferTitle { get; set; }

        [DisplayName(WebMessage.HomeMessage.COMPANY)]
        public string CompanyName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Stagio.Domain.Entities.InternshipApplication.ApplicationStatus Progression { get; set; }

        [DisplayName(WebMessage.InternshipApplicationMessage.StudentHasApplied.PROGRESSION)]
        public int ProgressionPercentage { get; set; }

        public string ProgressionDescription { get; set; }

        public string ProgessionUpdateHtmlContent { get; set; }

        public string ProgessionUpdateHtmlTitle { get; set; }

        [DisplayName(WebMessage.InternshipApplicationMessage.StudentHasApplied.LAST_UPDATE)]
        public string LastProgressionUpdateDateText { get; set; }

        [Required(ErrorMessage = WebMessage.ErrorMessage.INVALID_DATE_FORMAT)]
        [DataType(DataType.DateTime, ErrorMessage = WebMessage.ErrorMessage.INVALID_DATE_FORMAT)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        [DisplayName(WebMessage.InternshipApplicationMessage.StudentHasApplied.LAST_UPDATE)]
        public DateTime LastProgressionUpdateDate { get; set; }
    }
}