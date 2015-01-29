using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.Custom_Annotations.AllUsers
{
    public class ValidateFile : ValidationAttribute
    {
        public String[] ValidExtensions { get; set; }

        public override bool IsValid(object value)
        {
            ErrorMessage = WebMessage.ErrorMessage.INVALID_FILE_FORMAT + ValidExtensions[0];

            for (int i = 1; i < ValidExtensions.Length; i++)
            {
                ErrorMessage += ", " + ValidExtensions[i];
            }

            var file = value as HttpPostedFileBase;

            if (file == null || file.ContentLength < 0)
            {
                ErrorMessage = WebMessage.ErrorMessage.INVALID_FILE_DATA;
                return false;
            }

            var extension = System.IO.Path.GetExtension(file.FileName);

            return ValidExtensions.Contains(extension);
        }
    }
}