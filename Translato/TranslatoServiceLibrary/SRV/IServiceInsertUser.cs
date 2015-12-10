//author: futz
//helpers:
//last_cheked: futz@10.12.2015

using System.ServiceModel;
using System.Threading.Tasks;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceInsertUser
    {
        [OperationContract(Name = "insertUser")]
        ServiceInsertUser.ReturnedObject insertUser(string publicKey, string privateKey, User user);
    }
}
