using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Stagio.Web.Custom_Annotations.AllUsers;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.InternshipApplication
{
    public class EmployeeIndex
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        [DisplayName("Étudiant")]
        public string StudentName { get; set; }
        
        [DisplayName("Curriculum vitæ")]
        public string PathToResume { get; set; }

        [DisplayName("Lettre de présentation")]
        public string PathToCoverLetter { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int InternshipOfferId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Stagio.Domain.Entities.InternshipOffer InternshipOffer { get; set; }

        public string InternshipTitle { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime OfferPublicationDate { get; set; }

        [DisplayName("Date de postulation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime ApplicationDate { get; set; }

        [DisplayName("Adresse email")]
        public string Email { get; set; }

        [DisplayName("Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }
    }
}