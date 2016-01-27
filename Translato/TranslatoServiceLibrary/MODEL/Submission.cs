//author: DarkSun
//helpers: futz
//last_checked: futz@04.12.2015
//talked about with Alex

using System;
using System.Runtime.Serialization;

namespace TranslatoServiceLibrary.MODEL
{
    [DataContract]
    internal sealed class Submission
    {
        //private attributes
        private int p_submissionId;
        private DateTimeOffset p_dateSubmitted;
        private bool p_isAwarded;
        private User p_user;
        private Upload p_upload;
        private Job p_job;

        //empty constructor
        internal Submission()
        {

        }

        //full constructor
        internal Submission(
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
        [DataMember]
        internal int submissionId
        {
            get { return p_submissionId; }
            set { p_submissionId = value; }
        }
        [DataMember]
        internal DateTimeOffset dateSubmitted
        {
            get { return p_dateSubmitted; }
            set { p_dateSubmitted = value; }
        }
        [DataMember]
        internal bool isAwarded
        {
            get { return p_isAwarded; }
            set { p_isAwarded = value; }
        }
        [DataMember]
        internal User user
        {
            get { return p_user; }
            set { p_user = value; }
        }
        [DataMember]
        internal Upload upload
        {
            get { return p_upload; }
            set { p_upload = value; }
        }
        [DataMember]
        internal Job job
        {
            get { return p_job; }
            set { p_job = value; }
        }
    }
}
