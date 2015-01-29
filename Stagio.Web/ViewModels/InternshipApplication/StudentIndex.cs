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

        [DisplayName("Titre de l'offre")]
        public string InternshipOfferTitle { get; set; }

        [DisplayName("Compagnie")]
        public string CompanyName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Stagio.Domain.Entities.InternshipApplication.ApplicationStatus Progression { get; set; }

        [DisplayName("Progression")]
        public int ProgressionPercentage { get; set; }

        public string ProgressionDescription { get; set; }

        public string ProgessionUpdateHtmlContent { get; set; }

        public string ProgessionUpdateHtmlTitle { get; set; }

        [DisplayName("Dernière mise à jour")]
        public string LastProgressionUpdateDateText { get; set; }

        [Required(ErrorMessage = WebMessage.ErrorMessage.INVALID_DATE_FORMAT)]
        [DataType(DataType.DateTime, ErrorMessage = WebMessage.ErrorMessage.INVALID_DATE_FORMAT)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        [DisplayName("Dernière mise à jour")]
        public DateTime LastProgressionUpdateDate { get; set; }
    }
}