//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System.Runtime.Serialization;

namespace TranslatoServiceLibrary.MODEL
{
    [DataContract]
    internal sealed class File
    {   
        //private attributes
        private int p_fileId;
        
        //empty constructor
        internal File()
        {

        }
        
        //full constructor
        internal File(
            int fileId
            )
        {
            this.fileId = fileId;
        }

        //getters and setters
        [DataMember]
        internal int fileId
        {
            get { return p_fileId; }
            set { p_fileId = value; }
        }
    }
}
