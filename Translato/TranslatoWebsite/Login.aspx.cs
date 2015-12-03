using System;
using TranslatoWebsite.ServiceLoginUser;

namespace TranslatoWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginUser(object sender, EventArgs e)
        {
            ServiceLoginUserClient tsc = new ServiceLoginUserClient();

            string userNameOrEmail = TBX_User_name_or_Email.Text;
            string password = TBX_Password.Text;
            bool stayLoggedIn = CBX_Stay_logged_in.Checked;

            bool success = tsc.loginUser(userNameOrEmail, password);

            string output;
            if (success)
            {
                output = "You are now logged in.";
            }
            else
            {
                output = "Please try again.";
            }
            LBL_Output_text.Text = output;

        }
    }
}