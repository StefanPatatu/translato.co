//author: kristis133
//helpers:
//last_checked: futz@20.11.2015

namespace TranslatoServiceLibrary.MODEL
{
    public class Text
    {
        //private attributes
        private int p_textId;
        private string p_textData;

        //empty constructor
        public Text()
        {

        }

        //full constructor
        public Text(
            int textId,
            string textData
            )
        {
            this.textId = textId;
            this.textData = textData;
        }

        //getters and testers
        public int textId
        {
            get { return p_textId; }
            set { p_textId = value; }
        }
        public string textData
        {
            get { return p_textData; }
            set { p_textData = value; }
        }
    }
}
