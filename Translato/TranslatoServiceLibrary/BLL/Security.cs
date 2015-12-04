//author: futz
//helpers:
//last_checked: futz@04.12.2015

using System;

namespace TranslatoServiceLibrary.BLL
{
    internal static class Security
    {
        //returns "hashedPassword" on success
        //returns "null" on failure
        internal static string hashPassword(string HRpassword)
        {
            string hashedPassword = null;
            try
            {
                hashedPassword = Password.hashPassword(HRpassword);
            }
            catch (Exception ex)
            {
                hashedPassword = null;
                DEBUG.Log.Add(ex.ToString());
            }
            return hashedPassword;
        }

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
