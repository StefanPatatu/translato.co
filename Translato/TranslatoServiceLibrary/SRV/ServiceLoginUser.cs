//author: futz
//helpers:
//last_cheked: futz@05.12.2015

using TranslatoServiceLibrary.BLL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceLoginUser : IServiceLoginUser
    {
        public bool loginUser(string publicKey, string privateKey, string userNameOrEmail, string HRpassword)
        {
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrUser _CtrUser = new CtrUser();
                return _CtrUser.loginUser(userNameOrEmail, HRpassword);
            }
            else
            {
                return false;  //(int)ERR.CLIENT_NOT_AUTHORIZED;
            }
        }
    }
}
