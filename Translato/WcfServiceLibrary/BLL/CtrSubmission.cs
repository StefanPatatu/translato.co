//author: adrian
//helpers:
//last_checked:

using System;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
{
    public class CtrSubmission
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertSubmission(Submission submission)
        {
            int result = -1;

            //validate DateSubmitted
            if (
                result == 0 ||
                submission.dateSubmitted.Equals(null)
              )
            { result = 0; }

            //validate IsAwarded
            if (
                result == 0 ||
                submission.isAwarded.Equals(null)
                )
            { result = 0; }

            //validate UserId
            if (
                result == 0 ||
                submission.user.Equals(null)
                )
            { result = 0; }

            //validate UploadId
            if (
                result == 0 ||
                submission.upload.Equals(null)
                )
            { result = 0; }

            //validate JobId
            if (
                result == 0 ||
                submission.job.Equals(null)
                )
            { result = 0; }

            if (result != 0)//safe to proceed
            {
                ISubmissions _DbSubmissions = new DbSubmissions();

                result = _DbSubmissions.insertSubmission(submission);
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
