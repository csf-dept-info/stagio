using System.Collections.Generic;
using System.IO;
using System.Web;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Coordinator;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class FileImportServiceTests
    {
        public IFileImportService _fileImportService;

        [TestInitialize]
        public void Initialize()
        {
            _fileImportService = new FileImportService();
        }

        [TestMethod]
        public void is_file_valid_should_return_true_if_file_extension_is_the_same()
        {
            const string extension = ".csv";
            var file = Substitute.For<HttpPostedFileBase>();
            file.FileName.Returns("test.csv");

            _fileImportService.IsFileValid(extension, file).Should().BeTrue();
        }

        [TestMethod]
        public void is_file_valid_should_return_false_if_file_extension_is_the_different()
        {
            const string extension = ".csv";
            var file = Substitute.For<HttpPostedFileBase>();
            file.FileName.Returns("test.pdf");

            _fileImportService.IsFileValid(extension, file).Should().BeFalse();
        }


        [TestMethod]
        public void is_file_valid_should_return_false_if_file_is_empty()
        {
            const string extension = ".csv";
            var file = Substitute.For<HttpPostedFileBase>();

            _fileImportService.IsFileValid(extension, file).Should().BeFalse();
        }

        [Ignore]
        [TestMethod]
        public void compute_student_should_return_null_if_file_contain_wrong_data()
        {
            var file = Substitute.For<HttpPostedFileBase>();

            var inputStream = File.Open("../../Services/TestFile/TestFileReturnNullBecauseWrongData.csv", FileMode.Open);
            file.InputStream.Returns(inputStream);

            _fileImportService.ImportStudentInformationsFromFile(file).Should().BeNull();
        }

        [Ignore]
        [TestMethod]
        public void compute_student_should_return_null_if_file_contain_wrong_data2()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            var inputStream = File.Open("../../Services/TestFile/TestFileReturnNullBecauseWrongData2.csv", FileMode.Open);
            file.InputStream.Returns(inputStream);

            _fileImportService.ImportStudentInformationsFromFile(file).Should().BeNull();
        }

        [Ignore]
        [TestMethod]
        public void compute_student_should_return_null_if_file_is_empty()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            var inputStream = File.Open("../../Services/TestFile/TestFileReturnNullBecauseEmpty.csv", FileMode.Open);
            file.InputStream.Returns(inputStream);

            _fileImportService.ImportStudentInformationsFromFile(file).Should().BeNull();
        }

        [Ignore]
        [TestMethod]
        public void compute_student_should_return_student_list_if_file_is_correct()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            var inputStream = File.Open("../../Services/TestFile/TestFile1.csv", FileMode.Open);
            file.InputStream.Returns(inputStream);

            var listOfStudentExpected = new List<ImportStudentViewModel>
            {
                new ImportStudentViewModel
                {
                    Identifier = "1115381",
                    FirstName = "Martin",
                    LastName = "Barbeau"
                },
                new ImportStudentViewModel
                {
                    Identifier = "1117181",
                    FirstName = "Elise",
                    LastName = "Carbonneau-Leclerc"
                },
                new ImportStudentViewModel
                {
                    Identifier = "1110981",
                    FirstName = "Laurie",
                    LastName = "Lavoie"
                }
            };

            _fileImportService.ImportStudentInformationsFromFile(file).ShouldBeEquivalentTo(listOfStudentExpected);
        }
    }
}
