using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class FullOffer
    {
        [HiddenInput]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        [DisplayName("Date de l'offre")]
        public DateTime PublicationDate { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.INTERNSHIP_TITLE)]
        public string Title { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.COMPANY)]
        public Domain.Entities.Company Company { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.CONTACT)]
        public StaffMember Contact { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.OTHER_CONTACT)]
        public StaffMember OtherContact { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.DESCRIPTION)]
        public string Description { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.DETAILS)]
        public DisplayOfferDetails Details { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.NUMBER_OF_TRAINEES)]
        public int NumberOfTrainees { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.PERSON_IN_CHARGE)]
        public StaffMember PersonInCharge { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.DEADLINE)]
        public DateTime Deadline { get; set; }

        [DisplayName(WebMessage.InternshipOfferMessage.OfferDetails.DENY_MESSAGE)]
        public string DenyMessage { get; set; }
        
        [DisplayName(WebMessage.InternshipOfferMessage.OfferCreation.EXTRA_FILE)]
        public string PathToExtraFile { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Stagio.Domain.Entities.InternshipOffer.OfferStatus Status { get; set; }

        [HiddenInput]
        public int CompanyId { get; set; }

        [HiddenInput]
        public int EmployeeId { get; set; }
    }
}