using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Frontend.Validations
{
    public class IcuIdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputData = value as string;
            var icu = new IcuApiCalls().GetAllIcus().ToList().Find(icu => icu.IcuId == inputData);
            if (icu != null)
                return new ValidationResult(false, "ICU with same ID exists");
            else
                return new ValidationResult(true, "");
        }
    }
}
