using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.Domain.Entities;
using System.IO;

namespace Stagio.Web.Services
{
    public class FileSaveService : IFileSaveService
    {
        public string PathBeginning { get; set; }
        public string SaveOfferExtraFile(Employee employee, Stagio.Web.ViewModels.InternshipOffer.Create internshipOffer)
        {
            Initialize();
            var pathEnding = "\\Employees\\" + employee.FirstName + employee.LastName + employee.Id + "\\Offer" + internshipOffer.Title;
            var extraFilePath = this.PathBeginning + pathEnding;
            
            SaveFile(internshipOffer.ExtraFile, extraFilePath);
            
            return pathEnding;
        }
        public string SaveStudentFiles(Student student, Stagio.Web.ViewModels.InternshipApplication.Create internshipApplication)
        {
            Initialize();
            var pathEnding = "\\Students\\" + student.FirstName + student.LastName + student.Id + "\\Offer" + internshipApplication.InternshipOfferId;
            var extraFilePath = this.PathBeginning + pathEnding;

            SaveFile(internshipApplication.Resume, extraFilePath);
            SaveFile(internshipApplication.CoverLetter, extraFilePath);
            
            return pathEnding;
        }

        private void SaveFile(HttpPostedFileBase file, string path)
        {
            Directory.CreateDirectory(path);
            file.SaveAs(path + "\\" + file.FileName);
        }

        private void Initialize()
        {
            if (this.PathBeginning == null)
            {
                this.PathBeginning = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            }
        }
    }
}