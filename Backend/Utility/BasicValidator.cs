using System;
using System.Text.RegularExpressions;

namespace Backend.Utility
{
    public class BasicValidator
    {
        public readonly static Func<string, bool> basicValid = field =>
        {
            bool isFieldnullOrEmpty = string.IsNullOrEmpty(field);
            bool isFieldHaveWhitespace = string.IsNullOrWhiteSpace(field);
            if (!isFieldHaveWhitespace && !isFieldnullOrEmpty)
            {
                return true;
            }
            return false;
        };

        /*public static Func<string, bool> ValidInt = IntField =>
        {

            return Regex.IsMatch(IntField, @"^\d{2,3}$");
        };

        public static Func<string, bool> ValidFloat = FloatField =>
        {

            return Regex.IsMatch(FloatField, @"^\d{2,3} [.]{0,1}\d{2}$");
        };*/
    }
}
