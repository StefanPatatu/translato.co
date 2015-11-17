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
    public class DbSubmissions : ISubmissions
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_SubmissionId = new SqlParameter("@SubmissionIs", SqlDbType.Int);
        private static SqlParameter param_DateSubmitted = new SqlParameter("@DateSubmitted", SqlDbType.DateTimeOffset);
        private static SqlParameter param_IsAwarded = new SqlParameter("@IsAwarded", SqlDbType.Bit);
        private static SqlParameter param_UserId = new SqlParameter("@UserId", SqlDbType.Int);
        private static SqlParameter param_UploadId = new SqlParameter("@UploadId", SqlDbType.Int);
        private static SqlParameter param_JobId = new SqlParameter("@JobId", SqlDbType.Int);

        private static Submission createSubmission(IDataReader dbReader)
        {
            Submission submission = new Submission();
            submission.SubmissionId = Convert.ToInt32(dbReader["SubmissionId"]);
            submission.DateSubmitted = Convert.ToDateTime(dbReader["DateSubmitted"]);
            submission.IsAwarded = Convert.ToBoolean(dbReader["IsAwarded"]);
            submission.User.UserId = Convert.ToInt32(dbReader["UserId"]);
            submission.Upload.UploadId = Convert.ToInt32(dbReader["UploadId"]);
            submission.Job.JobId = Convert.ToInt32(dbReader["JobId"]);
            
            return submission;
        }

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

                    param_DateSubmitted.Value = submission.DateSubmitted;
                    sqlCommand.Parameters.Add(param_DateSubmitted);

                    param_IsAwarded.Value = submission.IsAwarded;
                    sqlCommand.Parameters.Add(param_IsAwarded);

                    param_UserId.Value = submission.User.UserId;
                    sqlCommand.Parameters.Add(param_UserId);

                    param_UploadId.Value = submission.Upload.UploadId;
                    sqlCommand.Parameters.Add(param_UploadId);

                    param_JobId.Value = submission.Job.JobId;
                    sqlCommand.Parameters.Add(param_JobId);

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
