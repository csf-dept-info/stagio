using System.Web;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Custom_Annotations.AllUsers;

namespace Stagio.Web.UnitTests.DataAnnotation
{
    [TestClass]
    public class ValidateFilesTests
    {
        private ValidateFile _validate;


        [TestInitialize]
        public void Initialize()
        {
            _validate = new ValidateFile();
        }

        [TestMethod]
        public void validate_should_return_false_if_extension_is_empty()
        {
            const string EXTENSION_TO_VALIDATE = "";
            _validate.ValidExtensions = new[] { ".pdf" };
            _validate.IsValid(EXTENSION_TO_VALIDATE).Should().BeFalse();
        }

        [TestMethod]
        public void validate_should_return_false_if_extension_is_null()
        {
            const string EXTENSION_TO_VALIDATE = null;
            _validate.ValidExtensions = new[] { ".pdf" };
            _validate.IsValid(EXTENSION_TO_VALIDATE).Should().BeFalse();
        }

        [TestMethod]
        public void validate_should_return_true_if_extension_is_valid()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            file.FileName.Returns("test.pdf");

            _validate.ValidExtensions = new[] { ".pdf", ".csv" };
            _validate.IsValid(file).Should().BeTrue();
        }
    }
}