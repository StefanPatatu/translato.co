using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public class DbUser : IUser
    {
        private static SqlCommand dbCommand = null;
        private static SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 15);
        private static SqlParameter param_HashedPassword = new SqlParameter("@HashedPassword", SqlDbType.Char, 1024);
        private static SqlParameter param_PasswordSalt = new SqlParameter("@PasswordSalt", SqlDbType.Char, 512);
        private static SqlParameter param_FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_LastName = new SqlParameter("@LastName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_Email = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
        private static SqlParameter param_NewsletterOptOut = new SqlParameter("@NewsletterOptOut", SqlDbType.Bit);

        public int insertUser(User user)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO [dbo].[User] VALUES (" +
                "@UserName, " +
                "@HashedPassowrd, " +
                "@PasswordSalt, " +
                "@FirstName, " +
                "@LastName, " +
                "@Email, " +
                "@NewsletterOptOut" +
            ")";
            dbCommand = AccessTranslatoDb.GetDbCommand(sqlQuery);

            param_UserName.Value = user.UserName;
            dbCommand.Parameters.Add(param_UserName);

            param_HashedPassword.Value = user.HashedPassword;
            dbCommand.Parameters.Add(param_HashedPassword);

            param_PasswordSalt.Value = user.PasswordSalt;
            dbCommand.Parameters.Add(param_PasswordSalt);

            param_FirstName.Value = user.FirstName;
            dbCommand.Parameters.Add(param_FirstName);

            param_LastName.Value = user.LastName;
            dbCommand.Parameters.Add(param_LastName);

            param_Email.Value = user.Email;
            dbCommand.Parameters.Add(param_Email);

            param_NewsletterOptOut.Value = user.NewsletterOptOut;
            dbCommand.Parameters.Add(param_NewsletterOptOut);

            try
            {
                result = dbCommand.ExecuteNonQuery();
                Console.WriteLine("sdfsdfsdfsdfsdfsdf");
                Console.WriteLine(dbCommand.ToString());
                dbCommand.Parameters.Clear();
                AccessTranslatoDb.Close();
            }
            catch(SqlException)
            {

            }
            return result;
        }
    }
}
