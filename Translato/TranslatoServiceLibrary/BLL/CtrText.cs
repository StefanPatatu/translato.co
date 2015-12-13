//author: adrian
//helpers: futz
//last_checked: futz@11.12.2015

using ENUM;
using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrText
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertText(Text text)
        {
            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate textData
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(text.textData) ||
                !Validate.hasMinLength(text.textData, 1) ||
                !Validate.hasMaxLength(text.textData, 40000)
                ) {returnCode = (int)CODE.CTRTEXT_INSERTTEXT_INVALID_TEXTDATA; result = (int)CODE.ZERO; }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
            {
                text.textData = text.textData;

                ITexts _DbTexts = new DbTexts();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        returnCode = _DbTexts.insertText(text);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    returnCode = (int)CODE.CTRTEXT_INSERTTEXT_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    returnCode = (int)CODE.CTRTEXT_INSERTTEXT_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.CTRTEXT_INSERTTEXT_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }

        //returns "MODEL.Text" object if successful/found
        //returns "null" if not
        internal Text findTextByTextId(int textId)
        {
            int result = (int)CODE.MINUS_ONE;
            Text text = null;

            //validate textId
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(textId.ToString()) ||
                !Validate.isAllNumbers(textId.ToString()) ||
                !Validate.isBiggerThan(textId, (int)CODE.TRANSLATO_DATABASE_SEED)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                ITexts _DbTexts = new DbTexts();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        text = _DbTexts.findTextByTextId(textId);

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

            if (result == (int)CODE.ZERO || text == null) { return null; }
            else { return text; }
        }
    }
}
