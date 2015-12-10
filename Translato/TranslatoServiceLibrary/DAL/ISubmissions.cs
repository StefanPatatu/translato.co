//author: adrian
//helpers: futz
//last_checked: futz@10.12.2015

using System;
using System.Collections.Generic;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface ISubmissions
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertSubmission(Submission submission);

        //returns "MODEL.Submission" object if successful
        //returns "null" if not
        Submission findSubmissionBySubmissionId(int submissionId);

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        List<Submission> getAllSubmissions(int offset, int limit);

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        List<Submission> getSubmissionsByTimeInterval(DateTimeOffset startTime, DateTimeOffset endTime, int offset, int limit);

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        List<Submission> getSubmissionsByIsAwarded(bool isAwarded, int offset, int limit);

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        List<Submission> getSubmissionsByUserId(int userId, int offset, int limit);

        //returns "MODEL.Submission" object if successful
        //returns "null" if not
        Submission findSubmissionByUploadId(int uploadId);

        //returns "List<MODEL.Submission>" object if successful
        //returns "null" if not
        List<Submission> getSubmissionsByJobId(int jobId, int offset, int limit);
    }
}
