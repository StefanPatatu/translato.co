﻿//author: futz
//helpers:
//last_cheked: futz@20.11.2015

using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    public class DbUsers : IUsers
    {
        //define sql parameters
        private static SqlParameter param_userId = new SqlParameter("@UserId", SqlDbType.Int);
        private static SqlParameter param_userName = new SqlParameter("@UserName", SqlDbType.VarChar, 15);
        private static SqlParameter param_hashedPassword = new SqlParameter("@HashedPassword", SqlDbType.Char, 100);
        private static SqlParameter param_firstName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_lastName = new SqlParameter("@LastName", SqlDbType.NVarChar, 20);
        private static SqlParameter param_email = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
        private static SqlParameter param_newsletterOptOut = new SqlParameter("@NewsletterOptOut", SqlDbType.Bit);
        private static SqlParameter param_createdOn = new SqlParameter("@CreatedOn", SqlDbType.DateTimeOffset);

        //
        private static User createUser(IDataReader dbReader)
        {
            User user = new User();
            user.userId = Convert.ToInt32(dbReader["UserId"]);
            user.userName = Convert.ToString(dbReader["UserName"]);
            user.hashedPassword = Convert.ToString(dbReader["HashedPassword"]);
            user.firstName = Convert.ToString(dbReader["Firstname"]);
            user.lastName = Convert.ToString(dbReader["LastName"]);
            user.email = Convert.ToString(dbReader["Email"]);
            user.newsletterOptOut = Convert.ToBoolean(dbReader["NewsletterOptOut"]);
            user.createdOn = Convert.ToDateTime(dbReader["CreatedOn"]);
            return user;
        }

        //
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

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    param_userName.Value = user.userName;
                    sqlCommand.Parameters.Add(param_userName);

                    param_hashedPassword.Value = user.hashedPassword;
                    sqlCommand.Parameters.Add(param_hashedPassword);

                    param_firstName.Value = user.firstName;
                    sqlCommand.Parameters.Add(param_firstName);

                    param_lastName.Value = user.lastName;
                    sqlCommand.Parameters.Add(param_lastName);

                    param_email.Value = user.email;
                    sqlCommand.Parameters.Add(param_email);

                    param_newsletterOptOut.Value = user.newsletterOptOut;
                    sqlCommand.Parameters.Add(param_newsletterOptOut);

                    param_createdOn.Value = user.createdOn;
                    sqlCommand.Parameters.Add(param_createdOn);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();

                    sqlCommand.Parameters.Clear();
                }
                catch (InvalidOperationException ioEx)
                {
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    DEBUG.Log.Add(ex.ToString());
                }
                return result;
            }
        }
    }
}