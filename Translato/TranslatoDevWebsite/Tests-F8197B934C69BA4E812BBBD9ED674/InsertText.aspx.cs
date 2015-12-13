//author: futz
//helpers:
//last_checked: futz@11.12.2015

using ENUM;
using System;
using TranslatoDevWebsite.Cookies;
using TranslatoDevWebsite.ServiceInsertText;

namespace TranslatoDevWebsite.Tests_F8197B934C69BA4E812BBBD9ED674
{
    public partial class InsertText : System.Web.UI.Page
    {
        bool isLoggedIn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["LoginCookie"] != null)
            {
                LoginCookie _loginCookie = new LoginCookie();
                isLoggedIn = _loginCookie.validateLoginCookie(Request.Cookies["LoginCookie"]); 
            }
            else { isLoggedIn = false; }
        }

        protected void submitText(object sender, EventArgs e)
        {
            ServiceInsertTextClient sitc = new ServiceInsertTextClient();

            string textData = TBX_Text_data.Text;

            Text text = new Text();
            text.textData = textData;

            ServiceInsertTextReturnedObject siuro = sitc.insertText(AuthData.publicKey, AuthData.privateKey, text);

            string output;
            if (siuro.code >= (int)CODE.TRANSLATO_DATABASE_SEED)
            {
                output = String.Format("Text #{0} inserted successfully.", siuro.code);
            }
            else
            {
                output = String.Format("Error #{0}. Please try again.", siuro.code);
            }
            LBL_Output_text.Text = output;
            LBL_Login_status.Text = isLoggedIn.ToString();
        }
    }
}