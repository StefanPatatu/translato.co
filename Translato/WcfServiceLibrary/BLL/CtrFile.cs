//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
{
    public class CtrFile
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertFile(File file)
        {
            int result = -1;

           //validations to be added

            if (result != 0)//safe to proceed
            {
                IFiles _DbFiles = new DbFiles();

                try
                {
                    using (TransactionScope trScope = new TransactionScope())
                    {
                        result = _DbFiles.insertFile(file);

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
