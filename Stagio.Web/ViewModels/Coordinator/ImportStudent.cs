using System.ComponentModel.DataAnnotations;
using System.Web;
using Stagio.Web.Custom_Annotations.AllUsers;


namespace Stagio.Web.ViewModels.Coordinator
{
    public class ImportStudent
    {
        [Required]
        [ValidateFile(ValidExtensions = new[] {".csv"})]
        public HttpPostedFileBase File { get; set; }
    }
}