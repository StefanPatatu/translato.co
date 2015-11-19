using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

//author: futz
//helpers:

namespace WcfServiceLibrary.BLL
{
    public class CtrUser
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertUser(User user)
        {
            int result = -1;

            //validate UserName 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.UserName) ||
                !Validate.isAlphaNumeric(user.UserName) ||
                !Validate.hasMinLength(user.UserName, 5) ||
                !Validate.hasMaxLength(user.UserName, 15)
               ) { result = 0; }
            //validate password(stored in the HashedPassword field at this point. Will be replaced with hash + salt later)
            if (
                result == 0 ||
                !Validate.hasMinLength(user.HashedPassword, 15)
               ) { result = 0; }
            //validate FirstName 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.FirstName) ||
                !Validate.hasMinLength(user.FirstName, 2) ||
                !Validate.hasMaxLength(user.FirstName, 20)
               )
            { result = 0; }
            //validate LastName 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.LastName) ||
                !Validate.hasMinLength(user.LastName, 2) ||
                !Validate.hasMaxLength(user.LastName, 20)
               )
            { result = 0; }
            //validate Email 
            if (
                result == 0 ||
                string.IsNullOrEmpty(user.Email) ||
                !Validate.hasMinLength(user.Email, 5) ||
                !Validate.hasMaxLength(user.Email, 50) ||
                !user.Email.Contains("@")
               )
            { result = 0; }
            if (result != 0)//safe to proceed
            {
                user.UserName = user.UserName;
                user.HashedPassword = Password.HashPassword(user.HashedPassword);
                user.FirstName = user.FirstName;
                user.LastName = user.LastName;
                user.Email = user.Email;
                user.NewsletterOptOut = user.NewsletterOptOut;
                user.CreatedOn = user.CreatedOn;

                IUsers _DbUsers = new DbUsers();

                result = _DbUsers.insertUser(user);
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
