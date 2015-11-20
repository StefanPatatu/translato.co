//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using System;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public class DbSubmissions : ISubmissions
    {
        //define sql parameters
        private static SqlParameter param_submissionId = new SqlParameter("@SubmissionIs", SqlDbType.Int);
        private static SqlParameter param_dateSubmitted = new SqlParameter("@DateSubmitted", SqlDbType.DateTimeOffset);
        private static SqlParameter param_isAwarded = new SqlParameter("@IsAwarded", SqlDbType.Bit);
        private static SqlParameter param_userId = new SqlParameter("@UserId", SqlDbType.Int);
        private static SqlParameter param_uploadId = new SqlParameter("@UploadId", SqlDbType.Int);
        private static SqlParameter param_jobId = new SqlParameter("@JobId", SqlDbType.Int);

        //
        private static Submission createSubmission(IDataReader dbReader)
        {
            Submission submission = new Submission();
            submission.submissionId = Convert.ToInt32(dbReader["SubmissionId"]);
            submission.dateSubmitted = Convert.ToDateTime(dbReader["DateSubmitted"]);
            submission.isAwarded = Convert.ToBoolean(dbReader["IsAwarded"]);
            submission.user.userId = Convert.ToInt32(dbReader["UserId"]);
            submission.upload.uploadId = Convert.ToInt32(dbReader["UploadId"]);
            submission.job.jobId = Convert.ToInt32(dbReader["JobId"]);
            return submission;
        }

        //
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

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

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
