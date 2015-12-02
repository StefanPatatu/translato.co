//author: futz
//helpers:
//last_cheked: futz@20.11.2015

using System.ServiceModel;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface ITranslatoService
    {
        [OperationContract]
        int insertUser(User user);
    }
}
