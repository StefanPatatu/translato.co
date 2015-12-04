//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbUploads : IUploads
    {
        //define sql parameters
        private static SqlParameter param_uploadId = new SqlParameter("@UploadId", SqlDbType.Int);
        private static SqlParameter param_textId = new SqlParameter("@TextId", SqlDbType.Int);
        private static SqlParameter param_fileId = new SqlParameter("@FileId", SqlDbType.Int);

        //dbReader
        private static Upload createUpload(IDataReader dbReader)
        {
            Upload upload = new Upload();
            upload.uploadId = Convert.ToInt32(dbReader["UploadId"]);
            upload.text.textId = Convert.ToInt32(dbReader["TextId"]);
            return upload;
        }

        //returns
        //returns
        //todo@futz
        public int insertUploadText(Upload upload)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Uploads VALUES (" +
                "@TextId, " +
                "NULL" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    param_textId.Value = upload.text.textId;
                    sqlCommand.Parameters.Add(param_textId);

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

        //returns
        //returns
        //todo@futz
        public int insertUploadFile(Upload upload)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Uploads VALUES (" +
                "NULL, " +
                "@FileId" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    param_fileId.Value = upload.file.fileId;
                    sqlCommand.Parameters.Add(param_fileId);

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
