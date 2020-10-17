using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlertToCareAPI.Utility
{
    public class BasicValidator
    {
        public static Func<string, bool> basicValid = field =>
        {
            bool IsFieldnullOrEmpty = string.IsNullOrEmpty(field);
            bool IsFieldHaveWhitespace = string.IsNullOrWhiteSpace(field);
            if (!IsFieldHaveWhitespace && !IsFieldnullOrEmpty)
            {
                return true;
            }
            return false;
        };

        public static Func<string, bool> ValidInt = IntField =>
        {

            return Regex.IsMatch(IntField, @"^\d{2,3}$");
        };

        public static Func<string, bool> ValidFloat = FloatField =>
        {

            return Regex.IsMatch(FloatField, @"^\d{2,3} [.]{0,1}\d{2}$");
        };
    }
}
