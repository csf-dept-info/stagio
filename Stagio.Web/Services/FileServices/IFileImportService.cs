using System.Collections.Generic;
using System.Web;
using Stagio.Web.ViewModels.Coordinator;

namespace Stagio.Web.Services
{
    public interface IFileImportService
    {
        string errorMessage { get; set; }

        IEnumerable<ImportStudentViewModel> ImportStudentInformationsFromFile(HttpPostedFileBase file);

        bool IsFileValid(string validExtension, HttpPostedFileBase file);
    }
}