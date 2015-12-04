//author: futz
//helpers:
//last_cheked: futz@04.12.2015

using TranslatoServiceLibrary.BLL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceLoginUser : IServiceLoginUser
    {
        public bool loginUser(string userNameOrEmail, string HRpassword)
        {
            CtrUser _CtrUser = new CtrUser();
            return _CtrUser.loginUser(userNameOrEmail, HRpassword);
        }
    }
}
