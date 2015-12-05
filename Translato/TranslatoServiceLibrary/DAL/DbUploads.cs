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

        //author adrian
        //returns "1" successful
        //returns "0" if not
        public int insertUploadText(Upload upload)
        {
            int result = 0;

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

                    if (sqlCommand.Parameters.Contains(param_textId)) sqlCommand.Parameters.Remove(param_textId);
                    param_textId.Value = upload.text.textId;
                    sqlCommand.Parameters.Add(param_textId);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_textId)) sqlCommand.Parameters.Remove(param_textId);

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

        //author adrian
        //returns "1" successful
        //returns "0" if not
        public int insertUploadFile(Upload upload)
        {
            int result = 0;

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

                    if (sqlCommand.Parameters.Contains(param_fileId)) sqlCommand.Parameters.Remove(param_fileId);
                    param_fileId.Value = upload.file.fileId;
                    sqlCommand.Parameters.Add(param_fileId);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_fileId)) sqlCommand.Parameters.Remove(param_fileId);

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

        //author adrian
        //returns "MODEL.Upload" object if successful
        //returns "null" if not
        public Upload findUploadById(int uploadId)
        {
            string sqlQuery = "SELECT * FROM Uploads WHERE " +
                "UploadId = @UploadId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Upload upload = new Upload();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_uploadId)) sqlCommand.Parameters.Remove(param_uploadId);
                    param_uploadId.Value = uploadId;
                    sqlCommand.Parameters.Add(param_uploadId);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if (dbReader.Read()) { upload = createUpload(dbReader); }
                    else { upload = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_uploadId)) sqlCommand.Parameters.Remove(param_uploadId);
                }
                catch (InvalidOperationException ioEx)
                {
                    upload = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    upload = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    upload = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    upload = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return upload;
            }
        }

        //author adrian
        //returns "Model.Upload" object if successful
        //returns "null if not"
        public Upload findUploadByTextId(int textId)
        {
            string sqlQuery = "SELECT * FROM Uploads WHERE " +
                "TextId = @TextId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Upload upload = new Upload();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_textId)) sqlCommand.Parameters.Remove(param_textId);
                    param_textId.Value = textId;
                    sqlCommand.Parameters.Add(param_textId);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if(dbReader.Read()) { upload = createUpload(dbReader); }
                    else { upload = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_textId)) sqlCommand.Parameters.Remove(param_textId);
                }
                catch (InvalidOperationException ioEx)
                {
                    upload = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    upload = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    upload = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    upload = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return upload;
            }
        }

    }
}
