using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public class DbUploads : IUploads
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_UploadId = new SqlParameter("@UploadId", SqlDbType.Int);
        private static SqlParameter param_TextId = new SqlParameter("@TextId", SqlDbType.Int);
        private static SqlParameter param_FileId = new SqlParameter("@FileId", SqlDbType.Int);

        private static Upload createUpload(IDataReader dbReader)
        {
            Upload upload = new Upload();
            upload.UploadId = Convert.ToInt32(dbReader["UploadId"]);
            upload.Text.TextId = Convert.ToInt32(dbReader["TextId"]);
           
            return upload;
        }

        public int insertUploadText(Upload upload)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Uploads VALUES (" +
                "@TextId, " +
                "NULL" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    param_TextId.Value = upload.Text.TextId;
                    sqlCommand.Parameters.Add(param_TextId);


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
                return result;
            }
        }

        public int insertUploadFile(Upload upload)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Uploads VALUES (" +
                "NULL, " +
                "@FileId" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    

                    param_FileId.Value = upload.File.FileId;
                    sqlCommand.Parameters.Add(param_FileId);

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
                return result;
            }
        }
    }
}
