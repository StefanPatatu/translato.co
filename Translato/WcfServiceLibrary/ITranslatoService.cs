using System.ServiceModel;
using WcfServiceLibrary.MODEL;

//author: futz
//helpers:

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface ITranslatoService
    {
        [OperationContract]
        int InsertUser(User user);
    }
}
