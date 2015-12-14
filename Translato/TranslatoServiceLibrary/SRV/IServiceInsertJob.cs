//author: futz
//helpers:
//last_cheked: futz@14.12.2015

using System.ServiceModel;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceInsertJob
    {
        [OperationContract(Name = "insertJobText")]
        ServiceInsertJob.ReturnedObject insertJobText(string publicKey, string privateKey, Job job);

        [OperationContract(Name = "insertJobFile")]
        ServiceInsertJob.ReturnedObject insertJobFile(string publicKey, string privateKey, Job job);
    }
}
