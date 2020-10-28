using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Frontend.Validations
{
    public class AddIcuFieldValidations : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputData = value as string;
            if (string.IsNullOrEmpty(inputData))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            else
            {
                return new ValidationResult(true, "");
            }
        }
    }
}
