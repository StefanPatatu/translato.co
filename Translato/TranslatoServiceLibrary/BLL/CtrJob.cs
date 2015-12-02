//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.DAL;

namespace TranslatoServiceLibrary.BLL
{
    public class CtrJob
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertJob(Job job)
        {
            int result = -1;

            //validate jobName
            if (
                result == 0 ||
                !Validate.isAlphaNumericWithUnderscore(job.jobName) ||
                job.jobName.Equals(null) ||
                !Validate.hasMaxLength(job.jobName, 50) ||
                !Validate.hasMinLength(job.jobName, 1)
              )
            { result = 0; }

            //validate dateCreated
            if (
                result == 0 ||
                job.dateCreated.Equals(null)
                )
            { result = 0; }

            //validate durationInDays
            if (
                result == 0 ||
                job.durationInDays<1 ||
                job.durationInDays.Equals(null)
                )
            { result = 0; }

            //validate languageFrom
            if (
                result == 0 ||
                job.languageFrom.Equals(null)
                )
            { result = 0; }

            //validate languageTo
            if (
                result == 0 ||
                job.languageTo.Equals(null)
                )
            { result = 0; }

            //validate user
            if (
                result == 0 ||
                job.user.Equals(null)
                )
            { result = 0; }

            //validate upload
            if (
                result == 0 ||
                job.upload.Equals(null)
                )
            { result = 0; }

            if (result != 0)//safe to proceed
            {
                IJobs _DbJobs = new DbJobs();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbJobs.insertJob(job);

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
