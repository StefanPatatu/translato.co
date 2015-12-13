//author: adrian
//helpers: futz
//last_checked: futz@11.12.2015

using ENUM;
using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbUploads : IUploads
    {
        //define sql parameters
        private SqlParameter param_uploadId;
        private SqlParameter param_textId;
        private SqlParameter param_fileId;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_uploadId = new SqlParameter("@UploadId", SqlDbType.Int);
            param_textId = new SqlParameter("@TextId", SqlDbType.Int);
            param_fileId = new SqlParameter("@FileId", SqlDbType.Int);
        }

        //dbReader
        private static Upload createUpload(IDataReader dbReader)
        {
            Upload upload = new Upload();
            upload.uploadId = Convert.ToInt32(dbReader["UploadId"]);
            if (dbReader["TextId"] != null && dbReader["TextId"] != DBNull.Value)
            {
                upload.text = new Text();
                upload.text.textId = Convert.ToInt32(dbReader["TextId"]);
            }
            else { upload.text = null; }
            if (dbReader["FileId"] != null && dbReader["FileId"] != DBNull.Value)
            {
                upload.file = new File();
                upload.file.fileId = Convert.ToInt32(dbReader["FileId"]);
            }
            else { upload.file = null; }
            return upload;
        }

        //author: adrian
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertUploadText(Upload upload)
        {                                    
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Uploads OUTPUT INSERTED.UploadId VALUES (" +
                "@TextId, " +
                "NULL" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_textId.Value = upload.text.textId;
                        sqlCommand.Parameters.Add(param_textId);

                        sqlCommand.Connection.Open();
                        returnCode = (int)sqlCommand.ExecuteScalar();
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADTEXT_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADTEXT_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADTEXT_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADTEXT_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
            }
        }

        //author: adrian
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertUploadFile(Upload upload)
        {
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Uploads OUTPUT INSERTED.UploadId VALUES (" +
                "NULL, " +
                "@FileId" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_fileId.Value = upload.file.fileId;
                        sqlCommand.Parameters.Add(param_fileId);

                        sqlCommand.Connection.Open();
                        returnCode = (int)sqlCommand.ExecuteScalar();
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADFILE_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADFILE_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADFILE_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBUPLOADS_INSERTUPLOADFILE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
            }
        }

        //author: adrian
        //returns "MODEL.Upload" object if successful
        //returns "null" if not
        public Upload findUploadByUploadId(int uploadId)
        {
            string sqlQuery = "SELECT * FROM Uploads WHERE " +
                "UploadId = @UploadId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Upload upload = new Upload();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_uploadId.Value = uploadId;
                        sqlCommand.Parameters.Add(param_uploadId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { upload = createUpload(dbReader); }
                        else { upload = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    upload = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    upload = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    upload = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    upload = null;
                    Log.Add(ex.ToString());
                }
                return upload;
            }
        }

        //author: adrian
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
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_textId.Value = textId;
                        sqlCommand.Parameters.Add(param_textId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { upload = createUpload(dbReader); }
                        else { upload = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    upload = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    upload = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    upload = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    upload = null;
                    Log.Add(ex.ToString());
                }
                return upload;
            }
        }

        //author: futz
        //returns "Model.Upload" object if successful
        //returns "null if not"
        public Upload findUploadByFileId(int fileId)
        {
            string sqlQuery = "SELECT * FROM Uploads WHERE " +
                "FileId = @FileId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Upload upload = new Upload();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_fileId.Value = fileId;
                        sqlCommand.Parameters.Add(param_fileId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { upload = createUpload(dbReader); }
                        else { upload = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    upload = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    upload = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    upload = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    upload = null;
                    Log.Add(ex.ToString());
                }
                return upload;
            }
        }
    }
}
