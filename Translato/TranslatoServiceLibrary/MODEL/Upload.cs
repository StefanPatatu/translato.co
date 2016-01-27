//author: DarkSun
//helpers: kool-kat, futz
//last_checked: futz@04.12.2015
//talked about with Alex

using System.Runtime.Serialization;

namespace TranslatoServiceLibrary.MODEL
{
    [DataContract]
    internal sealed class Upload
    {
        //private attributes
        private int p_uploadId;
        private Text p_text;
        private File p_file;

        //empty constructor
        internal Upload()
        {

        }

        //full constructor
        internal Upload(
            int uploadId,
            Text text,
            File file
            )
        {
            this.uploadId = uploadId;
            this.text = text;
            this.file = file;
        }

        //getters and setters
        [DataMember]
        internal int uploadId
        {
            get { return p_uploadId; }
            set { p_uploadId = value; }
        }
        [DataMember]
        internal Text text
        {
            get { return p_text; }
            set { p_text = value; }
        }
        [DataMember]
        internal File file
        {
            get { return p_file; }
            set { p_file = value; }
        }
    }
}
