using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//author: kristupas
//helpers:

namespace WcfServiceLibrary.MODEL
{
    public class Language
    {
        private int p_LanguageId;
        private string p_LanguageName;
        private Language()
        {

        }
        public Language(
            int LanguageId,
            string LanguageName)
        {
            this.LanguageId = LanguageId;
            this.LanguageName = LanguageName;
        }
        public int LanguageId
        {
            get { return p_LanguageId; }
            set { p_LanguageId = value; }
        }
        public string LanguageName
        {
            get { return p_LanguageName; }
            set { p_LanguageName = value; }
        }
    }
}
