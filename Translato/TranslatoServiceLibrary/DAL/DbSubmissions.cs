//author: adrian
//helpers: futz
//last_checked: futz@11.12.2015
//talked about with Alex

using ENUM;
using System;
using System.Collections.Generic;
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
        //
        private SqlParameter param_startTime;
        private SqlParameter param_endTime;
        //
        private SqlParameter param_offset;
        private SqlParameter param_limit;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_submissionId = new SqlParameter("@SubmissionId", SqlDbType.Int);
            param_dateSubmitted = new SqlParameter("@DateSubmitted", SqlDbType.DateTimeOffset);
            param_isAwarded = new SqlParameter("@IsAwarded", SqlDbType.Bit);
            param_userId = new SqlParameter("@UserId", SqlDbType.Int);
            param_uploadId = new SqlParameter("@UploadId", SqlDbType.Int);
            param_jobId = new SqlParameter("@JobId", SqlDbType.Int);
            //
            param_startTime = new SqlParameter("@StartTime", SqlDbType.DateTimeOffset);
            param_endTime = new SqlParameter("@EndTime", SqlDbType.DateTimeOffset);
            //
            param_offset = new SqlParameter("@Offset", SqlDbType.Int);
            param_limit = new SqlParameter("@Limit", SqlDbType.Int);
        }

        //dbReader
        private static Submission createSubmission(IDataReader dbReader)
        {
            Submission submission = new Submission();
            submission.submissionId = Convert.ToInt32(dbReader["SubmissionId"]);
            submission.dateSubmitted = (DateTimeOffset)dbReader["DateSubmitted"];
            submission.isAwarded = Convert.ToBoolean(dbReader["IsAwarded"]);
            submission.user = new User();
            submission.user.userId = Convert.ToInt32(dbReader["UserId"]);
            submission.upload = new Upload();
            submission.upload.uploadId = Convert.ToInt32(dbReader["UploadId"]);
            submission.job = new Job();
            submission.job.jobId = Convert.ToInt32(dbReader["JobId"]);
            return submission;
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertSubmission(Submission submission)
        {
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Submissions OUTPUT INSERTED.SubmissionId VALUES (" +
                "@DateSubmitted, " +
                "@IsAwarded, " +
                "@UserId, " +
                "@UploadId, " +
                "@JobId" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
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
                        returnCode = (int)sqlCommand.ExecuteScalar();
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBSUBMISSIONS_INSERTSUBMISSION_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBSUBMISSIONS_INSERTSUBMISSION_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBSUBMISSIONS_INSERTSUBMISSION_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBSUBMISSIONS_INSERTSUBMISSION_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
            }
        }

        //returns "MODEL.Submission" object if successful
        //returns "null" if not
        public Submission findSubmissionBySubmissionId(int submissionId)
        {
            string sqlQuery = "SELECT * FROM Submissions WHERE " +
                "SubmissionId = @SubmissionId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Submission submission = new Submission();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_submissionId.Value = submissionId;
                        sqlCommand.Parameters.Add(param_submissionId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { submission = createSubmission(dbReader); }
                        else { submission = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    submission = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    submission = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    submission = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    submission = null;
                    Log.Add(ex.ToString());
                }
                return submission;
            }
        }

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        public List<Submission> getAllSubmissions(int offset, int limit)
        {
            string sqlQuery = "SELECT * FROM Submissions " +
                "ORDER BY DateSubmitted DESC " +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                List<Submission> submissions = new List<Submission>();
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
                            Submission submission = createSubmission(dbReader);
                            submissions.Add(submission);
                        }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    submissions = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    submissions = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    submissions = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    submissions = null;
                    Log.Add(ex.ToString());
                }
                return submissions;
            }
        }

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        public List<Submission> getSubmissionsByTimeInterval(DateTimeOffset startTime, DateTimeOffset endTime, int offset, int limit)
        {
            string sqlQuery = "SELECT * FROM Submissions WHERE " +
                "DateSubmitted >= @StartTime AND DateSubmitted <= @EndTime " +
                "ORDER BY DateSubmitted DESC " +
                "OFFSET @Offset ROWS " + 
                "FETCH NEXT @Limit ROWS ONLY";
            
            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                List<Submission> submissions = new List<Submission>();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_startTime.Value = startTime;
                        sqlCommand.Parameters.Add(param_startTime);

                        param_endTime.Value = endTime;
                        sqlCommand.Parameters.Add(param_endTime);

                        param_offset.Value = offset;
                        sqlCommand.Parameters.Add(param_offset);

                        param_limit.Value = limit;
                        sqlCommand.Parameters.Add(param_limit);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        while (dbReader.Read())
                        {
                            Submission submission = createSubmission(dbReader);
                            submissions.Add(submission);
                        }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    submissions = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    submissions = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    submissions = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    submissions = null;
                    Log.Add(ex.ToString());
                }
                return submissions;
            }
        }

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        public List<Submission> getSubmissionsByIsAwarded(bool isAwarded, int offset, int limit)
        {
            string sqlQuery = "SELECT * FROM Submissions WHERE " +
                "IsAwarded = @IsAwarded " +
                "ORDER BY DateSubmitted DESC " +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                List<Submission> submissions = new List<Submission>();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_isAwarded.Value = isAwarded;
                        sqlCommand.Parameters.Add(param_isAwarded);

                        param_offset.Value = offset;
                        sqlCommand.Parameters.Add(param_offset);

                        param_limit.Value = limit;
                        sqlCommand.Parameters.Add(param_limit);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        while (dbReader.Read())
                        {
                            Submission submission = createSubmission(dbReader);
                            submissions.Add(submission);
                        }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    submissions = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    submissions = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    submissions = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    submissions = null;
                    Log.Add(ex.ToString());
                }
                return submissions;
            }
        }

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        public List<Submission> getSubmissionsByUserId(int userId, int offset, int limit)
        {
            string sqlQuery = "SELECT * FROM Submissions WHERE " +
                "UserId = @UserId " +
                "ORDER BY DateSubmitted DESC " +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                List<Submission> submissions = new List<Submission>();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_userId.Value = userId;
                        sqlCommand.Parameters.Add(param_userId);

                        param_offset.Value = offset;
                        sqlCommand.Parameters.Add(param_offset);

                        param_limit.Value = limit;
                        sqlCommand.Parameters.Add(param_limit);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        while (dbReader.Read())
                        {
                            Submission submission = createSubmission(dbReader);
                            submissions.Add(submission);
                        }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    submissions = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    submissions = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    submissions = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    submissions = null;
                    Log.Add(ex.ToString());
                }
                return submissions;
            }
        }

        //returns "MODEL.Submission" object if successful
        //returns "null" if not
        public Submission findSubmissionByUploadId(int uploadId)
        {
            string sqlQuery = "SELECT * FROM Submissions WHERE " +
                "UploadId = @UploadId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Submission submission = new Submission();
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
                        if (dbReader.Read()) { submission = createSubmission(dbReader); }
                        else { submission = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    submission = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    submission = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    submission = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    submission = null;
                    Log.Add(ex.ToString());
                }
                return submission;
            }
        }

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        public List<Submission> getSubmissionsByJobId(int jobId, int offset, int limit)
        {
            string sqlQuery = "SELECT * FROM Submissions WHERE " +
                "JobId = @JobId " +
                "ORDER BY DateSubmitted DESC " +
                "OFFSET @Offset ROWS " +
                "FETCH NEXT @Limit ROWS ONLY";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                List<Submission> submissions = new List<Submission>();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_jobId.Value = jobId;
                        sqlCommand.Parameters.Add(param_jobId);

                        param_offset.Value = offset;
                        sqlCommand.Parameters.Add(param_offset);

                        param_limit.Value = limit;
                        sqlCommand.Parameters.Add(param_limit);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        while (dbReader.Read())
                        {
                            Submission submission = createSubmission(dbReader);
                            submissions.Add(submission);
                        }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    submissions = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    submissions = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    submissions = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    submissions = null;
                    Log.Add(ex.ToString());
                }
                return submissions;
            }
        }
    }
}
