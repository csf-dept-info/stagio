using System;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.Custom_Annotations.AllUsers
{
    public class ValidatePassword : ValidationAttribute
    {
        public int Digit { get; set; }

        public int Character { get; set; }

        public ValidatePassword()
        {
            Digit = 2;
            Character = 2;
        }

        public override bool IsValid(object value)
        {
            var strValue = value as string;
            var digitFound = 0;
            var characterFound = 0;
            if (strValue == null)
            {
                return true;
            }
            foreach (var c in strValue)
            {
                if (Char.IsDigit(c))
                {
                    digitFound++;
                }
                else if (Char.IsLetter(c))
                {
                    characterFound++;
                }
                if (digitFound > 1 && characterFound > 1)
                {
                    return true;
                }
            }
                return false;
        }
    }
}