using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.BLL;


namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TranslatoService : ITranslatoService
    {
        public int InsertUser(User user)
        {
            CtrUser _ctrUser = new CtrUser();
            return _ctrUser.insertUser(user);
        }
    }
}
