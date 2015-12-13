//author: futz
//helpers:
//last_checked: futz@11.12.2015

using ENUM;
using System;
using TranslatoDevWebsite.Cookies;
using TranslatoDevWebsite.ServiceLoginUser;

namespace TranslatoDevWebsite.Tests_F8197B934C69BA4E812BBBD9ED674
{
    public partial class LoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginUser(object sender, EventArgs e)
        {
            ServiceLoginUserClient sluc = new ServiceLoginUserClient();

            string userNameOrEmail = TBX_User_name_or_Email.Text;
            string password = TBX_Password.Text;
            bool stayLoggedIn = CBX_Stay_logged_in.Checked;

            ServiceLoginUserReturnedObject siuro = sluc.loginUser(AuthData.publicKey, AuthData.privateKey, userNameOrEmail, password);

            string output;
            if (siuro.code == (int)CODE.CTRUSER_LOGINUSER_SUCCESS)
            {
                output = "You are now logged in.";

                LoginCookie _loginCookie = new LoginCookie();

                Response.Cookies.Add(_loginCookie.createLoginCookie(userNameOrEmail));
            }
            else
            {
                output = String.Format("Error #{0}. Please try again.", siuro.code);
            }
            LBL_Output_text.Text = output;
        }
    }
}