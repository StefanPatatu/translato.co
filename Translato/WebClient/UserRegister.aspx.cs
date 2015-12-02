using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.TranslatoAzureService;

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
            user.userName = UserName;
            user.hashedPassword = Password;
            user.firstName = FirstName;
            user.lastName = LastName;
            user.email = Email;
            user.newsletterOptOut = NewsletterOptOut;

            int result = tsc.insertUser(user);
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