//author: kristis133
//helpers:
//last_checked: futz@20.11.2015

namespace Translato.MODEL
{
    public class Language
    {
        //private attributes
        private int p_languageId;
        private string p_languageName;

        //empty constructor
        public Language()
        {

        }

        //full constructor
        public Language(
            int languageId,
            string languageName
            )
        {
            this.languageId = languageId;
            this.languageName = languageName;
        }

        //getters and setters
        public int languageId
        {
            get { return p_languageId; }
            set { p_languageId = value; }
        }
        public string languageName
        {
            get { return p_languageName; }
            set { p_languageName = value; }
        }
    }
}
