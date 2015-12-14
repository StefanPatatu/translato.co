//author: futz
//helpers:
//last_cheked: futz@14.12.2015

using ENUM;
using System.Runtime.Serialization;
using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertSubmission : IServiceInsertSubmission
    {
        public ReturnedObject insertSubmissionText(string publicKey, string privateKey, Submission submission)
        {
            ReturnedObject returnedObject = new ReturnedObject();
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrSubmission _CtrSubmission = new CtrSubmission();
                returnedObject.code = _CtrSubmission.insertSubmissionText(submission);
            }
            else
            {
                returnedObject.code = (int)CODE.CLIENT_NOT_AUTHORIZED;
            }
            return returnedObject;
        }

        public ReturnedObject insertSubmissionFile(string publicKey, string privateKey, Submission submission)
        {
            ReturnedObject returnedObject = new ReturnedObject();
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrSubmission _CtrSubmission = new CtrSubmission();
                returnedObject.code = _CtrSubmission.insertSubmissionFile(submission);
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
