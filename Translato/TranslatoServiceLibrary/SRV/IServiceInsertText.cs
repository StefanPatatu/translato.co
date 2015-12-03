//author: futz
//helpers:
//last_cheked: futz@03.12.2015

using System.ServiceModel;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    [ServiceContract]
    public interface IServiceInsertText
    {
        [OperationContract(Name = "insertText")]
        int insertText(Text text);
    }
}
