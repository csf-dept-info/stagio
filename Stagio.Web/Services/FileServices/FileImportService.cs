using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using AutoMapper;
using Microsoft.Owin.Security.Provider;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Custom_Annotations.AllUsers;
using Stagio.Web.ViewModels.Coordinator;

namespace Stagio.Web.Services
{
    public class FileImportService : IFileImportService
    {
        public string errorMessage { get; set; }

        public IEnumerable<ImportStudentViewModel> ImportStudentInformationsFromFile(HttpPostedFileBase file)
        {
            var importStudentsViewModel = new List<Stagio.Web.ViewModels.Coordinator.ImportStudentViewModel>();
            var stream = new StreamReader(file.InputStream);

            while (!stream.EndOfStream)
            {    
                importStudentsViewModel.Add(ProcessStudentString(stream.ReadLine()));
            }

            return ValidateImportStudentViewModelList(importStudentsViewModel);
        }

        public bool IsFileValid(string validExtension, HttpPostedFileBase file)
        {
            var validateFile = new ValidateFile() { ValidExtensions = new String[1] { validExtension } };
            if (validateFile.IsValid(file))
            {
                return true;
            }

            errorMessage = WebMessage.ErrorMessage.INVALID_FILE_FORMAT + validExtension;
            return false;
        }

        private ImportStudentViewModel ProcessStudentString(String readLine)
        {
            var student = CreateStudentFromInformations(readLine);
            if (!ValidateStudent(student))
            {
                return null;
            }
            
            var studentImport = new ImportStudentViewModel()
            {
                Identifier = student.Identifier,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Renew = false
            };
            return studentImport;
        }

        private bool ValidateStudentList(IEnumerable<ImportStudentViewModel> students)
        {
            foreach (var importStudentViewModel in students)
            {
                if (!ValidateStudent(importStudentViewModel))
                {
                    return false;
                }
            }
            return true;
        }

        private Student CreateStudentFromInformations(String studentInformations)
        {
            if (studentInformations == null)
            {
                return null;
            }

            var newStudent = new Student
            {
                LastName = GetLastName(studentInformations),
                FirstName = GetFirstName(studentInformations),
                Identifier = GetMatricule(studentInformations),
                Password = "",
                Roles = new List<UserRole>
                {
                    new UserRole {RoleName = RoleNames.Student},
                }
            };

            return newStudent;
        }

        private string GetMatricule(String student)
        {
            try
            {
                var positionOfFirstComma = student.IndexOf(",", System.StringComparison.Ordinal);
                return student.Substring(0, positionOfFirstComma);
            }
            catch (Exception)
            {

                return null;
            }

        }

        private string GetLastName(String student)
        {
            try
            {
                var positionOfFirstComma = student.IndexOf(",", System.StringComparison.Ordinal);
                var positionOfLastComma = student.LastIndexOf(",", System.StringComparison.Ordinal);
                return student.Substring(positionOfFirstComma + 2, positionOfLastComma - positionOfFirstComma - 2);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string GetFirstName(String student)
        {
            try
            {
                var positionOfLastComma = student.LastIndexOf(",", System.StringComparison.Ordinal);
                return student.Substring(positionOfLastComma + 2, student.Length - positionOfLastComma - 2);
            }
            catch (Exception)
            {
                return null;
            }

        }

        private bool ValidateStudent(ImportStudentViewModel student)
        {
            if (student == null)
            {
                return false;
            }

            if (student.LastName == null || student.FirstName == null)
            {
                return false;
            }

            if (student.Identifier == null || !IsNumeric(student.Identifier) || student.Identifier.Length != 7)
            {
                return false;
            }

            return true;
        }

        private bool ValidateStudent(Student student)
        {
            if (student.LastName == null || student.FirstName == null)
            {
                return false;
            }

            if (student.Identifier == null || !IsNumeric(student.Identifier) || student.Identifier.Length != 7)
            {
                return false;
            }

            return true;
        }

        private bool IsNumeric(string matricule)
        {
            int integerOut;
            return int.TryParse(matricule, out integerOut);
        }

        private IEnumerable<ImportStudentViewModel> ValidateImportStudentViewModelList(List<ImportStudentViewModel> importStudentViewModel)
        {
            if (importStudentViewModel.Count >= 1 && ValidateStudentList(importStudentViewModel))
            {
                return importStudentViewModel;
            }

            this.errorMessage = WebMessage.ErrorMessage.INVALID_FILE_DATA;

            return null;
        }
    }
}