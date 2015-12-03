using System;
using TranslatoWebsite.TranslatoAzureService;

namespace TranslatoWebsite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void registerUser(object sender, EventArgs e)
        {
            TranslatoServiceClient tsc = new TranslatoServiceClient();

            string userName = TBX_Username.Text;
            string password = TBX_Password.Text;
            string firstName = TBX_First_name.Text;
            string lastName = TBX_Last_name.Text;
            string email = TBX_Email_address.Text;
            bool newsletterOptOut = CBX_Unsubscribe.Checked;

            User user = new User();
            user.userName = userName;
            user.hashedPassword = password;
            user.firstName = firstName;
            user.lastName = lastName;
            user.email = email;
            user.newsletterOptOut = newsletterOptOut;

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
            LBL_Output_text.Text = output;
        }
    }
}