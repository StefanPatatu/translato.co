//author: adrian
//helpers: futz
//last_checked: futz@08.12.2015

using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbSubmissions : ISubmissions
    {
        //define sql parameters
        private SqlParameter param_submissionId;
        private SqlParameter param_dateSubmitted;
        private SqlParameter param_isAwarded;
        private SqlParameter param_userId;
        private SqlParameter param_uploadId;
        private SqlParameter param_jobId;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_submissionId = new SqlParameter("@SubmissionId", SqlDbType.Int);
            param_dateSubmitted = new SqlParameter("@DateSubmitted", SqlDbType.DateTimeOffset);
            param_isAwarded = new SqlParameter("@IsAwarded", SqlDbType.Bit);
            param_userId = new SqlParameter("@UserId", SqlDbType.Int);
            param_uploadId = new SqlParameter("@UploadId", SqlDbType.Int);
            param_jobId = new SqlParameter("@JobId", SqlDbType.Int);
        }

        //dbReader
        private static Submission createSubmission(IDataReader dbReader)
        {
            Submission submission = new Submission();
            submission.submissionId = Convert.ToInt32(dbReader["SubmissionId"]);
            submission.dateSubmitted = (DateTimeOffset)dbReader["DateSubmitted"];
            submission.isAwarded = Convert.ToBoolean(dbReader["IsAwarded"]);
            submission.user.userId = Convert.ToInt32(dbReader["UserId"]);
            submission.upload.uploadId = Convert.ToInt32(dbReader["UploadId"]);
            submission.job.jobId = Convert.ToInt32(dbReader["JobId"]);
            return submission;
        }

        //returns
        //returns
        //todo@futz
        public int insertSubmission(Submission submission)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Submissions VALUES (" +
                "@DateSubmitted, " +
                "@IsAwarded, " +
                "@UserId, " +
                "@UploadId, " +
                "@JobId " +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    param_dateSubmitted.Value = submission.dateSubmitted;
                    sqlCommand.Parameters.Add(param_dateSubmitted);

                    param_isAwarded.Value = submission.isAwarded;
                    sqlCommand.Parameters.Add(param_isAwarded);

                    param_userId.Value = submission.user.userId;
                    sqlCommand.Parameters.Add(param_userId);

                    param_uploadId.Value = submission.upload.uploadId;
                    sqlCommand.Parameters.Add(param_uploadId);

                    param_jobId.Value = submission.job.jobId;
                    sqlCommand.Parameters.Add(param_jobId);

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
