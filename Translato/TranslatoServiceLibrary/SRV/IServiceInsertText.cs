//author: futz
//helpers:
//last_cheked: futz@05.12.2015

using System.ServiceModel;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    internal interface IServiceInsertText
    {
        [OperationContract(Name = "insertText")]
        int insertText(string publicKey, string privateKey, Text text);
    }
}
