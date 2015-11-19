using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ServiceReference1;

namespace WebClient
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RegisterUser(object sender, EventArgs e)
        {
            TranslatoServiceClient tsc = new TranslatoServiceClient();

            string UserName = TBUserName.Text; 
            string Password = TBPassword.Text;
            string FirstName = TBFirstName.Text;
            string LastName = TBLastName.Text;
            string Email = TBEmail.Text;
            bool NewsletterOptOut = CBNewsletterOptOut.Checked;

            User user = new User();
            user.UserName = UserName;
            user.HashedPassword = Password;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;
            user.NewsletterOptOut = NewsletterOptOut;

            int result = tsc.InsertUser(user);
            string output;
            if (result == 1)
            {
                output = "Account created successfully.";                
            }
            else
            {
                output = "Error. Please try again.";
            }
            LBResult.Text = output;
        }
    }
}