//author: futz
//helpers:
//last_cheked: futz@05.12.2015

using System.ServiceModel;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceInsertUser
    {
        [OperationContract(Name = "insertUser")]
        int insertUser(string publicKey, string privateKey, User user);
    }
}
