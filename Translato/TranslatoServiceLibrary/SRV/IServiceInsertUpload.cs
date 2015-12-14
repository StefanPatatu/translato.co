//author: futz
//helpers:
//last_cheked: futz@14.12.2015

using System.ServiceModel;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceInsertUpload
    {
        [OperationContract(Name = "insertUploadText")]
        ServiceInsertUpload.ReturnedObject insertUploadText(string publicKey, string privateKey, Upload upload);

        [OperationContract(Name = "insertUploadFile")]
        ServiceInsertUpload.ReturnedObject insertUploadFile(string publicKey, string privateKey, Upload upload);
    }
}
