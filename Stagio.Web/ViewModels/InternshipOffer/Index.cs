using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.InternshipOffer
{
    public class Index
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Titre du stage")]
        public string Title { get; set; }

        [DisplayName("Description du projet pour le stage")]
        public string Description { get; set; }

        [DisplayName("Entreprise ou organisation")]
        public Domain.Entities.Company Company { get; set; }

        [DisplayName("Nombre de stagiaires")]
        public int NumberOfTrainees { get; set; }

        [DisplayName("Date de publication")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = WebMessage.DataFormat.DATE_FORMAT)]
        public DateTime PublicationDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Domain.Entities.InternshipOffer.OfferStatus Status { get; set; }

        public string ShortTitle
        {
            get
            {
                const int maxLength = 60;
                string shortTitle = Title;

                if (Title == null)
                {
                    shortTitle = "";
                } 
                else if (Title.Length >= maxLength)
                {
                    shortTitle = Title.Substring(0, maxLength) + "[...]";
                }

                return shortTitle;
            }
        }

        public string ShortDescription
        {
            get
            {
                const int maxLength = 60;
                string shortDescription = Description;

                if (Description == null)
                {
                    shortDescription = "";
                }
                else if (Description.Length >= maxLength)
                {
                    shortDescription = Description.Substring(0, maxLength) + "[...]";
                }

                return shortDescription;
            }
        }
    }
}