//author: futz
//helpers:
//last_cheked: futz@20.11.2015

using System.ServiceModel;
using Translato.MODEL;

namespace Translato
{
    [ServiceContract]
    public interface ITranslatoService
    {
        [OperationContract]
        int insertUser(User user);
    }
}
