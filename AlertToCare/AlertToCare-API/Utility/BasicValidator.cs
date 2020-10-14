using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlertToCare_API.Utility
{
    //check whether field is empty or have whitespace
    public class BasicValidator
    {
       public static Func<string, bool> basicValid = field =>
         {
             bool IsFieldnullOrEmpty = string.IsNullOrEmpty(field);
             bool IsFieldHaveWhitespace = string.IsNullOrWhiteSpace(field);
             if(!IsFieldHaveWhitespace && !IsFieldnullOrEmpty)
             {
                 return true;
             }
             return false;
         };

        public static Func<string, bool> ValidInt = IntField =>
         {
             
             return Regex.IsMatch(IntField, @"^\d{2}$");
         };

        public static Func<string, bool> ValidFloat = FloatField =>
        {

            return Regex.IsMatch(FloatField, @"^\d{2} [.]{0,1}\d{2}$");
        };
    }

    
}
