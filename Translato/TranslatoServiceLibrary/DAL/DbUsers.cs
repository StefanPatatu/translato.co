﻿//author: futz
//helpers:
//last_cheked: futz@03.12.2015

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

        //dbReader
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
            user.createdOn = (DateTimeOffset)dbReader["CreatedOn"];
            return user;
        }

        //returns "1" if successful
        //returns "0" if not
        public int insertUser(User user)
        {
            int result = 0;

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

                    if (sqlCommand.Parameters.Contains(param_userName)) sqlCommand.Parameters.Remove(param_userName);
                    param_userName.Value = user.userName;
                    sqlCommand.Parameters.Add(param_userName);

                    if (sqlCommand.Parameters.Contains(param_hashedPassword)) sqlCommand.Parameters.Remove(param_hashedPassword);
                    param_hashedPassword.Value = user.hashedPassword;
                    sqlCommand.Parameters.Add(param_hashedPassword);

                    if (sqlCommand.Parameters.Contains(param_firstName)) sqlCommand.Parameters.Remove(param_firstName);
                    param_firstName.Value = user.firstName;
                    sqlCommand.Parameters.Add(param_firstName);

                    if (sqlCommand.Parameters.Contains(param_lastName)) sqlCommand.Parameters.Remove(param_lastName);
                    param_lastName.Value = user.lastName;
                    sqlCommand.Parameters.Add(param_lastName);

                    if (sqlCommand.Parameters.Contains(param_email)) sqlCommand.Parameters.Remove(param_email);
                    param_email.Value = user.email;
                    sqlCommand.Parameters.Add(param_email);

                    if (sqlCommand.Parameters.Contains(param_newsletterOptOut)) sqlCommand.Parameters.Remove(param_newsletterOptOut);
                    param_newsletterOptOut.Value = user.newsletterOptOut;
                    sqlCommand.Parameters.Add(param_newsletterOptOut);

                    if (sqlCommand.Parameters.Contains(param_createdOn)) sqlCommand.Parameters.Remove(param_createdOn);
                    param_createdOn.Value = user.createdOn;
                    sqlCommand.Parameters.Add(param_createdOn);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_userName)) sqlCommand.Parameters.Remove(param_userName);
                    if (sqlCommand.Parameters.Contains(param_hashedPassword)) sqlCommand.Parameters.Remove(param_hashedPassword);
                    if (sqlCommand.Parameters.Contains(param_firstName)) sqlCommand.Parameters.Remove(param_firstName);
                    if (sqlCommand.Parameters.Contains(param_lastName)) sqlCommand.Parameters.Remove(param_lastName);
                    if (sqlCommand.Parameters.Contains(param_email)) sqlCommand.Parameters.Remove(param_email);
                    if (sqlCommand.Parameters.Contains(param_newsletterOptOut)) sqlCommand.Parameters.Remove(param_newsletterOptOut);
                    if (sqlCommand.Parameters.Contains(param_createdOn)) sqlCommand.Parameters.Remove(param_createdOn);

                    sqlCommand.Dispose();
                }
                catch (InvalidOperationException ioEx)
                {
                    result = 0;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    result = 0;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    result = 0;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
                return result;
            }
        }

        //returns "MODEL.User" object if successful
        //returns "null" if not
        public User findUserById(int userId)
        {
            string sqlQuery = "SELECT * FROM Users WHERE " +
                "UserId = @UserId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                User user = new User();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_userId)) sqlCommand.Parameters.Remove(param_userId);
                    param_userId.Value = userId;
                    sqlCommand.Parameters.Add(param_userId);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if (dbReader.Read()) { user = createUser(dbReader); }
                    else { user = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_userId)) sqlCommand.Parameters.Remove(param_userId);
                }
                catch (InvalidOperationException ioEx)
                {
                    user = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    user = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    user = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    user = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return user;
            }
        }

        //returns "MODEL.User" object if successful
        //returns "null" if not
        public User findUserByUserName(string userName)
        {
            string sqlQuery = "SELECT * FROM Users WHERE " +
                "UserName = @UserName";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                User user = new User();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_userName)) sqlCommand.Parameters.Remove(param_userName);
                    param_userName.Value = userName;
                    sqlCommand.Parameters.Add(param_userName);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if (dbReader.Read()) { user = createUser(dbReader); }
                    else { user = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_userName)) sqlCommand.Parameters.Remove(param_userName);
                }
                catch (InvalidOperationException ioEx)
                {
                    user = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    user = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    user = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    user = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return user;
            }
        }

        //returns "MODEL.User" object if successful
        //returns "null" if not
        public User findUserByEmail(string email)
        {
            string sqlQuery = "SELECT * FROM Users WHERE " +
                "Email = @Email";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                User user = new User();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_email)) sqlCommand.Parameters.Remove(param_email);
                    param_email.Value = email;
                    sqlCommand.Parameters.Add(param_email);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if (dbReader.Read()) { user = createUser(dbReader); }
                    else { user = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_email)) sqlCommand.Parameters.Remove(param_email);
                }
                catch (InvalidOperationException ioEx)
                {
                    user = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    user = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    user = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    user = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return user;
            }
        }
    }
}
