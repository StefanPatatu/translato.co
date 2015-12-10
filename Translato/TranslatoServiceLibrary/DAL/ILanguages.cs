//author: adrian
//helpers: futz
//last_checked: futz@10.12.2015

using System.Collections.Generic;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface ILanguages
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertLanguage(Language language);

        //returns "Model.Language" object if successful
        //returns "null" if not
        Language findLanguageByLanguageId(int langugeId);

        //returns "Model.Language" object if successful
        //returns "null" if not
        Language findLanguageByLanguageName(string languageName);

        //returns "List<MODEL.Language>" object if successful
        //returns "null" if not
        List<Language> getAllLanguages();

    }
}

