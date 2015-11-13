using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: adrian
//helpers:
namespace WcfServiceLibrary.MODEL
{
    public class File
    {
        private int p_FileId;

        public int FileId
        {
            get { return p_FileId; }
            set { p_FileId = value; }
        }
        private File()
        {

        }
        public File(int FileId)
        {
            this.FileId = FileId;
        }

    }
}
