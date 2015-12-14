//author: futz
//helpers:
//last_cheked: futz@14.12.2015

using ENUM;
using System.Runtime.Serialization;
using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertJob : IServiceInsertJob
    {
        public ReturnedObject insertJobText(string publicKey, string privateKey, Job job)
        {
            ReturnedObject returnedObject = new ReturnedObject();
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrJob _CtrJob = new CtrJob();
                returnedObject.code = _CtrJob.insertJobText(job);
            }
            else
            {
                returnedObject.code = (int)CODE.CLIENT_NOT_AUTHORIZED;
            }
            return returnedObject;
        }

        public ReturnedObject insertJobFile(string publicKey, string privateKey, Job job)
        {
            ReturnedObject returnedObject = new ReturnedObject();
            if (Security.authorizeClient(publicKey, privateKey))
            {
                CtrJob _CtrJob = new CtrJob();
                returnedObject.code = _CtrJob.insertJobFile(job);
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
