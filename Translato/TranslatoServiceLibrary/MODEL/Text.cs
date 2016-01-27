//author: kristis133
//helpers: futz
//last_checked: futz@04.12.2015
//talked about with Alex

using System.Runtime.Serialization;

namespace TranslatoServiceLibrary.MODEL
{
    [DataContract]
    internal sealed class Text
    {
        //private attributes
        private int p_textId;
        private string p_textData;

        //empty constructor
        internal Text()
        {

        }

        //full constructor
        internal Text(
            int textId,
            string textData
            )
        {
            this.textId = textId;
            this.textData = textData;
        }

        //getters and testers
        [DataMember]
        internal int textId
        {
            get { return p_textId; }
            set { p_textId = value; }
        }
        [DataMember]
        internal string textData
        {
            get { return p_textData; }
            set { p_textData = value; }
        }
    }
}
