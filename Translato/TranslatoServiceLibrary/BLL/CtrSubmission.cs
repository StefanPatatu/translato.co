//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.DAL;

namespace TranslatoServiceLibrary.BLL
{
    public class CtrSubmission
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertSubmission(Submission submission)
        {
            int result = -1;

            //validate dateSubmitted
            if (
                result == 0 ||
                submission.dateSubmitted.Equals(null)
               ) { result = 0; }

            //validate isAwarded
            if (
                result == 0 ||
                submission.isAwarded.Equals(null)
               )
            { result = 0; }

            //validate userId
            if (
                result == 0 ||
                submission.user.Equals(null)
                )
            { result = 0; }

            //validate uploadId
            if (
                result == 0 ||
                submission.upload.Equals(null)
                )
            { result = 0; }

            //validate jobId
            if (
                result == 0 ||
                submission.job.Equals(null)
                )
            { result = 0; }

            if (result != 0)//safe to proceed
            {
                ISubmissions _DbSubmissions = new DbSubmissions();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbSubmissions.insertSubmission(submission);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
