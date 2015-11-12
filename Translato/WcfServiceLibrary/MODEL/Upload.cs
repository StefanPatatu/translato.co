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
        private int p_TextId;
        private int p_FileId;

        private Upload()
        {

        }

        public Upload(
            int UploadId,
            string Type,
            int TextId,
            int FileId)
        {
            this.UploadId = UploadId;
            this.Type = Type;
            this.TextId = TextId;
            this.FileId = FileId;
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
        public int TextId
        {
            get { return p_TextId; }
            set { p_TextId = value; }
        }
        public int FileId
        {
            get { return p_FileId; }
            set { p_FileId = value; }
        }
    }
}
