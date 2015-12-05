//author: futz
//helpers:
//last_checked: futz@05.12.2015

using System;
using System.Collections.Generic;

namespace TranslatoServiceLibrary.BLL
{
    internal static class Security
    {
        //defining public and private keys
        //hardcoded because it is expected to only have a handful of clients and no need for adding more on the fly
        //string: 128-Bit Hex (32 ch.), string: 256-Bit Hex (64 ch.)
        private static Dictionary<string, string> keyMap = new Dictionary<string, string>()
        {
            //TranslatoWebsite
            {"30e5c23d933976afdd20df2eeb77abe5", "7241e81e73069476bc336efb027392117b425c397ff8e8e12947a6f6d6f8e1f6"},
            //Test Client
            {"131e1bca292ba7a85234799f062a1378", "a8ccbe625269d03698ed21ae332a2297427bb8dfb0dea1bbdb8646d7be784be9"}
        };

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

        //returns "true" if client is authorized
        //returns "false" if not
        internal static bool authorizeClient(string publicKey, string privateKey)
        {
            bool isAuthorized = false;
            string privateKeyOnFile;
            if (keyMap.ContainsKey(publicKey))
            {//means the publicKey is valid
                keyMap.TryGetValue(publicKey, out privateKeyOnFile);//get the privateKey associated with the publicKey
                if (String.Equals(privateKey, privateKeyOnFile)) { isAuthorized = true; }//means the privateKey matches the one on file
                else { isAuthorized = false; }//means it does not
            }
            else
            {//means the publicKey is not valid
                isAuthorized = false;
            }
            return isAuthorized;
        }
    }
}
