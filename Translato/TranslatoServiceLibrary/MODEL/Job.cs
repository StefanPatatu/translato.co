//author: adrian
//helpers: DarkSun, futz
//last_checked: futz@10.12.2015

using System;
using System.Runtime.Serialization;

namespace TranslatoServiceLibrary.MODEL
{
    [DataContract]
    internal sealed class Job
    {   
        //private attributes
        private int p_jobId;
        private string p_jobName;
        private DateTimeOffset p_dateCreated;
        private int p_durationInDays;
        private decimal p_reward;
        private DateTimeOffset? p_dateAwarded;
        private Language p_languageFrom;
        private Language p_languageTo;
        private User p_user;
        private Upload p_upload;

        //empty constructor
        internal Job()
        {

        }

        //full constructor
        internal Job(
            int jobId,
            string jobName,
            DateTimeOffset dateCreated,
            int durationInDays,
            decimal reward,
            DateTimeOffset dateAwarded,
            Language languageFrom,
            Language languageTo,
            User user,
            Upload upload
            )
        {
            this.jobId = jobId;
            this.jobName = jobName;
            this.dateCreated = dateCreated;
            this.durationInDays = durationInDays;
            this.reward = reward;
            this.dateAwarded = dateAwarded;
            this.languageFrom = languageFrom;
            this.languageTo = languageTo;
            this.user = user;
            this.upload = upload;
        }

        //geters and setters
        [DataMember]
        internal int jobId
        {
            get { return p_jobId; }
            set { p_jobId = value; }
        }
        [DataMember]
        internal string jobName
        {
            get { return p_jobName; }
            set { p_jobName = value; }
        }
        [DataMember]
        internal DateTimeOffset dateCreated
        {
            get { return p_dateCreated; }
            set { p_dateCreated = value; }
        }
        [DataMember]
        internal int durationInDays
        {
            get { return p_durationInDays; }
            set { p_durationInDays = value; }
        }
        [DataMember]
        internal decimal reward
        {
            get { return p_reward; }
            set { p_reward = value; }
        }
        [DataMember]
        internal DateTimeOffset? dateAwarded
        {
            get { return p_dateAwarded; }
            set { p_dateAwarded = value; }
        }
        [DataMember]
        internal Language languageFrom
        {
            get { return p_languageFrom; }
            set { p_languageFrom = value; }
        }
        [DataMember]
        internal Language languageTo
        {
            get { return p_languageTo; }
            set { p_languageTo = value; }
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
    }
}
