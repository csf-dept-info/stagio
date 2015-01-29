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

        [DisplayName("Titre du stage")]
        public string Title { get; set; }

        [DisplayName("Entreprise ou organisation")]
        public Domain.Entities.Company Company { get; set; }

        [DisplayName("Responsable du stage")]
        public StaffMember Contact { get; set; }

        [DisplayName("Autre contact pour le stage")]
        public StaffMember OtherContact { get; set; }

        [DisplayName("Description du projet pour le stage")]
        public string Description { get; set; }

        [DisplayName("Détails spécifiques au stage")]
        public DisplayOfferDetails Details { get; set; }

        [DisplayName("Nombre de stagiaires")]
        public int NumberOfTrainees { get; set; }

        [DisplayName("Soumettre les candidatures à")]
        public StaffMember PersonInCharge { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        [DisplayName("Date limite pour soumettre les candidatures")]
        public DateTime Deadline { get; set; }

        [DisplayName("Message de refus")]
        public string DenyMessage { get; set; }
        
        [DisplayName("Fichier supplémentaire")]
        public string PathToExtraFile { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Stagio.Domain.Entities.InternshipOffer.OfferStatus Status { get; set; }

        [HiddenInput]
        public int CompanyId { get; set; }

        [HiddenInput]
        public int EmployeeId { get; set; }
    }
}