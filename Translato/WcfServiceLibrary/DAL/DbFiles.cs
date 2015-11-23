﻿//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using System;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public class DbFiles : IFiles
    {
        //define sql parameters
        private static SqlParameter param_textId = new SqlParameter("@FileId", SqlDbType.Int);

        //
        private static File createFile(IDataReader dbReader)
        {
            File file = new File();
            file.fileId = Convert.ToInt32(dbReader["TextId"]);
            return file;
        }

        //
        public int insertFile(File file)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Files DEFAULT VALUES";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();

                    sqlCommand.Parameters.Clear();
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
