using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Stagio.Web.Custom_Annotations.AllUsers;

namespace Stagio.Web.ViewModels.InternshipApplication
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Curriculum vitæ")]
        [ValidateFile(ValidExtensions = new[] {".pdf"})]
        public HttpPostedFileBase Resume { get; set; }
        
        [Required]
        [DisplayName("Lettre de présentation")]
        [ValidateFile(ValidExtensions = new[] { ".pdf" })]
        public HttpPostedFileBase CoverLetter { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int InternshipOfferId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Domain.Entities.InternshipOffer InternshipOffer { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }
    }
}