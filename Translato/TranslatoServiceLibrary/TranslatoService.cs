//author: futz
//helpers:
//last_cheked: futz@20.11.2015

using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.BLL;

namespace TranslatoServiceLibrary
{
    public class TranslatoService : ITranslatoService
    {
        public int insertUser(User user)
        {
            CtrUser _CtrUser = new CtrUser();
            return _CtrUser.insertUser(user);
        }
    }
}
