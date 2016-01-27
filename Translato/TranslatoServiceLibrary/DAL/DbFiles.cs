//author: adrian
//helpers: futz
//last_checked: futz@11.12.2015
//talked about with Alex

using ENUM;
using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbFiles : IFiles
    {
        //define sql parameters
        private SqlParameter param_fileId;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_fileId = new SqlParameter("@FileId", SqlDbType.Int);
        }

        //dbReader
        private static File createFile(IDataReader dbReader)
        {
            File file = new File();
            file.fileId = Convert.ToInt32(dbReader["TextId"]);
            return file;
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertFile(File file)
        {
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Files OUTPUT INSERTED.FileId DEFAULT VALUES";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlCommand.Connection.Open();
                        returnCode = (int)sqlCommand.ExecuteScalar();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBFILES_INSERTFILE_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBFILES_INSERTFILE_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBFILES_INSERTFILE_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBFILES_INSERTFILE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
            }
        }
    }
}
