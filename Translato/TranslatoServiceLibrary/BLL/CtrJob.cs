//author: adrian
//helpers: futz
//last_checked: futz@13.12.2015
//talked about with Alex

using ENUM;
using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrJob
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertJobText(Job job)
        {
            return insertJob(job, true, false);
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertJobFile(Job job)
        {
            return insertJob(job, false, true);
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        private int insertJob(Job job, bool isText, bool isFile)
        {
            if ((isText && isFile) || (!isText && !isFile)) return (int)CODE.CTRJOB_INSERTJOB_ISBOTHORNEITHER;//means the functions was called wrong
            
            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate jobName
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(job.jobName) ||
                !Validate.isAlphaNumericWithUnderscoreAndSpaceAndDash(job.jobName) ||
                !Validate.hasMaxLength(job.jobName, 50) ||
                !Validate.hasMinLength(job.jobName, 1)
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_JOBNAME; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_JOBNAME; result = (int)CODE.ZERO;
            }
            //validate dateCreated
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO
                //nothing to validate here at this point
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_DATECREATED; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_DATECREATED; result = (int)CODE.ZERO;
            }
            //validate durationInDays
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                job.durationInDays.Equals(null) ||
                !Validate.integerIsBiggerThan(job.durationInDays, 0) ||
                !Validate.integerIsSmallerThan(job.durationInDays, 32)
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_DURATIONINDAYS; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_DURATIONINDAYS; result = (int)CODE.ZERO;
            }
            //validate reward
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                job.reward.Equals(null) ||
                !Validate.decimalIsBiggerThan(job.reward, 0)
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_REWARD; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_REWARD; result = (int)CODE.ZERO;
            }
            //validate dateAwarded
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO
                //nothing to validate here at this point
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_DATEAWARDED; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_DATEAWARDED; result = (int)CODE.ZERO;

            }
            //validate languageFrom
            //has to exist
            CtrLanguage _CtrLanguageFrom = new CtrLanguage();
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                job.languageFrom.Equals(null) ||
                _CtrLanguageFrom.findLanguageByLanguageId(job.languageFrom.languageId) == null
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_LANGUAGEFROM; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_LANGUAGEFROM; result = (int)CODE.ZERO;
            }
            //validate languageTo
            //has to exist
            CtrLanguage _CtrLanguageTo = new CtrLanguage();
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                job.languageTo.Equals(null) ||
                _CtrLanguageTo.findLanguageByLanguageId(job.languageTo.languageId) == null
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_LANGUAGETO; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_LANGUAGETO; result = (int)CODE.ZERO;
            }
            //validate user
            //has to exist
            CtrUser _CtrUser = new CtrUser();
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                job.user.Equals(null) ||
                _CtrUser.findUserByUserId(job.user.userId) == null
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_USER; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_USER; result = (int)CODE.ZERO;
            }
            //validate upload
            //does not have to exist; will be created
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                job.upload.Equals(null)
               )
            {
                if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_INVALID_UPLOAD; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_INVALID_UPLOAD; result = (int)CODE.ZERO;

            }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
            {
                job.jobName = job.jobName;
                job.dateCreated = DateTimeOffset.Now;
                job.durationInDays = job.durationInDays;
                job.reward = job.reward;
                job.dateAwarded = null;
                job.languageFrom = job.languageFrom;
                job.languageTo = job.languageTo;
                job.user = job.user;
                job.upload = job.upload;

                CtrUpload _CtrUpload = new CtrUpload();
                IJobs _DbJobs = new DbJobs();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        if (isText) returnCode = _CtrUpload.insertUploadText(job.upload);
                        if (isFile) returnCode = _CtrUpload.insertUploadFile(job.upload);
                        if (returnCode >= (int)CODE.TRANSLATO_DATABASE_SEED)//means upload was inserted successfully
                        {
                            job.upload.uploadId = returnCode;
                            returnCode = _DbJobs.insertJob(job);
                        }
                        else
                        {//means upload failed to be inserted
                            trScope.Dispose();
                        }

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_EXCEPTION;
                    if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_EXCEPTION;
                    if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    if (isText) returnCode = (int)CODE.CTRJOB_INSERTJOBTEXT_EXCEPTION;
                    if (isFile) returnCode = (int)CODE.CTRJOB_INSERTJOBFILE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }

        //returns "MODEL.Job" object if successful/found
        //returns "null" if not
        internal Job findJobByJobId(int jobId)
        {
            int result = (int)CODE.MINUS_ONE;
            Job job = null;

            //validate jobId
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(jobId.ToString()) ||
                !Validate.isAllNumbers(jobId.ToString()) ||
                !Validate.integerIsBiggerThan(jobId, (int)CODE.TRANSLATO_DATABASE_SEED - 1)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                IJobs _DbJobs = new DbJobs();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        job = _DbJobs.findJobByJobId(jobId);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(ex.ToString());
                }
            }
            else { result = (int)CODE.ZERO; }

            if (result == (int)CODE.ZERO || job == null) { return null; }
            else { return job; }
        }
    }
}
