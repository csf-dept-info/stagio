using System.Globalization;
using System.Web;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Custom_Annotations.AllUsers;

namespace Stagio.Web.UnitTests.DataAnnotation
{
    [TestClass]
    public class MaxFileSizeTests
    {
        private MaxFileSizeAttribute _validate;
        private int _size;

        [TestInitialize]
        public void Initialize()
        {
            _size = 10 * 1024 * 1024;
            _validate = new MaxFileSizeAttribute(_size);
        }

        [TestMethod]
        public void validate_should_return_false_if_file_is_null()
        {
            _validate.IsValid(null).Should().BeFalse();
        }

        [TestMethod]
        public void validate_should_return_an_error_message_if_file_is_oversized()
        {
            _validate.FormatErrorMessage("error").ShouldBeEquivalentTo("Le champ " + (_size).ToString(CultureInfo.InvariantCulture) + " n'est pas valide.");
        }

        [TestMethod]
        public void validate_should_return_true_if_file_is_valid()
        {
            var file = Substitute.For<HttpPostedFileBase>();

            _validate.IsValid(file).Should().BeTrue();
        }

        [TestMethod]
        public void validate_should_return_false_if_file_is_oversized()
        {
            var file = Substitute.For<HttpPostedFileBase>();
            file.ContentLength.Returns(_size*2);
            _validate.IsValid(file).Should().BeFalse();
        }


    }
}