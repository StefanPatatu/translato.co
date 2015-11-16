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
    public class DbUsers : IUsers
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_UserId = new SqlParameter("@UserId", SqlDbType.Int);
        private static SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 15);
        private static SqlParameter param_HashedPassword = new SqlParameter("@HashedPassword", SqlDbType.Char, 1024);
        private static SqlParameter param_PasswordSalt = new SqlParameter("@PasswordSalt", SqlDbType.Char, 512);
        private static SqlParameter param_FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_LastName = new SqlParameter("@LastName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_Email = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
        private static SqlParameter param_NewsletterOptOut = new SqlParameter("@NewsletterOptOut", SqlDbType.Bit);

        private static User createUser(IDataReader dbReader)
        {
            User user = new User();
            user.UserId = Convert.ToInt32(dbReader["UserId"]);
            user.UserName = Convert.ToString(dbReader["UserName"]);
            user.HashedPassword = Convert.ToString(dbReader["HashedPassword"]);
            user.PasswordSalt = Convert.ToString(dbReader["PasswordSalt"]);
            user.FirstName = Convert.ToString(dbReader["Firstname"]);
            user.LastName = Convert.ToString(dbReader["LastName"]);
            user.Email = Convert.ToString(dbReader["Email"]);
            user.NewsletterOptOut = Convert.ToBoolean(dbReader["NewsletterOptOut"]);
            return user;
        }

        public int insertUser(User user)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Users VALUES (" +
                "@UserName, " +
                "@HashedPassword, " +
                "@PasswordSalt, " +
                "@FirstName, " +
                "@LastName, " +
                "@Email, " +
                "@NewsletterOptOut" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    param_UserName.Value = user.UserName;
                    sqlCommand.Parameters.Add(param_UserName);

                    param_HashedPassword.Value = user.HashedPassword;
                    sqlCommand.Parameters.Add(param_HashedPassword);

                    param_PasswordSalt.Value = user.PasswordSalt;
                    sqlCommand.Parameters.Add(param_PasswordSalt);

                    param_FirstName.Value = user.FirstName;
                    sqlCommand.Parameters.Add(param_FirstName);

                    param_LastName.Value = user.LastName;
                    sqlCommand.Parameters.Add(param_LastName);

                    param_Email.Value = user.Email;
                    sqlCommand.Parameters.Add(param_Email);

                    param_NewsletterOptOut.Value = user.NewsletterOptOut;
                    sqlCommand.Parameters.Add(param_NewsletterOptOut);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                }
                catch (InvalidOperationException ioEx)
                {
                    Console.WriteLine(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.ToString());
                }
                return result;
            }
        }
    }
}
