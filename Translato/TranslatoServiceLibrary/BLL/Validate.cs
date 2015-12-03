//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System.Text.RegularExpressions;

namespace TranslatoServiceLibrary.BLL
{
    internal class Validate
    {
        //isAllNumbers: true | false
        internal static bool isAllNumbers(string stringToCheck)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            return regex.IsMatch(stringToCheck);
        }

        //isAlphaNumeric: true | false
        internal static bool isAlphaNumeric(string stringToCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9]*$");
            return regex.IsMatch(stringToCheck);
        }

        //isAlphaNumericWithUnderscore: true | false
        internal static bool isAlphaNumericWithUnderscore(string stringToCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_]*$");
            return regex.IsMatch(stringToCheck);
        }

        //isAllLetters: true | false
        internal static bool isAllLetters(string stringToCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z]*$");
            return regex.IsMatch(stringToCheck);
        }

        //hasMinLength: true | false
        internal static bool hasMinLength(string stringToCheck, int minLength)
        {
            if(stringToCheck.Length >= minLength) { return true; }
            else { return false; }
        }

        //hasMaxLength: true | false
        internal static bool hasMaxLength(string stringToCheck, int maxLength)
        {
            if (stringToCheck.Length <= maxLength) { return true; }
            else { return false; }
        }

        //isBiggerThan: true | false
        internal static bool isBiggerThan(int numberToCheck, int minValue)
        {
            if (numberToCheck > minValue) { return true; }
            else { return false; }
        }

        //isSmallerThan: true | false
        internal static bool isSmallerThan(int numberToCheck, int maxValue)
        {
            if (numberToCheck < maxValue) { return true; }
            else { return false; }
        }
    }
}
