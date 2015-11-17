using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: DarkSun
//helped: kool-kat

namespace WcfServiceLibrary.MODEL
{
    public class Upload
    {
        private int p_UploadId;
        // 1 text 0  file
       
        private Text p_Text;
        private File p_File;

        public Upload()
        {

        }

        public Upload(
            int UploadId,
       
            Text Text,
            File File)
        {
            this.UploadId = UploadId;
          
            this.Text = Text;
            this.File = File;
        }

        public int UploadId
        {
            get { return p_UploadId; }
            set { p_UploadId = value; }
        }
       
        public Text Text
        {
            get { return p_Text; }
            set { p_Text = value; }
        }
        public File File
        {
            get { return p_File; }
            set { p_File = value; }
        }
    }
}
