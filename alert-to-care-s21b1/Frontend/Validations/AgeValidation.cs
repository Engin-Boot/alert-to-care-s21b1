using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Frontend.Validations
{
    public class AgeValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int input;
            bool parsed = Int32.TryParse((string)value, out input);

            if (!parsed)
            {
                return new ValidationResult(false, "Input has to be a number");
            }
            else if (input <= 0)
            {
                return new ValidationResult(false, "Input has to be greater than 0");
            }

            else
            {
                return new ValidationResult(true, "");
            }
        }
    }
}
