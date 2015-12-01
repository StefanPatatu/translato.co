//author: adrian
//helpers: DarkSun
//last_checked: futz@20.11.2015

using System;

namespace Translato.MODEL
{
    public class Job
    {   
        //private attributes
        private int p_jobId;
        private string p_jobName;
        private DateTimeOffset p_dateCreated;
        private int p_durationInDays;
        private decimal p_reward;
        private DateTimeOffset p_dateAwarded;
        private Language p_languageFrom;
        private Language p_languageTo;
        private User p_user;
        private Upload p_upload;

        //empty constructor
        public Job()
        {

        }

        //full constructor
        public Job(
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
        public int jobId
        {
            get { return p_jobId; }
            set { p_jobId = value; }
        }
        public string jobName
        {
            get { return p_jobName; }
            set { p_jobName = value; }
        }
        public DateTimeOffset dateCreated
        {
            get { return p_dateCreated; }
            set { p_dateCreated = value; }
        }
        public int durationInDays
        {
            get { return p_durationInDays; }
            set { p_durationInDays = value; }
        }
        public decimal reward
        {
            get { return p_reward; }
            set { p_reward = value; }
        }
        public DateTimeOffset dateAwarded
        {
            get { return p_dateAwarded; }
            set { p_dateAwarded = value; }
        }
        public Language languageFrom
        {
            get { return p_languageFrom; }
            set { p_languageFrom = value; }
        }
        public Language languageTo
        {
            get { return p_languageTo; }
            set { p_languageTo = value; }
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
    }
}
