//author: futz
//helpers:
//last_cheked: futz@03.12.2015

using System.ServiceModel;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    public interface IServiceLoginUser
    {
        [OperationContract(Name = "loginUser")]
        bool loginUser(string userNameOrEmail, string HRpassword);
    }
}
