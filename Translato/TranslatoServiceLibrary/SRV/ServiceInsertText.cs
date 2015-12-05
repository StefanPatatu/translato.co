//author: futz
//helpers:
//last_cheked: futz@05.12.2015

using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertText : IServiceInsertText
    {
        public int insertText(string publicKey, string privateKey, Text text)
        {
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrText _CtrText = new CtrText();
                return _CtrText.insertText(text);
            }
            else
            {
                return (int)ERR.CLIENT_NOT_AUTHORIZED;
            }
        }
    }
}
