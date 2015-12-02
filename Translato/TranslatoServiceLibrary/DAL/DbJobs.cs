//author: adrian
//helpers:
//last_cheked: futz@20.11.2015

using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    public class DbJobs : IJobs
    {
        //define sql parameters
        private static SqlParameter param_jobId = new SqlParameter("@JobId", SqlDbType.Int);
        private static SqlParameter param_jobName = new SqlParameter("@JobName", SqlDbType.NVarChar, 50);
        private static SqlParameter param_dateCreated = new SqlParameter("@DateCreated", SqlDbType.DateTimeOffset);
        private static SqlParameter param_durationInDays = new SqlParameter("@DurationInDays", SqlDbType.Int);
        private static SqlParameter param_reward = new SqlParameter("@Reward", SqlDbType.Decimal);
        private static SqlParameter param_dateAwarded = new SqlParameter("@DateAwarded", SqlDbType.DateTimeOffset);
        private static SqlParameter param_languageFrom = new SqlParameter("@LanguageFrom", SqlDbType.Int);
        private static SqlParameter param_languageTo = new SqlParameter("@LanguageTo", SqlDbType.Int);
        private static SqlParameter param_userId = new SqlParameter("@UserId", SqlDbType.Int);
        private static SqlParameter param_uploadId = new SqlParameter("@UploadId", SqlDbType.Int);

        //
        private static Job createJob(IDataReader dbReader)
        {
            Job job = new Job();
            job.jobId = Convert.ToInt32(dbReader["JobId"]);
            job.jobName = Convert.ToString(dbReader["JobName"]);
            job.dateCreated = Convert.ToDateTime(dbReader["DateCreated"]);
            job.durationInDays = Convert.ToInt32(dbReader["DurationInDays"]);
            job.reward = Convert.ToDecimal(dbReader["Reward"]);
            job.dateAwarded = Convert.ToDateTime(dbReader["DateAwarded"]);
            job.languageFrom.languageId = Convert.ToInt32(dbReader["LanguageFrom"]);
            job.languageTo.languageId = Convert.ToInt32(dbReader["LanguageTo"]);
            job.user.userId = Convert.ToInt32(dbReader["UserId"]);
            job.upload.uploadId = Convert.ToInt32(dbReader["UploadId"]);
            return job;
        }

        //
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

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    param_jobName.Value = job.jobName;
                    sqlCommand.Parameters.Add(param_jobName);

                    param_dateCreated.Value = job.dateCreated;
                    sqlCommand.Parameters.Add(param_dateCreated);

                    param_durationInDays.Value = job.durationInDays;
                    sqlCommand.Parameters.Add(param_durationInDays);

                    param_reward.Value = job.reward;
                    sqlCommand.Parameters.Add(param_reward);

                    param_dateAwarded.Value = job.dateAwarded;
                    sqlCommand.Parameters.Add(param_dateAwarded);

                    param_languageFrom.Value = job.languageFrom;
                    sqlCommand.Parameters.Add(param_languageFrom);

                    param_languageTo.Value = job.languageTo;
                    sqlCommand.Parameters.Add(param_languageTo);

                    param_userId.Value = job.user.userId;
                    sqlCommand.Parameters.Add(param_userId);

                    param_uploadId.Value = job.upload.uploadId;
                    sqlCommand.Parameters.Add(param_uploadId);

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
