//author: futz
//helpers:
//last_cheked: futz@04.12.2015

using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertUser : IServiceInsertUser
    {
        public int insertUser(User user)
        {
            CtrUser _CtrUser = new CtrUser();
            return _CtrUser.insertUser(user);
        }
    }
}
