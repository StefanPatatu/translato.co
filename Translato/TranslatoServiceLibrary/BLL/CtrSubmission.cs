//author: adrian
//helpers: futz
//last_checked: futz@14.12.2015

using ENUM;
using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrSubmission
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertSubmissionText(Submission submission)
        {
            return insertSubmission(submission, true, false);
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertSubmissionFile(Submission submission)
        {
            return insertSubmission(submission, false, true);
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        private int insertSubmission(Submission submission, bool isText, bool isFile)
        {
            if ((isText && isFile) || (!isText && !isFile)) return (int)CODE.CTRSUBMISSION_INSERTSUBMISSION_ISBOTHORNEITHER;//means the functions was called wrong

            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate dateSubmitted
            if (
                 result == (int)CODE.ZERO ||
                 returnCode != (int)CODE.ZERO
                //nothing to validate here at this point
                )
            {
                if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_INVALID_DATESUBMITTED; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_INVALID_DATESUBMITTED; result = (int)CODE.ZERO;
            }
            //validate isAwarded
            if (
                 result == (int)CODE.ZERO ||
                 returnCode != (int)CODE.ZERO
                //nothing to validate here at this point
                )
            {
                if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_INVALID_ISAWARDED; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_INVALID_ISAWARDED; result = (int)CODE.ZERO;
            }
            //validate user
            //has to exist
            CtrUser _CtrUser = new CtrUser();
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                submission.user.Equals(null) ||
                _CtrUser.findUserByUserId(submission.user.userId) == null
               )
            {
                if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_INVALID_USER; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_INVALID_USER; result = (int)CODE.ZERO;
            }
            //validate upload
            //does not have to exist; will be created
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                submission.upload.Equals(null)
               )
            {
                if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_INVALID_UPLOAD; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_INVALID_UPLOAD; result = (int)CODE.ZERO;

            }
            //validate job
            //has to exist
            CtrJob _CtrJob = new CtrJob();
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                submission.job.Equals(null) ||
                _CtrJob.findJobByJobId(submission.job.jobId) == null
               )
            {
                if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_INVALID_JOB; result = (int)CODE.ZERO;
                if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_INVALID_JOB; result = (int)CODE.ZERO;
            }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
            {
                submission.dateSubmitted = DateTimeOffset.Now;
                submission.isAwarded = false;
                submission.user = submission.user;
                submission.upload = submission.upload;
                submission.job = submission.job;

                CtrUpload _CtrUpload = new CtrUpload();
                ISubmissions _DbSubmissions = new DbSubmissions();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        if (isText) returnCode = _CtrUpload.insertUploadText(submission.upload);
                        if (isFile) returnCode = _CtrUpload.insertUploadFile(submission.upload);
                        if (returnCode >= (int)CODE.TRANSLATO_DATABASE_SEED)//means upload was inserted successfully
                        {
                            submission.upload.uploadId = returnCode;
                            returnCode = _DbSubmissions.insertSubmission(submission);
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
                    if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_EXCEPTION;
                    if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_EXCEPTION;
                    if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    if (isText) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONTEXT_EXCEPTION;
                    if (isFile) returnCode = (int)CODE.CTRSUBMISSION_INSERTSUBMISSIONFILE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }

        //returns "MODEL.Submission" object if successful/found
        //returns "null" if not
        internal Submission findSubmissionBySubmissionId(int submissionId)
        {
            int result = (int)CODE.MINUS_ONE;
            Submission submission = null;

            //validate submissionId
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(submissionId.ToString()) ||
                !Validate.isAllNumbers(submissionId.ToString()) ||
                !Validate.integerIsBiggerThan(submissionId, (int)CODE.TRANSLATO_DATABASE_SEED - 1)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                ISubmissions _DbSubmission = new DbSubmissions();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        submission = _DbSubmission.findSubmissionBySubmissionId(submissionId);

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

            if (result == (int)CODE.ZERO || submission == null) { return null; }
            else { return submission; }
        }
    }
}
