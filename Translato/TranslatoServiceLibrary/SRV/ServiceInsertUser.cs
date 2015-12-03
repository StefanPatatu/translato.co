//author: futz
//helpers:
//last_cheked: futz@03.12.2015

using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    public class ServiceInsertUser : IServiceInsertUser
    {
        public int insertUser(User user)
        {
            CtrUser _CtrUser = new CtrUser();
            return _CtrUser.insertUser(user);
        }
    }
}
