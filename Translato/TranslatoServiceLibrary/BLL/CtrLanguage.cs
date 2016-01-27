//author: adrian
//helpers: futz
//last_checked: futz@13.12.2015
//talked about with Alex

using ENUM;
using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrLanguage
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertLanguage(Language language)
        {
            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate languageName
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(language.languageName) ||
                !Validate.hasMinLength(language.languageName, 1) ||
                !Validate.hasMaxLength(language.languageName, 15) ||
                !Validate.isAllLetters(language.languageName)
               ) { returnCode = (int)CODE.CTRLANGUAGE_INSERTLANGUAGE_INVALIDLANGUAGENAME; result = (int)CODE.ZERO; }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
            {
                language.languageName = language.languageName;

                ILanguages _DbLanguages = new DbLanguages();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        returnCode = _DbLanguages.insertLanguage(language);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    returnCode = (int)CODE.CTRLANGUAGE_INSERTLANGUAGE_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    returnCode = (int)CODE.CTRLANGUAGE_INSERTLANGUAGE_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.CTRLANGUAGE_INSERTLANGUAGE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }

        //returns "MODEL.Language" object if successful/found
        //returns "null" if not
        internal Language findLanguageByLanguageId(int languageId)
        {
            int result = (int)CODE.MINUS_ONE;
            Language language = null;

            //validate languageId
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(languageId.ToString()) ||
                !Validate.isAllNumbers(languageId.ToString()) ||
                !Validate.integerIsBiggerThan(languageId, (int)CODE.TRANSLATO_DATABASE_SEED - 1)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                ILanguages _DbLanguages = new DbLanguages();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        language = _DbLanguages.findLanguageByLanguageId(languageId);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(ex.ToString());
                }
            }
            else { result = (int)CODE.ZERO; }

            if (result == (int)CODE.ZERO || language == null) { return null; }
            else { return language; }
        }
    }
}
