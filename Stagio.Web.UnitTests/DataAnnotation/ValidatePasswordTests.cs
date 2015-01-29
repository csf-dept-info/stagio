using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Custom_Annotations.AllUsers;

namespace Stagio.Web.UnitTests.DataAnnotation
{
    [TestClass]
    public class ValidatePasswordTests
    {
        private ValidatePassword _validate;


        [TestInitialize]
        public void Initialize()
        {
            _validate = new ValidatePassword();
        }

        [TestMethod]
        public void validate_should_return_false_if_string_is_empty()
        {
            const string PASSWORD_TO_VALIDATE = "";
            _validate.IsValid(PASSWORD_TO_VALIDATE).Should().BeFalse();
        }

        [TestMethod]
        public void validate_should_return_true_if_string_is_null()
        {
            const string PASSWORD_TO_VALIDATE = null;
            _validate.IsValid(PASSWORD_TO_VALIDATE).Should().BeTrue();
        }

        [TestMethod]
        public void validate_should_return_false_if_string_contain_less_then_2_numeric_values()
        {
            const string PASSWORD_TO_VALIDATE = "aaaaaaaaa";
            _validate.IsValid(PASSWORD_TO_VALIDATE).Should().BeFalse();
        }

        [TestMethod]
        public void validate_should_return_false_if_string_contain_less_then_2_letters()
        {
            const string PASSWORD_TO_VALIDATE = "123456789";
            _validate.IsValid(PASSWORD_TO_VALIDATE).Should().BeFalse();
        }

        [TestMethod]
        public void validate_should_return_true_if_password_is_valid()
        {
            const string PASSWORD_TO_VALIDATE = "123456789AA";
            _validate.IsValid(PASSWORD_TO_VALIDATE).Should().BeTrue();
        }

    }
}