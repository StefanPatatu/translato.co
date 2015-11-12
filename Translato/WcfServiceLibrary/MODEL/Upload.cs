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
        private string p_Type;
        private Text p_Text;
        private File p_File;

        private Upload()
        {

        }

        public Upload(
            int UploadId,
            string Type,
            Text Text,
            File File)
        {
            this.UploadId = UploadId;
            this.Type = Type;
            this.Text = Text;
            this.File = File;
        }

        public int UploadId
        {
            get { return p_UploadId; }
            set { p_UploadId = value; }
        }
        public string Type
        {
            get { return p_Type; }
            set { p_Type = value; }
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
