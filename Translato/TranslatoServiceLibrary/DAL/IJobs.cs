//author: adrian
//helpers: futz
//last_checked: futz@10.12.2015
//talked about with Alex

using System.Collections.Generic;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface IJobs
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertJob(Job job);

        //returns "MODEL.Job" object if successful
        //returns "null" if not
        Job findJobByJobId(int jobId);

        //returns "List<MODEL.Job>" object if successful
        //returns "null" if not
        List<Job> getAllJobs(int offset, int limit);
    }
}
