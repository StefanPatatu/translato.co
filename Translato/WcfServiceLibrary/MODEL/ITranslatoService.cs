using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface ITranslatoService
    {
        [OperationContract]
        int InsertUser(User user);
    }
}
