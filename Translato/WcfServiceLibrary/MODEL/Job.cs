using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: adrian
//helpers:
namespace WcfServiceLibrary.MODEL
{
    public class Job
    {   //private attributes
        private int p_JobId;
        private string p_JobName;
        private DateTimeOffset p_DateCreated;
        private int p_DurationInDays;
        private decimal p_Reward;
        private DateTimeOffset p_DateAwarded;
        private Language p_LanguageFrom, p_LanguageTo;
        private User p_User;
        private Upload p_Upload;

        //empty constructor
        public Job()
        {

        }

        //constructor with parameters
        public Job(
            int JobId,
            string JobName,
            DateTimeOffset DateCreated,
            int DurationInDays,
            decimal Reward,
            DateTimeOffset DateAwarded,
            Language LanguageFrom,
            Language LanguageTo,
            User User,
            Upload Upload
            )
        {
            this.JobId = JobId;
            this.JobName = JobName;
            this.DateCreated = DateCreated;
            this.DurationInDays = DurationInDays;
            this.Reward = Reward;
            this.DateAwarded = DateAwarded;
            this.LanguageFrom = LanguageFrom;
            this.LanguageTo = LanguageTo;
            this.User = User;
            this.Upload = Upload;
        }

        //constructor without id 
        public Job(
            
            string JobName,
            DateTimeOffset DateCreated,
            int DurationInDays,
            decimal Reward,
            DateTimeOffset DateAwarded,
            Language LanguageFrom,
            Language LanguageTo,
            User User,
            Upload Upload
            )
        {
            
            this.JobName = JobName;
            this.DateCreated = DateCreated;
            this.DurationInDays = DurationInDays;
            this.Reward = Reward;
            this.DateAwarded = DateAwarded;
            this.LanguageFrom = LanguageFrom;
            this.LanguageTo = LanguageTo;
            this.User = User;
            this.Upload = Upload;
        }

        //gets and sets


        public int JobId
        {
            get { return p_JobId; }
            set { p_JobId = value; }
        }
        public string JobName
        {
            get { return p_JobName; }
            set { p_JobName = value; }
        }
        public DateTimeOffset DateCreated
        {
            get { return p_DateCreated; }
            set { p_DateCreated = value; }
        }
        public int DurationInDays
        {
            get { return p_DurationInDays; }
            set { p_DurationInDays = value; }
        }
        public decimal Reward
        {
            get { return p_Reward; }
            set { p_Reward = value; }
        }
        public DateTimeOffset DateAwarded
        {
            get { return p_DateAwarded; }
            set { p_DateAwarded = value; }
        }
        public Language LanguageFrom
        {
            get { return p_LanguageFrom; }
            set { p_LanguageFrom = value; }
        }
        public Language LanguageTo
        {
            get { return p_LanguageTo; }
            set { p_LanguageTo = value; }
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

    }
}
