//author: DarkSun
//helpers:
//last_checked: futz@20.11.2015

using System;

namespace TranslatoServiceLibrary.MODEL
{
    public class Submission
    {
        //private attributes
        int p_submissionId;
        DateTimeOffset p_dateSubmitted;
        bool p_isAwarded;
        User p_user;
        Upload p_upload;
        Job p_job;

        //empty constructor
        public Submission()
        {

        }

        //full constructor
        public Submission(
            int submissionId,
            DateTimeOffset dateSubmitted,
            bool isAwarded,
            User user,
            Upload upload,
            Job job
            )
        {
            this.submissionId = submissionId;
            this.dateSubmitted = dateSubmitted;
            this.isAwarded = isAwarded;
            this.user = user;
            this.upload = upload;
            this.job = job;
        }

        //getters and setters
        public int submissionId
        {
            get { return p_submissionId; }
            set { p_submissionId = value; }
        }
        public DateTimeOffset dateSubmitted
        {
            get { return p_dateSubmitted; }
            set { p_dateSubmitted = value; }
        }
        public bool isAwarded
        {
            get { return p_isAwarded; }
            set { p_isAwarded = value; }
        }
        public User user
        {
            get { return p_user; }
            set { p_user = value; }
        }
        public Upload upload
        {
            get { return p_upload; }
            set { p_upload = value; }
        }
        public Job job
        {
            get { return p_job; }
            set { p_job = value; }
        }
    }
}
