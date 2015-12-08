//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrSubmission
    {
        //returns "1" if successful
        //returns "0" if failure of any kind
        //todo@futz
        internal int insertSubmission(Submission submission)
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
                    X.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    X.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    X.Log.Add(ex.ToString());
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
