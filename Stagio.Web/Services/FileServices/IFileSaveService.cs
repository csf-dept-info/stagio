using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IFileSaveService
    {
        string PathBeginning { get; set; }
        string SaveStudentFiles(Student student, Stagio.Web.ViewModels.InternshipApplication.Create internshipApplication);
        string SaveOfferExtraFile(Employee employee, Stagio.Web.ViewModels.InternshipOffer.Create internshipOffer);
    }
}