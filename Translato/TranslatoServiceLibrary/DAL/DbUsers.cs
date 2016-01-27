//author: futz
//helpers:
//last_cheked: futz@11.12.2015
//talked about with Alex

using ENUM;
using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbUsers : IUsers
    {
        //define sql parameters
        private SqlParameter param_userId;
        private SqlParameter param_userName;
        private SqlParameter param_hashedPassword;
        private SqlParameter param_firstName;
        private SqlParameter param_lastName;
        private SqlParameter param_email;
        private SqlParameter param_newsletterOptOut;
        private SqlParameter param_createdOn;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_userId = new SqlParameter("@UserId", SqlDbType.Int);
            param_userName = new SqlParameter("@UserName", SqlDbType.VarChar, 15);
            param_hashedPassword = new SqlParameter("@HashedPassword", SqlDbType.Char, 100);
            param_firstName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 20);
            param_lastName = new SqlParameter("@LastName", SqlDbType.NVarChar, 20);
            param_email = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            param_newsletterOptOut = new SqlParameter("@NewsletterOptOut", SqlDbType.Bit);
            param_createdOn = new SqlParameter("@CreatedOn", SqlDbType.DateTimeOffset);
        }

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

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertUser(User user)
        {
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Users OUTPUT INSERTED.UserId VALUES (" +
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
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
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
                        returnCode = (int)sqlCommand.ExecuteScalar();
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBUSERS_INSERTUSER_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBUSERS_INSERTUSER_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBUSERS_INSERTUSER_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBUSERS_INSERTUSER_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
            }
        }

        //returns "MODEL.User" object if successful
        //returns "null" if not
        public User findUserByUserId(int userId)
        {
            string sqlQuery = "SELECT * FROM Users WHERE " +
                "UserId = @UserId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                User user = new User();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_userId.Value = userId;
                        sqlCommand.Parameters.Add(param_userId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { user = createUser(dbReader); }
                        else { user = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    user = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    user = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    user = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    user = null;
                    Log.Add(ex.ToString());
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
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_userName.Value = userName;
                        sqlCommand.Parameters.Add(param_userName);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { user = createUser(dbReader); }
                        else { user = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    user = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    user = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    user = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    user = null;
                    Log.Add(ex.ToString());
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
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_email.Value = email;
                        sqlCommand.Parameters.Add(param_email);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { user = createUser(dbReader); }
                        else { user = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    user = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    user = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    user = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    user = null;
                    Log.Add(ex.ToString());
                }
                return user;
            }
        }
    }
}
