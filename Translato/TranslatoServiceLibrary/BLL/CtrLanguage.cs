//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.DAL;

namespace TranslatoServiceLibrary.BLL
{
    public class CtrLanguage
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertLanguage(Language language)
        {
            int result = -1;

            //validate languageName
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

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbLanguages.insertLanguage(language);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
