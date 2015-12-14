//author: futz
//helpers:
//last_cheked: futz@14.12.2015

using System.ServiceModel;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceInsertSubmission
    {
        [OperationContract(Name = "insertSubmissionText")]
        ServiceInsertSubmission.ReturnedObject insertSubmissionText(string publicKey, string privateKey, Submission submission);

        [OperationContract(Name = "insertSubmissionFile")]
        ServiceInsertSubmission.ReturnedObject insertSubmissionFile(string publicKey, string privateKey, Submission submission);
    }
}
