using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.BLL;

//author: futz
//helpers:

namespace WcfServiceLibrary
{
    public class TranslatoService : ITranslatoService
    {
        public int InsertUser(User user)
        {
            CtrUser _ctrUser = new CtrUser();
            return _ctrUser.insertUser(user);
        }
    }
}
