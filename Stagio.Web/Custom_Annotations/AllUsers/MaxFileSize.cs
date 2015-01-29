using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web;

namespace Stagio.Web.Custom_Annotations.AllUsers
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }
            return file.ContentLength <= _maxFileSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString(CultureInfo.InvariantCulture));
        }
    }
}