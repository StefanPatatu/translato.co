using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: DarkSun
//helpers:

namespace WcfServiceLibrary.MODEL
{
    public class Submission
    {
        private int p_SubmissionId;
        private DateTimeOffset p_DateSubmitted;
        private bool p_IsAwarded;
        private User p_User;
        private Upload p_Upload;
        private Job p_Job;

        public Submission()
        {

        }

        public Submission(
            int SubmissionId,
            DateTimeOffset DateSubmitted,
            bool IsAwarded,
            User User,
            Upload Upload,
            Job Job)
        {
            this.SubmissionId = SubmissionId;
            this.DateSubmitted = DateSubmitted;
            this.IsAwarded = IsAwarded;
            this.User = User;
            this.Upload = Upload;
            this.Job = Job;
        }

        public int SubmissionId
        {
            get { return p_SubmissionId; }
            set { p_SubmissionId = value; }
        }
        public DateTimeOffset DateSubmitted
        {
            get { return p_DateSubmitted; }
            set { p_DateSubmitted = value; }
        }
        public bool IsAwarded
        {
            get { return p_IsAwarded; }
            set { p_IsAwarded = value; }
        }
        public User User
        {
            get { return p_User; }
            set { p_User = value; }
        }
        public Upload Upload
        {
            get { return p_Upload; }
            set { p_Upload = value; }
        }
        public Job Job
        {
            get { return p_Job; }
            set { p_Job = value; }
        }
    }
}
