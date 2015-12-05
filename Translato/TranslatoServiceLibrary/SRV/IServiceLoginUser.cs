//author: futz
//helpers:
//last_cheked: futz@05.12.2015

using System.ServiceModel;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceLoginUser
    {
        [OperationContract(Name = "loginUser")]
        bool loginUser(string publicKey, string privateKey, string userNameOrEmail, string HRpassword);
    }
}
