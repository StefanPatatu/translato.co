//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System;

namespace TranslatoServiceLibrary.MODEL
{
    public class User
    {   
        //private attributes
        private int p_userId;
        private string p_userName;
        private string p_hashedPassword;
        private string p_firstName;
        private string p_lastName;
        private string p_email;
        private bool p_newsletterOptOut;
        private DateTimeOffset p_createdOn;
        
        //empty constructor
        public User()
        {

        }
        
        //full constructor
        public User(
            int userId,
            string userName,
            string hashedPassword,
            string firstName,
            string lastName,
            string email,
            bool newsletterOptOut,
            DateTimeOffset createdOn
            )
        {
            this.userId = userId;
            this.userName = userName;
            this.hashedPassword = hashedPassword;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.newsletterOptOut = newsletterOptOut;
            this.createdOn = createdOn;
        }

        //getters and setters
        public int userId
        {
            get { return p_userId; }
            set { p_userId = value; }
        }
        public string userName
        {
            get { return p_userName; }
            set { p_userName = value; }
        }
        public string hashedPassword
        {
            get { return p_hashedPassword; }
            set { p_hashedPassword = value; }
        }
        public string firstName
        {
            get { return p_firstName; }
            set { p_firstName = value; }
        }
        public string lastName
        {
            get { return p_lastName; }
            set { p_lastName = value; }
        }
        public string email
        {
            get { return p_email; }
            set { p_email = value; }
        }
        public bool newsletterOptOut
        {
            get { return p_newsletterOptOut; }
            set { p_newsletterOptOut = value; }
        }
        public DateTimeOffset createdOn
        {
            get { return p_createdOn; }
            set { p_createdOn = value; }
        }
    }
}
