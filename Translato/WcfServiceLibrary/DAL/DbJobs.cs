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
    public class DbJobs : IJobs
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_JobId = new SqlParameter("@JobId", SqlDbType.Int);
        private static SqlParameter param_JobName = new SqlParameter("@JobName", SqlDbType.NVarChar, 50);
        private static SqlParameter param_DateCreated = new SqlParameter("@DateCreated", SqlDbType.DateTimeOffset);
        private static SqlParameter param_DurationInDays = new SqlParameter("@DurationInDays", SqlDbType.Int);
        private static SqlParameter param_Reward = new SqlParameter("@Reward", SqlDbType.Decimal);
        private static SqlParameter param_DateAwarded = new SqlParameter("@DateAwarded", SqlDbType.DateTimeOffset);
        private static SqlParameter param_LanguageFrom = new SqlParameter("@LanguageFrom", SqlDbType.Int);
        private static SqlParameter param_LanguageTo = new SqlParameter("@LanguageTo", SqlDbType.Int);
        private static SqlParameter param_UserId = new SqlParameter("@UserId", SqlDbType.Int);
        private static SqlParameter param_UploadId = new SqlParameter("@UploadId", SqlDbType.Int);


        private static Job createJob(IDataReader dbReader)
        {
            Job job = new Job();
            job.JobId = Convert.ToInt32(dbReader["JobId"]);
            job.JobName = Convert.ToString(dbReader["JobName"]);
            job.DateCreated = Convert.ToDateTime(dbReader["DateCreated"]);
            job.DurationInDays = Convert.ToInt32(dbReader["DurationInDays"]);
            job.Reward = Convert.ToDecimal(dbReader["Reward"]);
            job.DateAwarded = Convert.ToDateTime(dbReader["DateAwarded"]);
            job.LanguageFrom.LanguageId = Convert.ToInt32(dbReader["LanguageFrom"]);
            job.LanguageTo.LanguageId = Convert.ToInt32(dbReader["LanguageTo"]);
            job.User.UserId = Convert.ToInt32(dbReader["UserId"]);
            job.Upload.UploadId = Convert.ToInt32(dbReader["UploadId"]);
            return job;
        }

        public int insertJob(Job job)
        {
            int result = -1;
            string sqlQuery = "INSERT INTO Jobs VALUES (" +
                "@JobName, " +
                "@DateCreated, " +
                "@DurationInDays, " +
                "@Reward, " +
                "@DateAwarded, " +
                "@LanguageFrom, " +
                "@LanguageTo, " +
                "@UserId, " +
                "@UploadId " +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    param_JobName.Value = job.JobName;
                    sqlCommand.Parameters.Add(param_JobName);

                    param_DateCreated.Value = job.DateCreated;
                    sqlCommand.Parameters.Add(param_DateCreated);

                    param_DurationInDays.Value = job.DurationInDays;
                    sqlCommand.Parameters.Add(param_DurationInDays);

                    param_Reward.Value = job.Reward;
                    sqlCommand.Parameters.Add(param_Reward);

                    param_DateAwarded.Value = job.DateAwarded;
                    sqlCommand.Parameters.Add(param_DateAwarded);

                    param_LanguageFrom.Value = job.LanguageFrom;
                    sqlCommand.Parameters.Add(param_LanguageFrom);

                    param_LanguageTo.Value = job.LanguageTo;
                    sqlCommand.Parameters.Add(param_LanguageTo);

                    param_UserId.Value = job.User.UserId;
                    sqlCommand.Parameters.Add(param_UserId);

                    param_UploadId.Value = job.Upload.UploadId;
                    sqlCommand.Parameters.Add(param_UploadId);

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
