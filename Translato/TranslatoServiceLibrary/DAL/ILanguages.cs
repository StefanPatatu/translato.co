//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface ILanguages
    {
        //returns "1" if successful
        //returns "0" if not
        int insertLanguage(Language language);

        //returns "Model.Language" object if successful
        //returns "null" if not
        Language findLanguageByLanguageId(int langugeId);

        //returns "Model.Language" object if successful
        //returns "null" if not
        Language findLanguageByLanguageName(string languageName);

    }
}

