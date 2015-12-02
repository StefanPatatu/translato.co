//author: DarkSun
//helpers: kool-kat
//last_checked: futz@20.11.2015

namespace WcfServiceLibrary.MODEL
{
    public class Upload
    {
        //private attributes
        private int p_uploadId;
        private Text p_text;
        private File p_file;

        //empty constructor
        public Upload()
        {

        }

        //full constructor
        public Upload(
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
        public int uploadId
        {
            get { return p_uploadId; }
            set { p_uploadId = value; }
        }
       
        public Text text
        {
            get { return p_text; }
            set { p_text = value; }
        }
        public File file
        {
            get { return p_file; }
            set { p_file = value; }
        }
    }
}
