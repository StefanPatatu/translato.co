using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: kristis133
//helpers:

namespace WcfServiceLibrary.MODEL
{
    public class Text
    {
        private int p_TextId;
        private string p_TextData;
        public Text()
        {

        }
        public Text(
            int TextId,
            string TextData)
        {
            this.TextId = TextId;
            this.TextData = TextData;
        }
        public int TextId
        {
            get { return p_TextId; }
            set { p_TextId = value; }
        }
        public string TextData
        {
            get { return p_TextData; }
            set { p_TextData = value; }
        }
    }
}
