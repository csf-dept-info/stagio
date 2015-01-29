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
        [DisplayName("Titre du stage *")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Entreprise ou organisation")]
        public Stagio.Domain.Entities.Company Company { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_CONTACT)]
        [DisplayName("Responsable du stage *")]
        public ViewModels.InternshipOffer.StaffMember Contact { get; set; }

        [DisplayName("Autre contact pour le stage")]
        public ViewModels.InternshipOffer.StaffMember OtherContact { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_DESCRIPTION)]
        [DisplayName("Description du projet pour le stage *")]
        public string Description { get; set; }

        [DisplayName("Fichier supplémentaire")]
        [ValidateFile(ValidExtensions = new String[3] {".pdf", ".doc", ".docx"})]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = WebMessage.ErrorMessage.INVALID_FILE_SIZE)]
        public HttpPostedFileBase ExtraFile { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_DETAILS)]
        [DisplayName("Détails spécifiques au stage *")]
        public ViewModels.InternshipOffer.OfferDetails Details { get; set; }

        [Required]
        [Range(1, 99)]
        [DisplayName("Nombre de stagiaires *")]
        public int NumberOfTrainees { get; set; }

        [Required(ErrorMessage = WebMessage.InternshipOfferMessage.REQUIRED_PERSON_IN_CHARGE)]
        [DisplayName("Soumettre les candidatures à *")]
        public ViewModels.InternshipOffer.StaffMember PersonInCharge { get; set; }

        [Required(ErrorMessage = WebMessage.ErrorMessage.INVALID_DATE_FORMAT)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        [DisplayName("Date limite pour soumettre les candidatures *")]
        public DateTime Deadline { get; set; }

        [HiddenInput]
        public int CompanyId { get; set; }

        [HiddenInput]
        public int EmployeeId { get; set; }
    }
}