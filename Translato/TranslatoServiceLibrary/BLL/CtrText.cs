//author: adrian
//helpers: futz
//last_checked: futz@03.12.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.BLL
{
    public class CtrText
    {
        //returns "1" if successful
        //returns "0" if not
        public int insertText(Text text)
        {
            int result = -1;

            //validate textData
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(text.textData) ||
                !Validate.hasMinLength(text.textData, 1) ||
                !Validate.hasMaxLength(text.textData, 40000)
                ) { result = 0; }
            if (result != 0)//safe to proceed
            {
                text.textData = text.textData;

                ITexts _DbTexts = new DbTexts();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbTexts.insertText(text);

                        trScope.Complete();
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = 0;
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = 0;
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else { result = 0; }
            return result;
        }

        //returns "MODEL.Text" object if successful
        //returns "null" if not
        public Text findTextById(int textId)
        {
            int result = -1;
            Text text = null;

            //validate textId
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(textId.ToString()) ||
                !Validate.isAllNumbers(textId.ToString()) ||
                !Validate.isBiggerThan(textId, 0)
               ) { result = 0; }
            if (result != 0)//safe to proceed
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
                    result = 0;
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = 0;
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else { result = 0; }

            if (result == 0 || text == null) { return null; }
            else { return text; }
        }
    }
}
