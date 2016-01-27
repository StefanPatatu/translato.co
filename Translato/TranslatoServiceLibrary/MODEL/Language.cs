//author: kristis133
//helpers: futz
//last_checked: futz@04.12.2015
//talked about with Alex

using System.Runtime.Serialization;

namespace TranslatoServiceLibrary.MODEL
{
    [DataContract]
    internal sealed class Language
    {
        //private attributes
        private int p_languageId;
        private string p_languageName;

        //empty constructor
        internal Language()
        {

        }

        //full constructor
        internal Language(
            int languageId,
            string languageName
            )
        {
            this.languageId = languageId;
            this.languageName = languageName;
        }

        //getters and setters
        [DataMember]
        internal int languageId
        {
            get { return p_languageId; }
            set { p_languageId = value; }
        }
        [DataMember]
        internal string languageName
        {
            get { return p_languageName; }
            set { p_languageName = value; }
        }
    }
}
