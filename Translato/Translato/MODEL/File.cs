//author: adrian
//helpers:
//last_checked: futz@20.11.2015

namespace Translato.MODEL
{
    public class File
    {   
        //private attributes
        private int p_fileId;
        
        //empty constructor
        public File()
        {

        }
        
        //full constructor
        public File(
            int fileId
            )
        {
            this.fileId = fileId;
        }

        //getters and setters
        public int fileId
        {
            get { return p_fileId; }
            set { p_fileId = value; }
        }
    }
}
