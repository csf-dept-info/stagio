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
        
        [DisplayName(WebMessage.HomeMessage.STUDENT)]
        public string StudentName { get; set; }
        
        [DisplayName(WebMessage.GeneralMessage.RESUME)]
        public string PathToResume { get; set; }

        [DisplayName(WebMessage.GeneralMessage.COVER_LETTER)]
        public string PathToCoverLetter { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int InternshipOfferId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Stagio.Domain.Entities.InternshipOffer InternshipOffer { get; set; }

        public string InternshipTitle { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime OfferPublicationDate { get; set; }

        [DisplayName(WebMessage.InternshipApplicationMessage.APPLICATION_DATE)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime ApplicationDate { get; set; }

        [DisplayName(WebMessage.GeneralMessage.EMAIL)]
        public string Email { get; set; }

        [DisplayName(WebMessage.UserInformation.PHONE_NUMBER)]
        public string PhoneNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }
    }
}