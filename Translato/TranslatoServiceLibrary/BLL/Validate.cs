//author: futz
//helpers:
//last_checked: futz@04.12.2015
//talked about with Alex

using System.Text.RegularExpressions;

namespace TranslatoServiceLibrary.BLL
{
    internal static class Validate
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

        //isAlphaNumericWithUnderscoreAndSpaceAndDash: true | false
        internal static bool isAlphaNumericWithUnderscoreAndSpaceAndDash(string stringToCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_\- ]*$");
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

        //integerIsBiggerThan: true | false
        internal static bool integerIsBiggerThan(int numberToCheck, int minValue)
        {
            if (numberToCheck > minValue) { return true; }
            else { return false; }
        }

        //decimalIsBiggerThan: true | false
        internal static bool decimalIsBiggerThan(decimal numberToCheck, decimal minValue)
        {
            if (numberToCheck > minValue) { return true; }
            else { return false; }
        }

        //integerIsSmallerThan: true | false
        internal static bool integerIsSmallerThan(int numberToCheck, int maxValue)
        {
            if (numberToCheck < maxValue) { return true; }
            else { return false; }
        }

        //decimalIsSmallerThan: true | false
        internal static bool decimalIsSmallerThan(decimal numberToCheck, decimal maxValue)
        {
            if (numberToCheck < maxValue) { return true; }
            else { return false; }
        }
    }
}
