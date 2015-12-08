//author: futz
//helpers:
//last_cheked: futz@08.12.2015

using System.Runtime.Serialization;
using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertText : IServiceInsertText
    {
        public ReturnedObject insertText(string publicKey, string privateKey, Text text)
        {
            ReturnedObject returnedObject = new ReturnedObject();
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrText _CtrText = new CtrText();
                returnedObject.code = _CtrText.insertText(text);
            }
            else
            {
                returnedObject.code = (int)CODE.CLIENT_NOT_AUTHORIZED;
            }
            return returnedObject;
        }

        [DataContract]
        internal sealed class ReturnedObject
        {
            //private attributes
            private int p_code;

            //empty constructor
            internal ReturnedObject()
            {

            }

            //getters and setters
            [DataMember]
            internal int code
            {
                get { return p_code; }
                set { p_code = value; }
            }
        }
    }
}
