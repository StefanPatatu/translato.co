//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
{
    public class CtrText
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertText(Text text)
        {
            int result = -1;

            //validate textData
            if (
                result == 0 ||
                string.IsNullOrEmpty(text.textData) ||
                !Validate.hasMinLength(text.textData, 1) ||
                !Validate.hasMaxLength(text.textData, 40000)
                ) { result = 0; }

            if (result != 0)//safe to proceed
            {
                text.textData = text.textData;

                ITexts _DbTexts = new DbTexts();

                try
                {
                    using (TransactionScope trScope = new TransactionScope())
                    {
                        result = _DbTexts.insertText(text);

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
