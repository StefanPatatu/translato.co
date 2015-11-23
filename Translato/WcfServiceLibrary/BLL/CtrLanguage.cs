//author: adrian
//helpers:
//last_checked:

using System;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
{
    public class CtrLanguage
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertLanguage(Language language)
        {
            int result = -1;

            //validate LanguageName
            if (
                result == 0 ||
                string.IsNullOrEmpty(language.languageName) ||
                !Validate.hasMinLength(language.languageName, 1) ||
                !Validate.hasMaxLength(language.languageName, 15) ||
                !Validate.isAllLetters(language.languageName)
                )
            { result = 0; }

            if (result != 0)//safe to proceed
            {
                language.languageName = language.languageName;

                ILanguages _DbLanguages = new DbLanguages();

                result = _DbLanguages.insertLanguage(language);
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
