//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrLanguage
    {
        //returns "1" if successful
        //returns "0" if failure of any kind
        //todo@futz
        internal int insertLanguage(Language language)
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
