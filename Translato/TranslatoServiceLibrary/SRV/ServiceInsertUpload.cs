//author: futz
//helpers:
//last_cheked: futz@14.12.2015

using ENUM;
using System.Runtime.Serialization;
using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertUpload : IServiceInsertUpload
    {
        public ReturnedObject insertUploadText(string publicKey, string privateKey, Upload upload)
        {
            ReturnedObject returnedObject = new ReturnedObject();
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrUpload _CtrUpload = new CtrUpload();
                returnedObject.code = _CtrUpload.insertUploadText(upload);
            }
            else
            {
                returnedObject.code = (int)CODE.CLIENT_NOT_AUTHORIZED;
            }
            return returnedObject;
        }

        public ReturnedObject insertUploadFile(string publicKey, string privateKey, Upload upload)
        {
            ReturnedObject returnedObject = new ReturnedObject();
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrUpload _CtrUpload = new CtrUpload();
                returnedObject.code = _CtrUpload.insertUploadFile(upload);
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
