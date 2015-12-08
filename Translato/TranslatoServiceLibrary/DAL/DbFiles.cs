//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbFiles : IFiles
    {
        //define sql parameters
        private static SqlParameter param_textId = new SqlParameter("@FileId", SqlDbType.Int);

        //dbReader
        private static File createFile(IDataReader dbReader)
        {
            File file = new File();
            file.fileId = Convert.ToInt32(dbReader["TextId"]);
            return file;
        }

        //returns
        //returns
        //todo@futz
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
                    X.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    X.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    X.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    X.Log.Add(ex.ToString());
                }
                return result;
            }
        }
    }
}
