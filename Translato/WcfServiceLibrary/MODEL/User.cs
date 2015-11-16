using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: futz
//helpers:

namespace WcfServiceLibrary.MODEL
{
    public class User
    {
        private int p_UserId;
        private string p_UserName;
        private string p_HashedPassword;
        private string p_PasswordSalt;
        private string p_FirstName;
        private string p_LastName;
        private string p_Email;
        private bool p_NewsletterOptOut;
        public User()
        {

        }
        public User(
            int UserId,
            string UserName,
            string HashedPassword,
            string PasswordSalt,
            string FirstName,
            string LastName,
            string Email,
            bool NewsletterOptOut)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.HashedPassword = HashedPassword;
            this.PasswordSalt = PasswordSalt;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.NewsletterOptOut = NewsletterOptOut;
        }
        public int UserId
        {
            get { return p_UserId; }
            set { p_UserId = value; }
        }
        public string UserName
        {
            get { return p_UserName; }
            set { p_UserName = value; }
        }
        public string HashedPassword
        {
            get { return p_HashedPassword; }
            set { p_HashedPassword = value; }
        }
        public string PasswordSalt
        {
            get { return p_PasswordSalt; }
            set { p_PasswordSalt = value; }
        }
        public string FirstName
        {
            get { return p_FirstName; }
            set { p_FirstName = value; }
        }
        public string LastName
        {
            get { return p_LastName; }
            set { p_LastName = value; }
        }
        public string Email
        {
            get { return p_Email; }
            set { p_Email = value; }
        }
        public bool NewsletterOptOut
        {
            get { return p_NewsletterOptOut; }
            set { p_NewsletterOptOut = value; }
        }
    }
}
