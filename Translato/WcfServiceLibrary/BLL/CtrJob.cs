//author: adrian
//helpers:
//last_checked:

using System;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
{
    public class CtrJob
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertJob(Job job)
        {
            int result = -1;

            //validate JobName
            if (
                result == 0 ||
                !Validate.isAlphaNumericWithUnderscore(job.jobName) ||
                job.jobName.Equals(null) ||
                !Validate.hasMaxLength(job.jobName, 50) ||
                !Validate.hasMinLength(job.jobName, 1)
              )
            { result = 0; }

            //validate DateCreated
            if (
                result == 0 ||
                job.dateCreated.Equals(null)
                )
            { result = 0; }

            //validate DurationInDays
            if (
                result == 0 ||
                job.durationInDays<1 ||
                job.durationInDays.Equals(null)
                )
            { result = 0; }

            //validate LanguageFrom
            if (
                result == 0 ||
                job.languageFrom.Equals(null)
                )
            { result = 0; }

            //validate LanguageTo
            if (
                result == 0 ||
                job.languageTo.Equals(null)
                )
            { result = 0; }

            //validate User
            if (
                result == 0 ||
                job.user.Equals(null)
                )
            { result = 0; }

            //validate Upload
            if (
                result == 0 ||
                job.upload.Equals(null)
                )
            { result = 0; }

            if (result != 0)//safe to proceed
            {
                IJobs _DbJobs = new DbJobs();

                result = _DbJobs.insertJob(job);
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
