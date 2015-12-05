//author: futz
//helpers:
//last_cheked: futz@05.12.2015

using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertUser : IServiceInsertUser
    {
        public int insertUser(string publicKey, string privateKey, User user)
        {
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrUser _CtrUser = new CtrUser();
                return _CtrUser.insertUser(user);
            }
            else
            {
                return (int)ERR.CLIENT_NOT_AUTHORIZED;
            } 
        }
    }
}
