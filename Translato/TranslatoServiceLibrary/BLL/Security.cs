//author: futz
//helpers:
//last_checked: futz@03.12.2015

using System;

namespace TranslatoServiceLibrary.BLL
{
    internal class Security
    {
        //returns "true" if password matches
        //returns "false" if not
        internal static bool checkPassword(string hashedPassword, string HRpassword)
        {
            bool isTheSamePassword = false;
            try
            {
                isTheSamePassword = Password.verifyHashedPassword(hashedPassword, HRpassword);
            }
            catch (Exception ex)
            {
                isTheSamePassword = false;
                DEBUG.Log.Add(ex.ToString());
            }
            return isTheSamePassword;
        }
    }
}
