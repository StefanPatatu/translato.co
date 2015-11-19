using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

//author: futz
//helpers:

namespace WcfServiceLibrary.DAL
{
    public class DbUsers : IUsers
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_UserId = new SqlParameter("@UserId", SqlDbType.Int);
        private static SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 15);
        private static SqlParameter param_HashedPassword = new SqlParameter("@HashedPassword", SqlDbType.Char, 1024);
        private static SqlParameter param_FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_LastName = new SqlParameter("@LastName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_Email = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
        private static SqlParameter param_NewsletterOptOut = new SqlParameter("@NewsletterOptOut", SqlDbType.Bit);
        private static SqlParameter param_CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTimeOffset);

        private static User createUser(IDataReader dbReader)
        {
            User user = new User();
            user.UserId = Convert.ToInt32(dbReader["UserId"]);
            user.UserName = Convert.ToString(dbReader["UserName"]);
            user.HashedPassword = Convert.ToString(dbReader["HashedPassword"]);
            user.FirstName = Convert.ToString(dbReader["Firstname"]);
            user.LastName = Convert.ToString(dbReader["LastName"]);
            user.Email = Convert.ToString(dbReader["Email"]);
            user.NewsletterOptOut = Convert.ToBoolean(dbReader["NewsletterOptOut"]);
            user.CreatedOn = Convert.ToDateTime(dbReader["CreatedOn"]);
            return user;
        }

        public int insertUser(User user)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Users VALUES (" +
                "@UserName, " +
                "@HashedPassword, " +
                "@FirstName, " +
                "@LastName, " +
                "@Email, " +
                "@NewsletterOptOut," +
                "@CreatedOn" +
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

                    param_FirstName.Value = user.FirstName;
                    sqlCommand.Parameters.Add(param_FirstName);

                    param_LastName.Value = user.LastName;
                    sqlCommand.Parameters.Add(param_LastName);

                    param_Email.Value = user.Email;
                    sqlCommand.Parameters.Add(param_Email);

                    param_NewsletterOptOut.Value = user.NewsletterOptOut;
                    sqlCommand.Parameters.Add(param_NewsletterOptOut);

                    param_CreatedOn.Value = user.CreatedOn;
                    sqlCommand.Parameters.Add(param_CreatedOn);

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return result;
            }
        }
    }
}
