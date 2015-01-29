using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Company
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nom")]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Adresse")]
        public string Address { get; set; }

        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(WebMessage.RegularExpression.PHONE_NUMBER_FORMAT, ErrorMessage = WebMessage.ErrorMessage.INVALID_PHONE_NUMBER_FORMAT)]
        [StringLength(14)]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = WebMessage.ErrorMessage.INVALID_EMAIL_FORMAT)]
        [DisplayName("Adresse courriel")]
        public string Email { get; set; }

        [DisplayName("Site web")]
        [Url(ErrorMessage = WebMessage.ErrorMessage.INVALID_URL_FORMAT)]
        public string WebSite { get; set; }
    }
}