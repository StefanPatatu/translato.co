using System;
using TranslatoDevWebsite.ServiceInsertUser;
using TranslatoServiceLibrary.X;

namespace TranslatoDevWebsite.Tests_F8197B934C69BA4E812BBBD9ED674
{
    public partial class InsertUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerUser(object sender, EventArgs e)
        {
            ServiceInsertUserClient siuc = new ServiceInsertUserClient();

            string userName = TBX_User_name.Text;
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

            ServiceInsertUserReturnedObject siuro = siuc.insertUser(AuthData.publicKey, AuthData.privateKey, user);

            string output;
            if (siuro.code >= (int)CODE.TRANSLATO_DATABASE_SEED)
            {
                output = String.Format("Account #{0} created successfully.", siuro.code);
            }
            else
            {
                output = String.Format("Error #{0}. Please try again.", siuro.code);
            }
            LBL_Output_text.Text = output;
        }
    }
}