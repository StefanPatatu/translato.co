//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System.Text.RegularExpressions;

namespace WcfServiceLibrary.BLL
{
    internal class Validate
    {

        //isAlphaNumeric: true | false
        internal static bool isAlphaNumeric(string stringToCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_]*$");
            return regex.IsMatch(stringToCheck);
        }

        //hasMinLength: true | false
        internal static bool hasMinLength(string stringToCheck, int minLength)
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

        //hasMaxLength: true | false
        internal static bool hasMaxLength(string stringToCheck, int maxLength)
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
