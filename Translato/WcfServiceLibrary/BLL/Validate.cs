using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WcfServiceLibrary.BLL
{
    class Validate
    {
        public static bool isAlphaNumeric(string stringToCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_]*$");
            return regex.IsMatch(stringToCheck);
        }
        public static bool hasMinLength(string stringToCheck, int minLength)
        {
            if(stringToCheck.Length >= minLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool hasMaxLength(string stringToCheck, int maxLength)
        {
            if (stringToCheck.Length <= maxLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
