//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
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
                    using (TransactionScope trScope = new TransactionScope())
                    {
                        result = _DbLanguages.insertLanguage(language);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    Console.WriteLine(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    Console.WriteLine(aEx.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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
