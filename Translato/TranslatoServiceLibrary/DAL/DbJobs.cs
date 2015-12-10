//author: adrian
//helpers: futz
//last_checked: futz@10.12.2015

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbJobs : IJobs
    {
        //define sql parameters
        private SqlParameter param_jobId;
        private SqlParameter param_jobName;
        private SqlParameter param_dateCreated;
        private SqlParameter param_durationInDays;
        private SqlParameter param_reward;
        private SqlParameter param_dateAwarded;
        private SqlParameter param_languageFrom;
        private SqlParameter param_languageTo;
        private SqlParameter param_userId;
        private SqlParameter param_uploadId;
        //
        private SqlParameter param_offset;
        private SqlParameter param_limit;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_jobId = new SqlParameter("@JobId", SqlDbType.Int);
            param_jobName = new SqlParameter("@JobName", SqlDbType.NVarChar, 50);
            param_dateCreated = new SqlParameter("@DateCreated", SqlDbType.DateTimeOffset);
            param_durationInDays = new SqlParameter("@DurationInDays", SqlDbType.Int);
            param_reward = new SqlParameter("@Reward", SqlDbType.Decimal);
            param_dateAwarded = new SqlParameter("@DateAwarded", SqlDbType.DateTimeOffset);
            param_languageFrom = new SqlParameter("@LanguageFrom", SqlDbType.Int);
            param_languageTo = new SqlParameter("@LanguageTo", SqlDbType.Int);
            param_userId = new SqlParameter("@UserId", SqlDbType.Int);
            param_uploadId = new SqlParameter("@UploadId", SqlDbType.Int);
            //
            param_offset = new SqlParameter("@Offset", SqlDbType.Int);
            param_limit = new SqlParameter("@Limit", SqlDbType.Int);
        }

        //dbReader
        private static Job createJob(IDataReader dbReader)
        {
            Job job = new Job();
            job.jobId = Convert.ToInt32(dbReader["JobId"]);
            job.jobName = Convert.ToString(dbReader["JobName"]);
            job.dateCreated = (DateTimeOffset)dbReader["DateCreated"];
            job.durationInDays = Convert.ToInt32(dbReader["DurationInDays"]);
            job.reward = Convert.ToDecimal(dbReader["Reward"]);
            if (dbReader["DateAwarded"] != null && dbReader["DateAwarded"] != DBNull.Value)
            {
                job.dateAwarded = (DateTimeOffset)dbReader["DateAwarded"];
            }
            else { job.dateAwarded = null; }
            job.languageFrom = new Language();
            job.languageFrom.languageId = Convert.ToInt32(dbReader["LanguageFrom"]);
            job.languageTo = new Language();
            job.languageTo.languageId = Convert.ToInt32(dbReader["LanguageTo"]);
            job.user = new User();
            job.user.userId = Convert.ToInt32(dbReader["UserId"]);
            job.upload = new Upload();
            job.upload.uploadId = Convert.ToInt32(dbReader["UploadId"]);
            return job;
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertJob(Job job)
        {
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Jobs OUTPUT INSERTED.JobId VALUES (" +
                "@JobName, " +
                "@DateCreated, " +
                "@DurationInDays, " +
                "@Reward, " +
                "NULL, " +
                "@LanguageFrom, " +
                "@LanguageTo, " +
                "@UserId, " +
                "@UploadId" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_jobName.Value = job.jobName;
                        sqlCommand.Parameters.Add(param_jobName);

                        param_dateCreated.Value = job.dateCreated;
                        sqlCommand.Parameters.Add(param_dateCreated);

                        param_durationInDays.Value = job.durationInDays;
                        sqlCommand.Parameters.Add(param_durationInDays);

                        param_reward.Value = job.reward;
                        sqlCommand.Parameters.Add(param_reward);

                        param_languageFrom.Value = job.languageFrom.languageId;
                        sqlCommand.Parameters.Add(param_languageFrom);

                        param_languageTo.Value = job.languageTo.languageId;
                        sqlCommand.Parameters.Add(param_languageTo);

                        param_userId.Value = job.user.userId;
                        sqlCommand.Parameters.Add(param_userId);

                        param_uploadId.Value = job.upload.uploadId;
                        sqlCommand.Parameters.Add(param_uploadId);

                        sqlCommand.Connection.Open();
                        returnCode = (int)sqlCommand.ExecuteScalar();
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBJOBS_INSERTJOB_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBJOBS_INSERTJOB_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBJOBS_INSERTJOB_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBJOBS_INSERTJOB_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
            }
        }

        //returns "MODEL.Job" object if successful
        //returns "null" if not
        public Job findJobByJobId(int jobId)
        {
            string sqlQuery = "SELECT * FROM Jobs WHERE " +
                "JobId = @JobId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Job job = new Job();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_jobId.Value = jobId;
                        sqlCommand.Parameters.Add(param_jobId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { job = createJob(dbReader); }
                        else { job = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    job = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    job = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    job = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    job = null;
                    Log.Add(ex.ToString());
                }
                return job;
            }
        }

        //returns "List<MODEL.Job>" object if successful
        //returns "null" if not
        public List<Job> getAllJobs(int offset, int limit)
        {
            string sqlQuery = "SELECT * FROM Jobs " +
                "ORDER BY DateCreated DESC " +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                List<Job> jobs = new List<Job>();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_offset.Value = offset;
                        sqlCommand.Parameters.Add(param_offset);

                        param_limit.Value = limit;
                        sqlCommand.Parameters.Add(param_limit);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        while (dbReader.Read())
                        {
                            Job job = createJob(dbReader);
                            jobs.Add(job);
                        }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    jobs = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    jobs = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    jobs = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    jobs = null;
                    Log.Add(ex.ToString());
                }
                return jobs;
            }
        }
    }
}    
