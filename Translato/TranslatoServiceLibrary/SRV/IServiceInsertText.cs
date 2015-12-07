//author: futz
//helpers:
//last_cheked: futz@07.12.2015

using System.ServiceModel;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceInsertText
    {
        [OperationContract(Name = "insertText")]
        ServiceInsertText.ReturnedObject insertText(string publicKey, string privateKey, Text text);
    }
}
