//author: futz
//helpers:
//last_cheked: futz@03.12.2015

using TranslatoServiceLibrary.BLL;

namespace TranslatoServiceLibrary.SRV
{
    public class ServiceLoginUser : IServiceLoginUser
    {
        public bool loginUser(string userNameOrEmail, string HRpassword)
        {
            CtrUser _CtrUser = new CtrUser();
            return _CtrUser.loginUser(userNameOrEmail, HRpassword);
        }
    }
}
