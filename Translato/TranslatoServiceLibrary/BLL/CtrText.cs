//author: adrian
//helpers: futz
//last_checked: futz@08.12.2015

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
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    returnCode = (int)CODE.CTRTEXT_INSERTTEXT_EXCEPTION;
                    X.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    returnCode = (int)CODE.CTRTEXT_INSERTTEXT_EXCEPTION;
                    X.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.CTRTEXT_INSERTTEXT_EXCEPTION;
                    X.Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }

        //returns "MODEL.Text" object if successful/found
        //returns "null" if not
        internal Text findTextById(int textId)
        {
            int result = (int)CODE.MINUS_ONE;
            Text text = null;

            //validate textId
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(textId.ToString()) ||
                !Validate.isAllNumbers(textId.ToString()) ||
                !Validate.isBiggerThan(textId, 0)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                ITexts _DbTexts = new DbTexts();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        text = _DbTexts.findTextById(textId);

                        trScope.Complete();
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = (int)CODE.ZERO;
                    X.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = (int)CODE.ZERO;
                    X.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = (int)CODE.ZERO;
                    X.Log.Add(ex.ToString());
                }
            }
            else { result = (int)CODE.ZERO; }

            if (result == (int)CODE.ZERO || text == null) { return null; }
            else { return text; }
        }
    }
}
